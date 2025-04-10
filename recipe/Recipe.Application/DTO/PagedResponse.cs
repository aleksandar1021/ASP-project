using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Application.DTO
{
    public class PagedResponse<T>
        where T : class
    {
        public IEnumerable<T> Data { get; set; }
        public int PerPage { get; set; }
        public int TotalCount { get; set; }
        public int Pages
        {
            get
            {
                return (int)Math.Ceiling((double)TotalCount / PerPage);
            }
        }
        public int Page { get; set; }
    }
}
