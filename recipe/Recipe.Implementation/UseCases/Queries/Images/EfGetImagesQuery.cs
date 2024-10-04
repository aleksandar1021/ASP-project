using Recipe.Application.DTO;
using Recipe.Application.UseCases.Queries.Images;
using Recipe.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Implementation.UseCases.Queries.Images
{
    public class EfGetImagesQuery : EfUseCase, IGetImagesQuery
    {
        public EfGetImagesQuery(RecipeContext context) : base(context)
        {
        }

        public int Id => 47;

        public string Name => "Search images";

        public PagedResponse<ResponseImagesDTO> Execute(SearchImagesDTO data)
        {
            var query = Context.Images.AsQueryable();


            if (data.Id.HasValue)
            {
                query = query.Where(x => x.Id == data.Id);
            }

            if (data.RecipeId.HasValue)
            {
                query = query.Where(x => x.RecipeId == data.RecipeId);
            }

            if (!string.IsNullOrEmpty(data.Path))
            {
                query = query.Where(x => x.Path.ToLower().Contains(data.Path.ToLower()));
            }



            int totalCountOfLogs = query.Count();
            int perPage = data.PerPage.HasValue ? (int)Math.Abs((double)data.PerPage) : 5;
            int page = data.Page.HasValue ? (int)Math.Abs((double)data.Page) : 1;
            int skip = perPage * (page - 1);

            query = query.Skip(skip).Take(perPage);

            return new PagedResponse<ResponseImagesDTO>
            {
                Page = page,
                Data = query.Select(x => new ResponseImagesDTO
                {
                    Id = x.Id,
                    RecipeId = x.RecipeId,
                    Path = x.Path
                }).ToList(),

                PerPage = perPage,
                TotalCount = totalCountOfLogs,
            };
        }
    }
}
