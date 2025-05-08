using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quiz.DTOs;
using Quiz.Mapper;
using Quiz.Models;
using Quiz.Repository;
using Quiz.Services;

namespace Quiz.Controller
{
    [ApiController]
    [Route("api/")]
    public class QuizController : ControllerBase
    {
        private readonly BaseRepository _baseRepo;
        private readonly SeedDataService _seedDataService;

        public QuizController(BaseRepository baseRepo, SeedDataService seedDataService)
        {
            _baseRepo = baseRepo;
            _seedDataService = seedDataService;
        }

        [HttpGet("quizzes")]
        public async Task<IActionResult> GetQuizzes()
        {
            try {
                var quizzes = await _baseRepo.GetQuizzesAsync();
                return Ok(quizzes);
            } catch (Exception ex){
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("reset-user-status")]
        public async Task<IActionResult> ResetOrCreateUser()
        {
            // create a new user if userId is not provided
            var userId = Request.Cookies.ContainsKey("userId") ? int.Parse(Request.Cookies["userId"]) : 0;
            if (userId <= 0)
            {
                var user = await _baseRepo.CreateUserAsync(new UserInSession(){
                    BeginQuizAt = DateTime.Now,
                    EndQuizAt = DateTime.Now,
                    CreatedAt = DateTime.UtcNow,
                    LastActiveAt = DateTime.UtcNow
                });
                Response.Cookies.Append("userId", user.UserId.ToString(), new CookieOptions { HttpOnly = false, Secure = false, SameSite = SameSiteMode.Lax, Expires = DateTimeOffset.UtcNow.AddDays(30)});
                return Ok("New user created.");
            } else {
                await _baseRepo.ResetUserStatusAsync(userId);
            }

            return Ok($"User with ID {userId} has been reset.");
        }

        // for test purposes only
        [HttpPost("quizzes")]
        public async Task<IActionResult> AddQuiz([FromBody] AddQuizRequest addQuizRequest)
        {
            if (addQuizRequest == null)
            {
                return BadRequest("Quiz cannot be null");
            }

            if (string.IsNullOrEmpty(addQuizRequest.Content) || addQuizRequest.Answers.Count != 4)
            {
                return BadRequest("Quiz content are required and must have exactly 4 answers");
            }
            
            try {
                await _baseRepo.AddQuizAsync(addQuizRequest.MapToQuiz());
            } catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
            return StatusCode(201, addQuizRequest);
        }
        // for test purposes only
        [HttpDelete("quizzes/{id}")]
        public async Task<IActionResult> DeleteQuiz(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid quiz ID");
            }

            await _baseRepo.DeleteQuizAsync(id);
            return NoContent();
        }
        [HttpGet("seed-quiz-data")]
        public async Task<IActionResult> SeedQuizData()
        {
            try {
                await _seedDataService.SeedQuizData();
            } catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

            return Ok();
        }
        [HttpGet("quizzes/{quizId}/validate")]
        public async Task<IActionResult> ValidateQuiz([FromRoute] int quizId, [FromQuery] int selectedAnswersId)
        {
            var userId = Request.Cookies.ContainsKey("userId") ? int.Parse(Request.Cookies["userId"]) : 0;
            if (quizId <= 0 || selectedAnswersId <= 0 || userId <= 0)
            {
                return BadRequest("Invalid quiz ID, selected answer ID, or user ID");
            }
            
            try {
                var quiz = await _baseRepo.GetQuizByIdAsync(quizId);
                if (quiz == null)
                {
                    return NotFound($"Quiz with ID {quizId} not found");
                }

                // data for validation
                var correctAnswer = quiz.Answers.FirstOrDefault(a => a.IsCorrect);
                if (correctAnswer == null)
                {
                    return NotFound($"No correct answer found for quiz ID {quizId}");
                }

                // add this quiz to the user's history
                var userHistory = new UserHistory
                {
                    QuizId = quiz.QuizId,
                    UserId = userId, // Assuming a user ID of 1 for testing purposes
                    UserAnswerId = selectedAnswersId,
                    CorrectAnswerId = correctAnswer.AnswerId,
                    CreatedAt = DateTime.Now
                };
                // Console.WriteLine($"Quiz History: {userHistory.QuizId}, User ID: {userHistory.UserId}, User Answer ID: {userHistory.UserAnswerId}, Correct Answer ID: {userHistory.CorrectAnswerId}");
                await _baseRepo.AddQuizHistoryAsync(userHistory);

                return Ok(new ValidateResponse {
                    IsCorrect = correctAnswer.AnswerId == selectedAnswersId,
                    FeedBack = quiz.FeedBack,
                    CorrectAnswerId = correctAnswer.AnswerId
                });

            } catch (Exception ex)
            {
                return StatusCode(500,$"External Error: {ex.Message}");
            }
        }
        
        [HttpGet("quizzes/complete")]
        public async Task<IActionResult> CompleteQuiz()
        {
            var userId = Request.Cookies.ContainsKey("userId") ? int.Parse(Request.Cookies["userId"]) : 0;
            if (userId <= 0)
            {
                return BadRequest("Invalid user ID");
            }

            var user = await _baseRepo.GetUserByIdAsync(userId);
            if (user == null)
            {
                return NotFound($"User with ID {userId} not found");
            }

            // Update the user's status to completed
            user.LastActiveAt = DateTime.UtcNow;
            user.EndQuizAt = DateTime.Now;
            await _baseRepo.UpdateUserStatusAsync(user);

            return Ok();
        }

        [HttpGet("quizzes/statistic")]
        public async Task<IActionResult> GetTheStatisticAfterCompletion()
        {
            const int PassQuantity = 5;
            // correct answer, wrong answer, and total time
            var userId = Request.Cookies.ContainsKey("userId") ? int.Parse(Request.Cookies["userId"]) : 0;

            var user = await _baseRepo.GetUserByIdAsync(userId);
            if (user == null)
            {
                return NotFound($"User with ID {userId} not found");
            }
            var userHistory = await _baseRepo.GetUserHistoryAsync(userId);
            var statisticResponse = new StatisticResponse
            {
                TimeForQuiz = user.EndQuizAt - user.BeginQuizAt,
                CorrectAnswers = userHistory.Count(uh => uh.UserAnswerId == uh.CorrectAnswerId),
                WrongAnswers = userHistory.Count(uh => uh.UserAnswerId != uh.CorrectAnswerId),
                IsPassed = userHistory.Count(uh => uh.UserAnswerId == uh.CorrectAnswerId) >= PassQuantity,
                TotalAnswers = userHistory.Count()
            };

            return Ok(statisticResponse);
        }

        [HttpGet("quizzes/history")]
        public async Task<IActionResult> GetUserHistory()
        {
            var userId = Request.Cookies.ContainsKey("userId") ? int.Parse(Request.Cookies["userId"]) : 0;
            if (userId <= 0)
            {
                return BadRequest("Invalid user ID");
            }

            var userHistory = await _baseRepo.GetUserHistoryAsync(userId);
            if (userHistory == null || !userHistory.Any())
            {
                return NotFound($"No history found for user with ID {userId}");
            }
            var response = userHistory.Select(uh => uh.MapToUserHistoryResponse()).ToList();

            return Ok(response);
        }
    }
}