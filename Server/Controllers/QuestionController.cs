using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Oqtane.Shared;
using Oqtane.Enums;
using Oqtane.Infrastructure;
using SquareQ.Quiz.Models;
using SquareQ.Quiz.Repository;

namespace SquareQ.Quiz.Controllers
{
    [Route(ControllerRoutes.Default)]
    public class QuestionController : Controller
    {
        private readonly IQuestionRepository _QuestionRepository;
        private readonly ILogManager _logger;
        protected int _entityId = -1;

        public QuestionController(IQuestionRepository questionRepository, ILogManager logger, IHttpContextAccessor accessor)
        {
            _QuestionRepository = questionRepository;
            _logger = logger;

            if (accessor.HttpContext.Request.Query.ContainsKey("entityid"))
            {
                _entityId = int.Parse(accessor.HttpContext.Request.Query["entityid"]);
            }
        }

        // GET api/<controller>/
        [HttpGet]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public IEnumerable<Question> GetQuestions(string QuizID)
        {
            return _QuestionRepository.GetQuestions(int.Parse(QuizID));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public Question GetQuestion(int id)
        {
            return _QuestionRepository.GetQuestion(id);
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize(Policy = PolicyNames.EditModule)]
        public Question PostQuestion([FromBody] Question Question)
        {
            Question = _QuestionRepository.AddQuestion(Question);
            _logger.Log(LogLevel.Information, this, LogFunction.Create, "Question Added {Question}", Question);

            return Question;
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public Question PutQuestion(int id, [FromBody] Question Question)
        {
            Question = _QuestionRepository.UpdateQuestion(Question);
            _logger.Log(LogLevel.Information, this, LogFunction.Update, "QuizItem Updated {QuizItem}", Question);

            return Question;
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public void DeleteQuestion(int id)
        {
            Question Question = _QuestionRepository.GetQuestion(id);
            if (Question != null)
            {
                _QuestionRepository.DeleteQuestion(id);
                _logger.Log(LogLevel.Information, this, LogFunction.Delete, "QuizItem Deleted {QuizItemId}", id);
            }
        }
    }
}
