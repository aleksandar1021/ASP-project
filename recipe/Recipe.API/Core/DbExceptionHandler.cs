using Recipe.Application;
using Recipe.DataAccess;
using Recipe.Domain;

namespace Recipe.API.Core
{
    public class DbExceptionHandler : IExceptionLogger
    {
        private readonly RecipeContext _aspContext;
        public DbExceptionHandler(RecipeContext aspContext)
        {
            _aspContext = aspContext;
        }

        public Guid Log(Exception ex, IApplicationActor actor)
        {
            Guid id = Guid.NewGuid();
            ErrorLog log = new()
            {
                Id = id,
                Message = ex.Message,
                Time = DateTime.UtcNow,
                StrackTrace = ex.StackTrace
            };
            _aspContext.ErrorLogs.Add(log);
            _aspContext.SaveChanges();
            return id;
        }
    }
}
