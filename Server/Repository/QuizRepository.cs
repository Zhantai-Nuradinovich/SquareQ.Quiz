using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Oqtane.Modules;
using SquareQ.Quiz.Models;

namespace SquareQ.Quiz.Repository
{
    public class QuizRepository : IQuizRepository, IService
    {
        private readonly QuizContext _db;

        public QuizRepository(QuizContext context)
        {
            _db = context;
        }

        public IEnumerable<Models.Quiz> GetQuizzes(int ModuleId)
        {
            return _db.Quizzes.Where(item => item.ModuleId == ModuleId);
        }

        public Models.Quiz GetQuiz(int QuizId)
        {
            return _db.Quizzes.First(t => t.QuizId == QuizId);
        }

        public Models.Quiz AddQuiz(Models.Quiz Quiz)
        {
            _db.Quizzes.Add(Quiz);
            _db.SaveChanges();
            return Quiz;
        }

        public Models.Quiz UpdateQuiz(Models.Quiz Quiz)
        {
            _db.Entry(Quiz).State = EntityState.Modified;
            _db.SaveChanges();
            return Quiz;
        }

        public void DeleteQuiz(int QuizId)
        {
            Models.Quiz Quiz = _db.Quizzes.Find(QuizId);
            _db.Quizzes.Remove(Quiz);
            _db.SaveChanges();
        }
    }
}
