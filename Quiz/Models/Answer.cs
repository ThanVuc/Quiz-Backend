using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz.Models
{
    public class Answer
    {
        [Key]
        public int AnswerId { get; set; }
        public string Content { get; set; } = string.Empty;
        public bool IsCorrect { get; set; } = false;
        [ForeignKey("Quiz")]
        public int QuizId { get; set; }
        public Quiz? Quiz { get; set; }
    }
}