using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quiz.DTOs;

namespace Quiz.Mapper
{
    public static class MapDTO
    {
        public static QuizResponse MapToQuizResponse(this Quiz.Models.Quiz quiz)
        {
            return new QuizResponse
            {
                QuizId = quiz.QuizId,
                Content = quiz.Content,
                Answers = quiz.Answers.Select(a => new Quiz.DTOs.AnswerResponse
                {
                    AnswerId = a.AnswerId,
                    Content = a.Content,
                    IsCorrect = a.IsCorrect
                }).ToList()
            };
        }
        public static Quiz.Models.Quiz MapToQuiz(this AddQuizRequest quizRequest)
        {
            return new Quiz.Models.Quiz
            {
                Content = quizRequest.Content,
                Answers = quizRequest.Answers.Select(a => new Quiz.Models.Answer
                {
                    Content = a.Content,
                    IsCorrect = a.IsCorrect
                }).ToList(),
                FeedBack = quizRequest.FeedBack
            };
        }
        public static UserHistoryResponse MapToUserHistoryResponse(this Models.UserHistory userHistory)
        {
            return new UserHistoryResponse
            {
                UserAnswerId = userHistory.UserAnswerId,
                CorrectAnswerId = userHistory.CorrectAnswerId,
                CreatedAt = userHistory.CreatedAt ?? DateTime.UtcNow,
                Quiz = new QuizHistoryResponse
                {
                    QuizId = userHistory.QuizId,
                    Content = userHistory.Quiz?.Content ?? string.Empty,
                    Answers = userHistory.Quiz?.Answers.Select(a => a.Content).ToList() ?? new List<string>()
                }
            };
        }
    }
}