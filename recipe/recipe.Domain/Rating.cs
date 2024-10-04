using Recipe.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Domain
{
    public class Rating : Entity
    {
        public int RatingValue { get; set; }

        public virtual ICollection<RecipeRating> RecipeRatings { get; set; } = new HashSet<RecipeRating>();
    }
}
