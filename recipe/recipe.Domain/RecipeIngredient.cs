using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Domain
{
    public class RecipeIngredient : Entity
    {
        public int IngredientId { get; set; }
        public int RecipeId { get; set; }
        public string Quantity { get; set; }

        public virtual Ingredient Ingredient { get; set; }
        public virtual Recipes Recipe { get; set; }
    }
}
