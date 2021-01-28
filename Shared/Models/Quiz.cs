using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Oqtane.Models;

namespace SquareQ.Quiz.Models
{
    [Table("SquareQQuiz")]
    public class Quiz : IAuditable
    {
        public int QuizId { get; set; }
        public int ModuleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
