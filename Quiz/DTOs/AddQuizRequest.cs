using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz.DTOs
{
    public class AddQuizRequest
    {
        public string Content { get; set; } = string.Empty;
        public List<AddAnswerRequest> Answers { get; set; } = new List<AddAnswerRequest>();
        public string FeedBack { get; set; } = string.Empty;
    }

    public class AddAnswerRequest
    {
        public string Content { get; set; } = string.Empty;
        public bool IsCorrect { get; set; }
    }
}