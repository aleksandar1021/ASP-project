using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Application.DTO
{
    public class CategoryResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class CategoryResponseWithChildrenDTO : CategoryResponseDTO
    {
        public IEnumerable<CategoryResponseWithChildrenDTO> Children { get; set; }
    }
}
