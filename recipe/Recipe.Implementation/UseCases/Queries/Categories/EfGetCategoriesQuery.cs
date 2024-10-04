using Azure;
using Microsoft.EntityFrameworkCore;
using Recipe.Application.DTO;
using Recipe.Application.UseCases.Queries.Categories;
using Recipe.DataAccess;
using Recipe.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Implementation.UseCases.Queries.Categories
{
    public class EfGetCategoriesQuery : EfUseCase, IGetCategoriesQuery
    {
        public EfGetCategoriesQuery(RecipeContext context) : base(context)
        {
        }

        public int Id => 13;

        public string Name => "Search all categories by filter";

        public PagedResponse<CategoryResponseDTO> Execute(CategorySearchDTO data)
        {
            var query = Context.Categories.AsQueryable();

            if (data.WithChilds.HasValue)
            {
                if (data.WithChilds.Value)
                {
                    query = query.Where(c => c.Children.Any());
                }
                else
                {
                    query = query.Where(c => !c.Children.Any());
                }
            }

            if (data.ParentId.HasValue)
            {
                query = query.Where(x => x.ParentId == data.ParentId);
            }

            if (!string.IsNullOrEmpty(data.Name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(data.Name.ToLower())); ;
            }

            int totalCountOfLogs = query.Count();

            int perPage = data.PerPage.HasValue ? (int)Math.Abs((double)data.PerPage) : 5;
            int page = data.Page.HasValue ? (int)Math.Abs((double)data.Page) : 1;

            int skip = perPage * (page - 1);

            query = query.Skip(skip).Take(perPage);

            return new PagedResponse<CategoryResponseDTO>
            {
                Page = page,
                Data = query.Select(x => new CategoryResponseDTO
                {
                    Id = x.Id,
                    Name = x.Name,

                }).ToList(),

                PerPage = perPage,
                TotalCount = totalCountOfLogs,
            };
        }
    }
}
