using SquareQ.Quiz.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareQ.Quiz.Shared.Models
{
    [Table("SquareQQuestionType")]
    public class QuestionType
    {
        public int ItemTypeId { get; set; }
        public int QuizItemID { get; set; }
        public QuizItem QuizItem { get; set; }
        public string TypeName { get; set; }
        public string Description { get; set; }
        public int SecondsForPicture { get; set; } //seconds to show picture
    }
}
