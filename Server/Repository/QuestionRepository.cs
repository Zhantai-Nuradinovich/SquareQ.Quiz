using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Oqtane.Modules;
using SquareQ.Quiz.Models;

namespace SquareQ.Quiz.Repository
{
    public class QuestionRepository : IQuestionRepository, IService
    {
        private readonly QuizContext _db;

        public QuestionRepository(QuizContext context)
        {
            _db = context;
        }

        public IEnumerable<Question> GetQuestions(int QuizID)
        {
            return _db.Questions.Where(item => item.QuizID == QuizID);
        }

        public Question GetQuestion(int QuestionId)
        {
            return _db.Questions.Find(QuestionId);
        }

        public Question AddQuestion(Question Question)
        {
            _db.Questions.Add(Question);
            _db.SaveChanges();
            return Question;
        }

        public Question UpdateQuestion(Question Question)
        {
            _db.Entry(Question).State = EntityState.Modified;
            _db.SaveChanges();
            return Question;
        }

        public void DeleteQuestion(int QuestionId)
        {
            Question Question = _db.Questions.Find(QuestionId);
            _db.Questions.Remove(Question);
            _db.SaveChanges();
        }
    }
}
