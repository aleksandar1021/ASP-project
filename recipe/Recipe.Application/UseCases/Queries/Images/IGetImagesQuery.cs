using Recipe.Application.DTO;
using Recipe.Application.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Application.UseCases.Queries.Images
{
    public interface IGetImagesQuery : IQuery<PagedResponse<ResponseImagesDTO>, SearchImagesDTO>
    {
    }
}
