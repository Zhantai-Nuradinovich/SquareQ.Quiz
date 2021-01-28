using System.Collections.Generic;
using SquareQ.Quiz.Models;

namespace SquareQ.Quiz.Repository
{
    public interface IQuestionRepository
    {
        IEnumerable<Question> GetQuestions(int QuizID);
        Question GetQuestion(int QuestionId);
        Question AddQuestion(Question Question);
        Question UpdateQuestion(Question Question);
        void DeleteQuestion(int QuestionId);
    }
}
