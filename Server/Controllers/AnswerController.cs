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
    public class AnswerController : Controller
    {
        private readonly IAnswerRepository _AnswerRepository;
        private readonly ILogManager _logger;

        public AnswerController(IAnswerRepository answerRepository, ILogManager logger)
        {
            _AnswerRepository = answerRepository;
            _logger = logger;
        }

        // GET api/<controller>/
        [HttpGet]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public IEnumerable<Answer> GetAnswers(string QuestionID)
        {
            return _AnswerRepository.GetAnswers(int.Parse(QuestionID));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public Answer GetAnswer(int id)
        {
            return _AnswerRepository.GetAnswer(id);
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize(Policy = PolicyNames.EditModule)]
        public Answer PostAnswer([FromBody] Answer Answer)
        {
            Answer = _AnswerRepository.AddAnswer(Answer);
            _logger.Log(LogLevel.Information, this, LogFunction.Create, "Answer Added {Answer}", Answer);

            return Answer;
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public Answer PutAnswer(int id, [FromBody] Answer Answer)
        {
            Answer = _AnswerRepository.UpdateAnswer(Answer);
            _logger.Log(LogLevel.Information, this, LogFunction.Update, "Answer Updated {Answer}", Answer);

            return Answer;
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public void DeleteAnswer(int id)
        {
            Answer Answer = _AnswerRepository.GetAnswer(id);
            if (Answer != null)
            {
                _AnswerRepository.DeleteAnswer(id);
                _logger.Log(LogLevel.Information, this, LogFunction.Delete, "Answer Deleted {AnswerId}", id);
            }
        }
    }
}
