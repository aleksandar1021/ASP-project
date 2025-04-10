using Recipe.Application.DTO;
using Recipe.Application.UseCases.Queries.Steps;
using Recipe.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Implementation.UseCases.Queries.Steps
{
    public class EfGetStepsQuery : EfUseCase, IGetStepsQuery
    {
        public EfGetStepsQuery(RecipeContext context) : base(context)
        {
        }

        public int Id => 43;

        public string Name => "Search steps";

        public PagedResponse<ResponseStepDTO> Execute(SearchStepDTO data)
        {
            var query = Context.Steps.AsQueryable();

            if (data.Id.HasValue)
            {
                query = query.Where(x => x.Id == data.Id);
            }

            if (data.RecipeId.HasValue)
            {
                query = query.Where(x => x.RecipeId == data.RecipeId);
            }


            if (data.StepNumber.HasValue)
            {
                query = query.Where(x => x.StepNumber == data.StepNumber);
            }


            if (!string.IsNullOrEmpty(data.Description))
            {
                query = query.Where(x => x.Description.ToLower().Contains(data.Description.ToLower()));
            }



            int totalCountOfLogs = query.Count();
            int perPage = data.PerPage.HasValue ? (int)Math.Abs((double)data.PerPage) : 5;
            int page = data.Page.HasValue ? (int)Math.Abs((double)data.Page) : 1;
            int skip = perPage * (page - 1);

            query = query.Skip(skip).Take(perPage);

            return new PagedResponse<ResponseStepDTO>
            {
                Page = page,
                Data = query.Select(x => new ResponseStepDTO
                {
                    Id = x.Id,
                    RecipeId = x.RecipeId,
                    StepNumber = x.StepNumber,
                    Description = x.Description
                }).ToList(),

                PerPage = perPage,
                TotalCount = totalCountOfLogs,
            };
        }
    }
}
