using SquareQ.Quiz.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareQ.Quiz.Models
{
    [Table("SquareQAnswer")]
    public class Answer //при создании вопроса, должно быть сразу создано минимум 1 ответ
    {
        public int AnswerId { get; set; }
        public int QuestionID { get; set; }
        public Question Question { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
        [NotMapped]
        public bool IsChosen { get; set; }
    }
}
