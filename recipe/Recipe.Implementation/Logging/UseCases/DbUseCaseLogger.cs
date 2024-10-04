using Recipe.Application;
using Recipe.Domain;
using Recipe.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Recipe.Implementation.Logging.UseCases
{
    public class DbUseCaseLogger : IUseCaseLogger
    {
        private RecipeContext ctx;

        public DbUseCaseLogger(RecipeContext ctx)
        {
            this.ctx = ctx;
        }

        public void Log(Application.UseCaseLog log)
        {
            Domain.UseCaseLog newLog = new Domain.UseCaseLog
            {
                UseCaseName = log.UseCaseName,
                Username = log.Username,
                UseCaseData = JsonConvert.SerializeObject(log.UseCaseData),
                ExecutedAt = DateTime.UtcNow
            };

            ctx.UseCaseLogs.Add(newLog);
            ctx.SaveChanges();
        }
    }
}
