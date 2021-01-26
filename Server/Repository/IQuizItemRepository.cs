using System.Collections.Generic;
using SquareQ.Quiz.Models;

namespace SquareQ.Quiz.Repository
{
    public interface IQuizItemRepository
    {
        IEnumerable<QuizItem> GetQuizItems(int QuizID);
        QuizItem GetQuizItem(int QuizItemId);
        QuizItem AddQuizItem(QuizItem QuizItem);
        QuizItem UpdateQuizItem(QuizItem QuizItem);
        void DeleteQuizItem(int QuizItemId);
    }
}
