using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Quiz.Models;

namespace Quiz.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the Quiz entity
            modelBuilder.Entity<UserHistory>()
                .HasKey(ih => new { ih.UserId, ih.QuizId });
            modelBuilder.Entity<UserHistory>()
                .HasOne(ih => ih.UserAnswer)
                .WithOne()
                .HasForeignKey<UserHistory>(ih => ih.UserAnswerId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<UserHistory>()
                .HasOne(ih => ih.CorrectAnswer)
                .WithOne()
                .HasForeignKey<UserHistory>(ih => ih.CorrectAnswerId)
                .OnDelete(DeleteBehavior.NoAction);
        }

        public DbSet<UserHistory> IncorrectHistories { get; set; } = null!;
        public DbSet<UserInSession> Users { get; set; } = null!;    
        public DbSet<Quiz.Models.Quiz> Quizzes { get; set; } = null!;
        public DbSet<Answer> Answers { get; set; } = null!;
    }
}