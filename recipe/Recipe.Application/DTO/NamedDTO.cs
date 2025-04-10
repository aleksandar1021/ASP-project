using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Application.DTO
{
    public class NamedDTO
    {
        public string Name { get; set; }
    }

    public class UpdateNamedDTO : NamedDTO
    {
        public int Id { get; set; }
    }

    public class SearchNamedDTO : PagedSearch
    {
        public int? Id { get; set; }
        public string Name { get; set; }
    }

    public class ResponseNamedDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
