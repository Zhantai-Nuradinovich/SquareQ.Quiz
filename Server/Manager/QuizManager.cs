using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Oqtane.Modules;
using Oqtane.Models;
using Oqtane.Infrastructure;
using Oqtane.Repository;
using SquareQ.Quiz.Models;
using SquareQ.Quiz.Repository;

namespace SquareQ.Quiz.Manager
{
    public class QuizManager : IInstallable, IPortable
    {
        private IQuizRepository _QuizRepository;
        private ISqlRepository _sql;

        public QuizManager(IQuizRepository QuizRepository, ISqlRepository sql)
        {
            _QuizRepository = QuizRepository;
            _sql = sql;
        }

        public bool Install(Tenant tenant, string version)
        {
            return _sql.ExecuteScript(tenant, GetType().Assembly, "SquareQ.Quiz." + version + ".sql");
        }

        public bool Uninstall(Tenant tenant)
        {
            return _sql.ExecuteScript(tenant, GetType().Assembly, "SquareQ.Quiz.Uninstall.sql");
        }

        public string ExportModule(Module module)
        {
            string content = "";
            List<Models.Quiz> Quizs = _QuizRepository.GetQuizzes(module.ModuleId).ToList();
            if (Quizs != null)
            {
                content = JsonSerializer.Serialize(Quizs);
            }
            return content;
        }

        public void ImportModule(Module module, string content, string version)
        {
            List<Models.Quiz> Quizs = null;
            if (!string.IsNullOrEmpty(content))
            {
                Quizs = JsonSerializer.Deserialize<List<Models.Quiz>>(content);
            }
            if (Quizs != null)
            {
                foreach(var Quiz in Quizs)
                {
                    _QuizRepository.AddQuiz(new Models.Quiz { ModuleId = module.ModuleId, Name = Quiz.Name });
                }
            }
        }
    }
}