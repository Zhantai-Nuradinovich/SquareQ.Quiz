using SquareQ.Quiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareQ.Quiz.Repository
{
    public interface IAnswerRepository
    {
        IEnumerable<Answer> GetAnswers(int QuestionID);
        Answer GetAnswer(int AnswerId);
        Answer AddAnswer(Answer Answer);
        Answer UpdateAnswer(Answer Answer);
        void DeleteAnswer(int AnswerId);
    }
}
