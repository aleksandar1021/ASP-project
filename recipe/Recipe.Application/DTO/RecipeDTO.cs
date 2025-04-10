using Recipe.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Application.DTO
{
    public class RecipeDTO
    {
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public virtual IEnumerable<string> Images { get; set; } 
        public virtual IEnumerable<IngredientsDTO> Ingredients { get; set; } 
        public virtual IEnumerable<Step> Steps { get; set; } 
    }

    public class IngredientsDTO
    {
        public int Id { get; set;}
        public string Quantity { get; set; }
    }

    public class UpdateRecipeDTO : RecipeDTO 
    {
        public int Id { get; set; }
    }

}
