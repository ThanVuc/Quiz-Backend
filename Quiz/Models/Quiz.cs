using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz.Models
{
    public class Quiz
    {
        public int QuizId { get; set; }
        public string Content { get; set; } = string.Empty;
        public List<Answer> Answers { get; set; } = new List<Answer>();
        public string FeedBack { get; set; } = string.Empty;
    }
}