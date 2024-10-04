using Recipe.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Application.UseCases.Queries.Ingredients
{
    public interface IGetIngredientsQuery : IQuery<PagedResponse<NamedResponseDTO>, NamedSearchDTO>
    {
    }
}
