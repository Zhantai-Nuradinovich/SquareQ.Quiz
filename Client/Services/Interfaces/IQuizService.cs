using System.Collections.Generic;
using System.Threading.Tasks;
using SquareQ.Quiz.Models;

namespace SquareQ.Quiz.Services
{
    public interface IQuizService 
    {
        Task<List<Models.Quiz>> GetQuizzesAsync(int ModuleId);

        Task<Models.Quiz> GetQuizAsync(int QuizId, int ModuleId);

        Task<Models.Quiz> AddQuizAsync(Models.Quiz Quiz);

        Task<Models.Quiz> UpdateQuizAsync(Models.Quiz Quiz);

        Task DeleteQuizAsync(int QuizId, int ModuleId);
    }
}
