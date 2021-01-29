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
    public class QuestionService : ServiceBase, IQuestionService, IService
    {
        private readonly SiteState _siteState;

        public QuestionService(HttpClient http, SiteState siteState) : base(http)
        {
            _siteState = siteState;
        }

        private string Apiurl => CreateApiUrl(_siteState.Alias, "Question");

        public async Task<List<Question>> GetQuestionsAsync(int QuizID)
        {
            List<Question> Questions = await GetJsonAsync<List<Question>>(CreateAuthorizationPolicyUrl($"{Apiurl}?quizid={QuizID}", QuizID));
            return Questions.ToList();
        }

        public async Task<Question> GetQuestionAsync(int QuestionId, int QuizID)
        {
            return await GetJsonAsync<Question>(CreateAuthorizationPolicyUrl($"{Apiurl}/{QuestionId}", QuizID));
        }

        public async Task<Question> AddQuestionAsync(Question Question)
        {
            return await PostJsonAsync<Question>(CreateAuthorizationPolicyUrl($"{Apiurl}", Question.QuizID), Question);
        }

        public async Task<Question> UpdateQuestionAsync(Question Question) 
        {
            return await PutJsonAsync<Question>(CreateAuthorizationPolicyUrl($"{Apiurl}/{Question.QuestionId}", Question.QuizID), Question);
        }

        public async Task DeleteQuestionAsync(int QuestionId, int QuizID)
        {
            await DeleteAsync(CreateAuthorizationPolicyUrl($"{Apiurl}/{QuestionId}", QuizID));
        }
    }
}
