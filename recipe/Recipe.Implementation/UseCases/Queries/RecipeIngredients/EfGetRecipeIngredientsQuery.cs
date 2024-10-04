using Microsoft.EntityFrameworkCore;
using Recipe.Application.DTO;
using Recipe.Application.UseCases.Queries.RecipeIngredients;
using Recipe.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Implementation.UseCases.Queries.RecipeIngredients
{
    public class EfGetRecipeIngredientsQuery : EfUseCase, IGetRecipeIngredientsQuery
    {
        public EfGetRecipeIngredientsQuery(RecipeContext context) : base(context)
        {
        }

        public int Id => 49;

        public string Name => "Search ingredients for recipes";

        public PagedResponse<ResponseRecipeIngredientsDTO> Execute(SearchRecipeIngredientsDTO data)
        {
            var query = Context.RecipeIngredients.Include(x => x.Ingredient).AsQueryable();

            if (data.Id.HasValue)
            {
                query = query.Where(x => x.Id == data.Id);
            }

            if (data.IngredientId.HasValue)
            {
                query = query.Where(x => x.IngredientId == data.IngredientId);
            }


            if (data.RecipeId.HasValue)
            {
                query = query.Where(x => x.RecipeId == data.RecipeId);
            }

            if (!string.IsNullOrEmpty(data.Quantity))
            {
                query = query.Where(x => x.Quantity.ToLower().Contains(data.Quantity.ToLower()));
            }


            int totalCountOfLogs = query.Count();
            int perPage = data.PerPage.HasValue ? (int)Math.Abs((double)data.PerPage) : 5;
            int page = data.Page.HasValue ? (int)Math.Abs((double)data.Page) : 1;
            int skip = perPage * (page - 1);

            query = query.Skip(skip).Take(perPage);

            return new PagedResponse<ResponseRecipeIngredientsDTO>
            {
                Page = page,
                Data = query.Select(x => new ResponseRecipeIngredientsDTO
                {
                    Id = x.Id,
                    RecipeId = x.RecipeId,
                    Ingredient = new ResponseIngredientDTO
                                {
                                    Id = x.Ingredient.Id,
                                    Ingredient = x.Ingredient.Name,
                                    Quantity = x.Quantity,
                                },
                }).ToList(),

                PerPage = perPage,
                TotalCount = totalCountOfLogs,
            };
        }
    }
}
