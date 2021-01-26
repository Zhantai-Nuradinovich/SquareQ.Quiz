using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Oqtane.Modules;
using SquareQ.Quiz.Models;

namespace SquareQ.Quiz.Repository
{
    public class QuizItemRepository : IQuizItemRepository, IService
    {
        private readonly QuizContext _db;

        public QuizItemRepository(QuizContext context)
        {
            _db = context;
        }

        public IEnumerable<QuizItem> GetQuizItems(int QuizID)
        {
            return _db.QuizItems.Where(item => item.QuizID == QuizID);
        }

        public QuizItem GetQuizItem(int QuizItemId)
        {
            return _db.QuizItems.Find(QuizItemId);
        }

        public QuizItem AddQuizItem(QuizItem QuizItem)
        {
            _db.QuizItems.Add(QuizItem);
            _db.SaveChanges();
            return QuizItem;
        }

        public QuizItem UpdateQuizItem(QuizItem QuizItem)
        {
            _db.Entry(QuizItem).State = EntityState.Modified;
            _db.SaveChanges();
            return QuizItem;
        }

        public void DeleteQuizItem(int QuizItemId)
        {
            QuizItem QuizItem = _db.QuizItems.Find(QuizItemId);
            _db.QuizItems.Remove(QuizItem);
            _db.SaveChanges();
        }
    }
}
