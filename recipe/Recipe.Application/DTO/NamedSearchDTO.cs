using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Application.DTO
{
    public class NamedSearchDTO : PagedSearch
    {
        public string Name { get; set; }
    }

    public class NamedResponseDTO : NamedSearchDTO
    {
        public int Id { get; set; }
    }
}
