using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Quiz.Data;
using Quiz.DTOs;
using Quiz.Mapper;
using Quiz.Models;

namespace Quiz.Repository
{
    public class BaseRepository
    {
        private readonly AppDbContext _context;
        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<QuizResponse>> GetQuizzesAsync(int quantity = 10)
        {
            try {
                if (_context.Quizzes == null || !_context.Quizzes.Any())
                {
                    return new List<QuizResponse>();
                }
                Console.WriteLine("Fetching quizzes from the database...");
                int minID = await _context.Quizzes.MinAsync(q => q.QuizId);
                int maxID = await _context.Quizzes.MaxAsync(q => q.QuizId);
                int randomID = new Random().Next(minID, maxID + 1);
                var quizzes = await _context.Quizzes
                    .Include(q => q.Answers)
                    .Where(q => q.QuizId >= randomID)
                    .OrderBy(q => q.QuizId)
                    .Take(quantity)
                    .Select(q => q.MapToQuizResponse())
                    .AsNoTracking()
                    .ToListAsync();
                if (quizzes.Count < quantity)
                {
                    var additionalQuizzes = await _context.Quizzes
                        .Include(q => q.Answers)
                        .Where(q => q.QuizId < randomID)
                        .OrderBy(q => q.QuizId)
                        .Take(quantity - quizzes.Count)
                        .Select(q => q.MapToQuizResponse())
                        .AsNoTracking()
                        .ToListAsync();
                    quizzes.AddRange(additionalQuizzes);
                }
                return quizzes;
            } catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving quizzes: ", ex);
                return new List<QuizResponse>();
            }
            
        }
    
        public async Task AddQuizAsync(Quiz.Models.Quiz quiz)
        {
            await _context.Quizzes.AddAsync(quiz);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteQuizAsync(int id)
        {
            var quiz = await _context.Quizzes.FindAsync(id);
            if (quiz != null)
            {
                _context.Quizzes.Remove(quiz);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<Quiz.Models.Quiz?> GetQuizByIdAsync(int id)
        {
            var quiz = await _context.Quizzes
                .Include(q => q.Answers)
                .FirstOrDefaultAsync(q => q.QuizId == id);
            if (quiz == null)
            {
                return null;
            }
            return quiz;
        }
        public async Task ResetUserStatusAsync(int userId)
        {
            // Remove all user history records for the specified user
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.UserId == userId);
            if (user == null)
            {
                throw new Exception($"User with ID {userId} not found.");
            }

            _context.UserHistories.RemoveRange(_context.UserHistories.Where(uh => uh.UserId == userId));
            // Reset the user's begin and end times
            user.BeginQuizAt = DateTime.Now;

            await _context.SaveChangesAsync();
        }
        public async Task AddQuizHistoryAsync(UserHistory userHistory)
        {
            Console.WriteLine($"Adding quiz history: {userHistory.QuizId}, User ID: {userHistory.UserId}, User Answer ID: {userHistory.UserAnswerId}, Correct Answer ID: {userHistory.CorrectAnswerId}");
            // Check if the user history already exists
            var existingHistory = await _context.UserHistories
                .FirstOrDefaultAsync(uh => uh.UserId == userHistory.UserId && uh.QuizId == userHistory.QuizId);
            if (existingHistory == null){
                Console.WriteLine("No existing history found, adding new record.");
                await _context.UserHistories.AddAsync(userHistory);
            } else {
                // Update the existing history record
                Console.WriteLine("Existing history found, updating record.");
                existingHistory.UserAnswerId = userHistory.UserAnswerId;
                existingHistory.CorrectAnswerId = userHistory.CorrectAnswerId;
                existingHistory.QuizId = userHistory.QuizId;
                existingHistory.CreatedAt = DateTime.Now;
                _context.UserHistories.Update(existingHistory);
            }
            await _context.SaveChangesAsync();
        }  
        public async Task<List<UserHistory>> GetUserHistoryAsync(int userId)
        {
            var userHistory = await _context.UserHistories
                .Include(uh => uh.Quiz)
                .ThenInclude(q => q.Answers)
                .Include(uh => uh.UserAnswer)
                .Include(uh => uh.CorrectAnswer)
                .Where(uh => uh.UserId == userId)
                .OrderBy(uh => uh.CreatedAt)
                .ToListAsync();
            return userHistory;
        }
        public async Task<UserInSession?> GetUserByIdAsync(int userId)
        {
            var users = await _context.Users
                .FirstOrDefaultAsync(u => u.UserId == userId); // Assuming a user ID of 1 for testing purposes
            return users;
        }
        public async Task UpdateUserStatusAsync(UserInSession user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
        public async Task<UserInSession> CreateUserAsync(UserInSession user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}