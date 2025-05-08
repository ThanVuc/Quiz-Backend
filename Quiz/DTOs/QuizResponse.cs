using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz.DTOs
{
    public class QuizResponse
    {
        public int QuizId { get; set; }
        public string Content { get; set; } = string.Empty;
        public List<AnswerResponse> Answers { get; set; } = new List<AnswerResponse>();
    }

    public class AnswerResponse
    {
        public int AnswerId { get; set; }
        public string Content { get; set; } = string.Empty;
        public bool IsCorrect { get; set; }
    }
}