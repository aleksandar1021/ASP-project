using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Application.DTO
{
    public class SearchRatingsDTO : PagedSearch
    {
        public int? Id { get; set; }
        public int? RatingValue { get; set; }
    }


    public class ResponseRatingsDTO
    {
        public int Id { get; set; }
        public int RatingValue { get; set; }
    }
}
