using Recipe.Application.DTO;
using Recipe.Application.UseCases.Queries.Users;
using Recipe.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Implementation.UseCases.Queries.Users
{
    public class EfGetUserUseCasesQuery : EfUseCase, IGetUserUseCasesQuery
    {
        public EfGetUserUseCasesQuery(RecipeContext context) : base(context)
        {
        }

        public int Id => 43;

        public string Name => "Search user use cases";

        public PagedResponse<UserUseCasesDTO> Execute(SearchUserUseCasesDTO data)
        {
            var query = Context.UserUseCases.AsQueryable();


            if (data.UserId.HasValue)
            {
                query = query.Where(u => u.UserId == data.UserId.Value);
            }

            if (data.UseCaseId.HasValue)
            {
                query = query.Where(u => u.UseCaseId == data.UseCaseId.Value);
            }

           
            int totalCountOfLogs = query.Count();

            int perPage = data.PerPage.HasValue ? (int)Math.Abs((double)data.PerPage) : 5;
            int page = data.Page.HasValue ? (int)Math.Abs((double)data.Page) : 1;

            int skip = perPage * (page - 1);

            query = query.Skip(skip).Take(perPage);

            return new PagedResponse<UserUseCasesDTO>
            {
                Page = page,
                Data = query.Select(x => new UserUseCasesDTO
                {
                    UserId = x.UserId,
                    UseCaseId = x.UseCaseId
                    
                }).ToList(),

                PerPage = perPage,
                TotalCount = totalCountOfLogs,
            };
        }
    }
}
