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
    public class QuizService : ServiceBase, IQuizService, IService
    {
        private readonly SiteState _siteState;

        public QuizService(HttpClient http, SiteState siteState) : base(http)
        {
            _siteState = siteState;
        }

        private string Apiurl => CreateApiUrl(_siteState.Alias, "Quiz");

        public async Task<List<Models.Quiz>> GetQuizzesAsync(int ModuleId)
        {
            List<Models.Quiz> Quizs = await GetJsonAsync<List<Models.Quiz>>(CreateAuthorizationPolicyUrl($"{Apiurl}?moduleid={ModuleId}", ModuleId));
            return Quizs.OrderBy(item => item.Name).ToList();
        }

        public async Task<Models.Quiz> GetQuizAsync(int QuizId, int ModuleId)
        {
            return await GetJsonAsync<Models.Quiz>(CreateAuthorizationPolicyUrl($"{Apiurl}/{QuizId}", ModuleId));
        }

        public async Task<Models.Quiz> AddQuizAsync(Models.Quiz Quiz)
        {
            return await PostJsonAsync<Models.Quiz>(CreateAuthorizationPolicyUrl($"{Apiurl}", Quiz.ModuleId), Quiz);
        }

        public async Task<Models.Quiz> UpdateQuizAsync(Models.Quiz Quiz)
        {
            return await PutJsonAsync<Models.Quiz>(CreateAuthorizationPolicyUrl($"{Apiurl}/{Quiz.QuizId}", Quiz.ModuleId), Quiz);
        }

        public async Task DeleteQuizAsync(int QuizId, int ModuleId)
        {
            await DeleteAsync(CreateAuthorizationPolicyUrl($"{Apiurl}/{QuizId}", ModuleId));
        }
    }
}
