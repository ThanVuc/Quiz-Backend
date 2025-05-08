using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz.DTOs
{
    public class StatisticResponse
    {
        public TimeSpan TimeForQuiz { get; set; }
        public int CorrectAnswers { get; set; }
        public int WrongAnswers { get; set; }
        public int TotalAnswers { get; set; }
        public bool IsPassed { get; set; }
    }
}