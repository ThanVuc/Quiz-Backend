using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz.DTOs
{
    public class UserHistoryResponse
    {
        public int UserAnswerId { get; set; }
        public QuizHistoryResponse? Quiz { get; set; }
        public int CorrectAnswerId { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class QuizHistoryResponse
    {
        public int QuizId { get; set; }
        public string Content { get; set; } = string.Empty;
        public List<string> Answers { get; set; } = new List<string>();
    }
}