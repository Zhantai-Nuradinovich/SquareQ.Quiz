using System.Collections.Generic;
using System.Threading.Tasks;
using SquareQ.Quiz.Models;

namespace SquareQ.Quiz.Services
{
    public interface IQuestionService
    {
        Task<List<Question>> GetQuestionsAsync(int QuizID);

        Task<Question> GetQuestionAsync(int QuestionId);

        Task<Question> AddQuestionAsync(Question Question);

        Task<Question> UpdateQuestionAsync(Question Question);

        Task DeleteQuestionAsync(int QuestionId);
    }
}
