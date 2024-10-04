using Recipe.Application.DTO;
using Recipe.Application.UseCases.Queries.Ingredients;
using Recipe.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Implementation.UseCases.Queries.Ingredients
{
    public class EfGetIngredientsQuery : EfUseCase,IGetIngredientsQuery
    {
        public EfGetIngredientsQuery(RecipeContext context) : base(context)
        {
        }

        public int Id => 18;

        public string Name => "Search ingredients";

        public PagedResponse<NamedResponseDTO> Execute(NamedSearchDTO data)
        {
            var query = Context.Ingredients.AsQueryable();


            if (!string.IsNullOrEmpty(data.Name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(data.Name.ToLower()));
            }

            

            int totalCountOfLogs = query.Count();
            int perPage = data.PerPage.HasValue ? (int)Math.Abs((double)data.PerPage) : 5;
            int page = data.Page.HasValue ? (int)Math.Abs((double)data.Page) : 1;
            int skip = perPage * (page - 1);

            query = query.Skip(skip).Take(perPage);

            return new PagedResponse<NamedResponseDTO>
            {
                Page = page,
                Data = query.Select(x => new NamedResponseDTO
                {
                    Name = x.Name,
                }).ToList(),

                PerPage = perPage,
                TotalCount = totalCountOfLogs,
            };
        }
    }
}
