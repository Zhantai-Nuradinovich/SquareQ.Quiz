using Oqtane.Models;
using Oqtane.Modules;

namespace SquareQ.Quiz
{
    public class ModuleInfo : IModule
    {
        public ModuleDefinition ModuleDefinition => new ModuleDefinition
        {
            Name = "Quiz",
            Description = "Quiz",
            Version = "1.0.0",
            ServerManagerType = "SquareQ.Quiz.Manager.QuizManager, SquareQ.Quiz.Server.Oqtane",
            ReleaseVersions = "1.0.0",
            Dependencies = "SquareQ.Quiz.Shared.Oqtane"
        };
    }
}
