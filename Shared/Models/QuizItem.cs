using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareQ.Quiz.Models
{
    [Table("SquareQQuizItem")]
    public class QuizItem //rename to question
    {
        public int QuizItemId { get; set; }
        public int ModuleId { get; set; }
        public string Question { get; set; }
        public string PicturePath { get; set; }
        public string Answers { get; set; }
        public string RightAnswer { get; set; }
        public string QuestionType { get; set; }
        public int QuizID { get; set; }
        public Quiz Quiz { get; set; }
    }
}
