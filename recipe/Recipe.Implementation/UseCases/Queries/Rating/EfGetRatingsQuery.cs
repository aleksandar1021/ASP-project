using Recipe.Application.DTO;
using Recipe.Application.UseCases.Queries.Rating;
using Recipe.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Implementation.UseCases.Queries.Rating
{
    public class EfGetRatingsQuery : EfUseCase, IGetRatingsQuery
    {
        public EfGetRatingsQuery(RecipeContext context) : base(context)
        {
        }

        public int Id => 46;

        public string Name => "Search ratings";

        public PagedResponse<ResponseRatingsDTO> Execute(SearchRatingsDTO data)
        {
            var query = Context.Ratings.AsQueryable();


            if (data.RatingValue.HasValue)
            {
                query = query.Where(x => x.RatingValue == data.RatingValue);
            }

            if (data.Id.HasValue)
            {
                query = query.Where(x => x.Id == data.Id);
            }

            int totalCountOfLogs = query.Count();
            int perPage = data.PerPage.HasValue ? (int)Math.Abs((double)data.PerPage) : 5;
            int page = data.Page.HasValue ? (int)Math.Abs((double)data.Page) : 1;
            int skip = perPage * (page - 1);

            query = query.Skip(skip).Take(perPage);

            return new PagedResponse<ResponseRatingsDTO>
            {
                Page = page,
                Data = query.Select(x => new ResponseRatingsDTO
                {
                    Id = x.Id,
                    RatingValue = x.RatingValue,
                }).ToList(),

                PerPage = perPage,
                TotalCount = totalCountOfLogs,
            };
        }
    }
}
