using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Domain
{
    public class Step : Entity
    {
        public int RecipeId { get; set; }
        public int StepNumber { get; set; }
        public string Description { get; set; }

        public virtual Recipes Recipe { get; set; }
    }
}
