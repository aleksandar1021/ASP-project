using Recipe.Application.DTO;
using Recipe.Application.UseCases.Queries.Follows;
using Recipe.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Implementation.UseCases.Queries.Follows
{
    public class EfGetFollowsQuery : EfUseCase, IGetFollowsQuery
    {
        public EfGetFollowsQuery(RecipeContext context) : base(context)
        {
        }

        public int Id => 48;

        public string Name => "Search follows";

        public PagedResponse<ResponseFollowsDTO> Execute(SearchFollowsDTO data)
        {
            var query = Context.Follows.AsQueryable();


            if (data.Id.HasValue)
            {
                query = query.Where(x => x.Id == data.Id);
            }

            if (data.UserId.HasValue)
            {
                query = query.Where(x => x.UserId == data.UserId);
            }

            if (data.FollowedId.HasValue)
            {
                query = query.Where(x => x.FollowId == data.FollowedId);
            }

            int totalCountOfLogs = query.Count();
            int perPage = data.PerPage.HasValue ? (int)Math.Abs((double)data.PerPage) : 5;
            int page = data.Page.HasValue ? (int)Math.Abs((double)data.Page) : 1;
            int skip = perPage * (page - 1);

            query = query.Skip(skip).Take(perPage);

            return new PagedResponse<ResponseFollowsDTO>
            {
                Page = page,
                Data = query.Select(x => new ResponseFollowsDTO
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    FollowedId = x.FollowId
                }).ToList(),

                PerPage = perPage,
                TotalCount = totalCountOfLogs,
            };
        }
    }
}
