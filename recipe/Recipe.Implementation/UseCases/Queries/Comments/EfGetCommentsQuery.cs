using Recipe.Application.DTO;
using Recipe.Application.UseCases.Queries.Comments;
using Recipe.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Recipe.Implementation.UseCases.Queries.Comments
{
    public class EfGetCommentsQuery : EfUseCase, IGetCommentsQuery
    {
        public EfGetCommentsQuery(RecipeContext context) : base(context)
        {
        }

        public int Id => 50;

        public string Name => "Search comments by filters";

        public PagedResponse<ResponseCommentWithoutChildsDTO> Execute(SearchCommentsDTO data)
        {
            var query = Context.Comments.AsQueryable();


            if (data.Id.HasValue)
            {
                query = query.Where(x => x.Id == data.Id);
            }

            if (data.ParentId.HasValue)
            {
                query = query.Where(x => x.ParentId == data.ParentId);
            }

            if (data.RecipeId.HasValue)
            {
                query = query.Where(x => x.RecipeId == data.RecipeId);
            }

            if (data.UserId.HasValue)
            {
                query = query.Where(x => x.UserId == data.UserId);
            }


            int totalCountOfLogs = query.Count();
            int perPage = data.PerPage.HasValue ? (int)Math.Abs((double)data.PerPage) : 5;
            int page = data.Page.HasValue ? (int)Math.Abs((double)data.Page) : 1;
            int skip = perPage * (page - 1);

            query = query.Skip(skip).Take(perPage);

            return new PagedResponse<ResponseCommentWithoutChildsDTO>
            {
                Page = page,
                Data = query.Select(x => new ResponseCommentWithoutChildsDTO
                {
                    Id = x.Id,
                    ParentId = x.ParentId,
                    Text = x.Text,
                    UserId = x.UserId,
                    RecipeId = x.RecipeId
                }).ToList(),

                PerPage = perPage,
                TotalCount = totalCountOfLogs,
            };
        }
    }
}
