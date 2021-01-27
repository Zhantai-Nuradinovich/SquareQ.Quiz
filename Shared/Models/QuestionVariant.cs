using SquareQ.Quiz.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareQ.Quiz.Shared.Models
{
    [Table("SquareQQuestionVariant")]
    public class QuestionVariant //при создании вопроса, должно быть сразу создано минимум 1 ответ
    {
        public int QuestionVariantId { get; set; }
        public int QuizItemID { get; set; }
        public QuizItem QuizItem { get; set; }
        public string Answer { get; set; }
        public bool IsCorrect { get; set; }
        [NotMapped]
        public bool IsChosen { get; set; }
    }
}
