using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Application.DTO
{
    public class RatingDTO
    {
        public int RatingValue { get; set; }
    }

    public class UpdateRatingDTO : RatingDTO
    {
        public int Id { get; set; }
    }
}
