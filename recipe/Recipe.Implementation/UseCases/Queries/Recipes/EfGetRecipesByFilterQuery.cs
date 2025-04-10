using Microsoft.EntityFrameworkCore;
using Recipe.Application.DTO;
using Recipe.Application.UseCases.Queries.Recipes;
using Recipe.DataAccess;
using Recipe.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Implementation.UseCases.Queries.Recipes
{
    public class EfGetRecipesByFilterQuery : EfUseCase, IGetRecipesByFilterQuery
    {
        public EfGetRecipesByFilterQuery(RecipeContext context) : base(context)
        {
        }

        public int Id => 22;

        public string Name => "Search recipes by filters";

        public PagedResponse<RecipeResponse> Execute(RecipeSearchDTO data)
        {
            var query = Context.Recipes.Include(r => r.Comments)
                                                    .Include(r => r.Images)
                                                    .Include(r => r.RecipeRatings)
                                                    .Include(r => r.Steps)
                                                    .Include(r => r.RecipeIngredients)
                                                    .ThenInclude(x => x.Ingredient)
                                                    .AsQueryable();


            if (data.Id.HasValue)
            {
                query = query.Where(r => r.Id == data.Id.Value);
            }

            if (data.UserId.HasValue)
            {
                query = query.Where(r => r.UserId == data.UserId.Value);
            }

            if (data.CategoryId.HasValue)
            {
                query = query.Where(r => r.CategoryId == data.CategoryId.Value);
            }

            if (!string.IsNullOrEmpty(data.Title))
            {
                query = query.Where(u => u.Title.ToLower().Contains(data.Title.ToLower()));
            }

           

            int totalCountOfLogs = query.Count();

            int perPage = data.PerPage.HasValue ? (int)Math.Abs((double)data.PerPage) : 5;
            int page = data.Page.HasValue ? (int)Math.Abs((double)data.Page) : 1;

            int skip = perPage * (page - 1);

            query = query.Skip(skip).Take(perPage);

            return new PagedResponse<RecipeResponse>
            {
                Page = page,
                Data = query.Select(x => new RecipeResponse
                {
                    Id = x.Id,
                    UserId = x.User.Id,
                    CategoryId = x.CategoryId,
                    Title = x.Title,
                    Description = x.Description,
                    Images = x.Images.Select(i => i.Path).ToArray(),
                    RecipeIngredients = x.RecipeIngredients.Select(ri => new ResponseIngredientDTO
                    {
                        Id = ri.Id,
                        Ingredient = ri.Ingredient.Name,
                        Quantity = ri.Quantity
                    }).ToList(),
                    RecipeRatings = x.RecipeRatings
                                     .Select(r => new RecipeRatingsDTO
                                     {
                                         UserId = r.UserId,
                                         RatingId = r.RatingId,
                                         Rating = r.Rating.RatingValue
                                     }).ToList(),
                    Steps = x.Steps.Select(s => new StepResponseDTO
                    {
                        StepNumber = s.StepNumber,
                        Description = s.Description
                    }).ToList()
                    
                }).ToList(),

                PerPage = perPage,
                TotalCount = totalCountOfLogs,
            };
        }
    }
}
