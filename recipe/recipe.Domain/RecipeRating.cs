using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Domain
{
    public class RecipeRating : Entity
    {
        public int RecipeId { get; set; }
        public int RatingId { get; set; }

        public int UserId { get; set; }
        public virtual Rating Rating { get; set; }
        public virtual Recipes Recipe { get; set; }
        public virtual User User { get; set; }
    }
}
