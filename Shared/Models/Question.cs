using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareQ.Quiz.Models
{
    [Table("SquareQQuestion")]
    public class Question //rename to question
    {
        public int QuestionId { get; set; }
        public string Text { get; set; }
        public string PicturePath { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public string QuestionType { get; set; }
        public int SecondsforPicture { get; set; } //to close picture
        public int QuizID { get; set; }
        public Quiz Quiz { get; set; }
    }
}
