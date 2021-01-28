using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Oqtane.Modules;
using SquareQ.Quiz.Models;

namespace SquareQ.Quiz.Repository
{
    public class AnswerRepository : IAnswerRepository, IService
    {
        private readonly QuizContext _db;

        public AnswerRepository(QuizContext context)
        {
            _db = context;
        }

        public IEnumerable<Answer> GetAnswers(int QuestionID)
        {
            return _db.Answers.Where(item => item.QuestionID == QuestionID);
        }

        public Answer GetAnswer(int AnswerId)
        {
            return _db.Answers.Find(AnswerId);
        }

        public Answer AddAnswer(Answer Answer)
        {
            _db.Answers.Add(Answer);
            _db.SaveChanges();
            return Answer;
        }

        public Answer UpdateAnswer(Answer Answer)
        {
            _db.Entry(Answer).State = EntityState.Modified;
            _db.SaveChanges();
            return Answer;
        }

        public void DeleteAnswer(int AnswerId)
        {
            Answer Answer = _db.Answers.Find(AnswerId);
            _db.Answers.Remove(Answer);
            _db.SaveChanges();
        }
    }
}
