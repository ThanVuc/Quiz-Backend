using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz.Models
{
    public class UserInSession
    {
        [Key]
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime LastActiveAt { get; set; } = DateTime.UtcNow;
        public List<UserHistory>? IncorrectHistories { get; set; }
        public DateTime BeginQuizAt { get; set; } = DateTime.Now;
        public DateTime EndQuizAt { get; set; } = DateTime.Now;
    }
}