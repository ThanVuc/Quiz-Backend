using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz.Models
{
    public class UserHistory
    {
        // take care of the situation when the user is wrong 2 times in the same quiz
        [ForeignKey("User")]
        public int UserId { get; set; }
        [ForeignKey("Quiz")]
        public int QuizId { get; set; }
        [ForeignKey("UserAnswer")]
        public int UserAnswerId { get; set; }
        [ForeignKey("CorrectAnswer")]
        public int CorrectAnswerId { get; set; }
        public UserInSession? User { get; set; }
        public Quiz? Quiz { get; set; }
        public Answer? UserAnswer { get; set; }
        public Answer? CorrectAnswer { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    }
}