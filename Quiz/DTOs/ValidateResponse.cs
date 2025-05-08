using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz.DTOs
{
    public class ValidateResponse
    {
        public string FeedBack { get; set; } = string.Empty;
        public bool IsCorrect { get; set; } = false;
        public int CorrectAnswerId { get; set; } = 0;
    }
}