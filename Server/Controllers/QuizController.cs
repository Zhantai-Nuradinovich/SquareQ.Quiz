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
    public class QuizController : Controller
    {
        private readonly IQuizRepository _QuizRepository;
        private readonly ILogManager _logger;
        protected int _entityId = -1;

        public QuizController(IQuizRepository QuizRepository, ILogManager logger, IHttpContextAccessor accessor)
        {
            _QuizRepository = QuizRepository;
            _logger = logger;

            if (accessor.HttpContext.Request.Query.ContainsKey("entityid"))
            {
                _entityId = int.Parse(accessor.HttpContext.Request.Query["entityid"]);
            }
        }

        // GET: api/<controller>?moduleid=x
        [HttpGet]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public IEnumerable<Models.Quiz> Get(string moduleid)
        {
            return _QuizRepository.GetQuizzes(int.Parse(moduleid));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public Models.Quiz Get(int id)
        {
            Models.Quiz Quiz = _QuizRepository.GetQuiz(id);
            if (Quiz != null && Quiz.ModuleId != _entityId)
            {
                Quiz = null;
            }
            return Quiz;
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize(Policy = PolicyNames.EditModule)]
        public Models.Quiz Post([FromBody] Models.Quiz Quiz)
        {
            if (ModelState.IsValid && Quiz.ModuleId == _entityId)
            {
                Quiz = _QuizRepository.AddQuiz(Quiz);
                _logger.Log(LogLevel.Information, this, LogFunction.Create, "Quiz Added {Quiz}", Quiz);
            }
            return Quiz;
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public Models.Quiz Put(int id, [FromBody] Models.Quiz Quiz)
        {
            if (ModelState.IsValid && Quiz.ModuleId == _entityId)
            {
                Quiz = _QuizRepository.UpdateQuiz(Quiz);
                _logger.Log(LogLevel.Information, this, LogFunction.Update, "Quiz Updated {Quiz}", Quiz);
            }
            return Quiz;
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public void Delete(int id)
        {
            Models.Quiz Quiz = _QuizRepository.GetQuiz(id);
            if (Quiz != null && Quiz.ModuleId == _entityId)
            {
                _QuizRepository.DeleteQuiz(id);
                _logger.Log(LogLevel.Information, this, LogFunction.Delete, "Quiz Deleted {QuizId}", id);
            }
        }
    }
}
