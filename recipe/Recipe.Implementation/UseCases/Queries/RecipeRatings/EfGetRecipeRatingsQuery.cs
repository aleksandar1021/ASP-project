using Microsoft.EntityFrameworkCore;
using Recipe.Application.DTO;
using Recipe.Application.UseCases;
using Recipe.Application.UseCases.Queries.RecipeRatings;
using Recipe.Application.UseCases.Queries.Users;
using Recipe.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Implementation.UseCases.Queries.RecipeRatings
{
    public class EfGetRecipeRatingsQuery : EfUseCase, IGetRecipeRatingsQuery
    {
        public EfGetRecipeRatingsQuery(RecipeContext context) : base(context)
        {
        }

        public int Id => 45;

        public string Name => "Search ratings for recipes";

        public PagedResponse<ResponseRecipeRatingsDTO> Execute(SearchRecipeRatingsDTO data)
        {
            var query = Context.RecipeRatings.Include(x => x.User).AsQueryable();

            if (data.Id.HasValue)
            {
                query = query.Where(x => x.Id == data.Id);
            }

            if (data.RecipeId.HasValue)
            {
                query = query.Where(x => x.RecipeId == data.RecipeId);
            }


            if (data.RatingId.HasValue)
            {
                query = query.Where(x => x.RatingId == data.RatingId);
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

            return new PagedResponse<ResponseRecipeRatingsDTO>
            {
                Page = page,
                Data = query.Select(x => new ResponseRecipeRatingsDTO
                {
                    Id = x.Id,
                    RecipeId = x.RecipeId,
                    UserId = x.UserId,
                    RatingId = x.RatingId,
                    User = new UserResponseDTO
                    {
                        Id = x.User.Id,
                        Username = x.User.Username,
                        Image = x.User.Image
                    }
                }).ToList(),

                PerPage = perPage,
                TotalCount = totalCountOfLogs,
            };
        }
    }
}
