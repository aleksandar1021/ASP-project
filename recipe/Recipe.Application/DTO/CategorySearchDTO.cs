using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Application.DTO
{
    public class CategorySearchDTO : PagedSearch
    {
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public bool? WithChilds { get; set; }
    }

    public class CategorySearchByIdDTO : PagedSearch
    {
        public int Id { get; set; }
    }
}
