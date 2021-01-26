using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Oqtane.Modules;
using Oqtane.Repository;
using SquareQ.Quiz.Models;

namespace SquareQ.Quiz.Repository
{
    public class QuizContext : DBContextBase, IService
    {
        public virtual DbSet<Models.Quiz> Quizzes { get; set; }
        public virtual DbSet<QuizItem> QuizItems { get; set; }

        public QuizContext(ITenantResolver tenantResolver, IHttpContextAccessor accessor) : base(tenantResolver, accessor)
        {
            // ContextBase handles multi-tenant database connections
        }
    }
}
