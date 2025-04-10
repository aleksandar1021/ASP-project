using Recipe.API.Core;
using Recipe.Application.DTO;
using Recipe.Application.UseCases.Queries.ErrorLogs;
using Recipe.DataAccess;
using Recipe.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Implementation.UseCases.Queries.ErrorLogs
{
    public class EfGetErrorLogsByIdQuery : EfUseCase, IGetErrorLogsQuery
    {
        public EfGetErrorLogsByIdQuery(RecipeContext context) : base(context)
        {
        }

        public int Id => 52;

        public string Name => "Search error logs by id";

        public ResponseErrorLogDTO Execute(string data)
        {
            ErrorLog errorLog = Context.ErrorLogs.FirstOrDefault(x => data.ToLower() == x.Id.ToString().ToLower());

            if (errorLog == null)
            {
                throw new NotFoundException();
            }

            return new ResponseErrorLogDTO
            {
                Id = errorLog.Id,
                Message = errorLog.Message,
                StrackTrace = errorLog.StrackTrace,
                Time = errorLog.Time
            };

        }
    }
    
}
