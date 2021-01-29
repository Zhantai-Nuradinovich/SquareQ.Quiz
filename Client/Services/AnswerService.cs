using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Oqtane.Modules;
using Oqtane.Services;
using Oqtane.Shared;
using SquareQ.Quiz.Models;

namespace SquareQ.Quiz.Services
{
    public class AnswerService : ServiceBase, IAnswerService, IService
    {
        private readonly SiteState _siteState;

        public AnswerService(HttpClient http, SiteState siteState) : base(http)
        {
            _siteState = siteState;
        }

        private string Apiurl => CreateApiUrl(_siteState.Alias, "Answer");

        public async Task<List<Answer>> GetAnswersAsync(int QuestionID)
        {
            List<Answer> Answers = await GetJsonAsync<List<Answer>>(CreateAuthorizationPolicyUrl($"{Apiurl}/?questionid={QuestionID}", QuestionID));
            return Answers.ToList();
        }

        public async Task<Answer> GetAnswerAsync(int AnswerId, int QuestionID)
        {
            return await GetJsonAsync<Answer>(CreateAuthorizationPolicyUrl($"{Apiurl}/{AnswerId}", QuestionID));
        }

        public async Task<Answer> AddAnswerAsync(Answer Answer) 
        {
            return await PostJsonAsync<Answer>(CreateAuthorizationPolicyUrl($"{Apiurl}", Answer.QuestionID), Answer);
        }

        public async Task<Answer> UpdateAnswerAsync(Answer Answer)
        {
            return await PutJsonAsync<Answer>(CreateAuthorizationPolicyUrl($"{Apiurl}/{Answer.AnswerId}", Answer.QuestionID), Answer);
        }

        public async Task DeleteAnswerAsync(int AnswerId, int QuestionID)
        {
            await DeleteAsync(CreateAuthorizationPolicyUrl($"{Apiurl}/{AnswerId}", QuestionID));
        }
    }
}
