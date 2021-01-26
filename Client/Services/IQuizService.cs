using System.Collections.Generic;
using System.Threading.Tasks;
using SquareQ.Quiz.Models;

namespace SquareQ.Quiz.Services
{
    public interface IQuizService 
    {
        Task<List<Models.Quiz>> GetQuizzesAsync(int ModuleId);

        Task<List<QuizItem>> GetQuizItemsAsync(int ModuleId, int QuizID);

        Task<Models.Quiz> GetQuizAsync(int QuizId, int ModuleId);

        Task<QuizItem> GetQuestionAsync(int QuizItemId, int ModuleId);

        Task<Models.Quiz> AddQuizAsync(Models.Quiz Quiz);

        Task<QuizItem> AddQuestionAsync(QuizItem QuizItem);

        Task<Models.Quiz> UpdateQuizAsync(Models.Quiz Quiz);

        Task<QuizItem> UpdateQuestionAsync(QuizItem QuizItem);

        Task DeleteQuizAsync(int QuizId, int ModuleId);

        Task DeleteQuestionAsync(int QuizItemId, int ModuleId);
    }
}
