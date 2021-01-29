using System.Collections.Generic;
using System.Threading.Tasks;
using SquareQ.Quiz.Models;

namespace SquareQ.Quiz.Services 
{
    public interface IAnswerService
    {
        Task<List<Answer>> GetAnswersAsync(int QuestionID);

        Task<Answer> GetAnswerAsync(int AnswerId, int QuestionID);

        Task<Answer> AddAnswerAsync(Answer Answer);

        Task<Answer> UpdateAnswerAsync(Answer Answer);

        Task DeleteAnswerAsync(int AnswerId, int QuestionID);
    }
}
