using Recipe.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Application.DTO
{
    public class CreateRecipeIngredientDTO 
    {
        public int RecipeId { get; set; }
        public int IngredientId { get; set; }
    }

    public class UpdateRecipeIngredientDTO : CreateRecipeIngredientDTO
    {
        public int Id { get; set; }
    }

    public class SearchRecipeIngredientsDTO : PagedSearch
    {
        public int? Id { get; set; }
        public int? IngredientId { get; set; }
        public int? RecipeId { get; set; }
        public string Quantity { get; set; }
    }

    public class ResponseRecipeIngredientsDTO
    {
        public int Id { get; set; }
        public ResponseIngredientDTO Ingredient { get; set; }
        public int RecipeId { get; set; }
        
    }

    public class ResponseIngredientDTO
    {
        public int Id { get; set; }
        public string Ingredient { get; set; }
        public string Quantity { get; set; }
    }
}
