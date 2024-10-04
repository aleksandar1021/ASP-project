using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Domain
{
    public class Image : Entity
    {
        public int RecipeId { get; set; }
        public string Path { get; set; }

        public virtual Recipes Recipe {  get; set; }
    }
}
