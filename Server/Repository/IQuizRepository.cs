using System.Collections.Generic;
using SquareQ.Quiz.Models;

namespace SquareQ.Quiz.Repository
{
    public interface IQuizRepository
    {
        IEnumerable<Models.Quiz> GetQuizzes(int ModuleId);
        Models.Quiz GetQuiz(int QuizId);
        Models.Quiz AddQuiz(Models.Quiz Quiz);
        Models.Quiz UpdateQuiz(Models.Quiz Quiz);
        void DeleteQuiz(int QuizId);
    }
}
