using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Application.DTO
{
    public class CreateRecipeRatingsDTO
    {
        public int RecipeId { get; set; }
        public int RatingId { get; set; }
        public int UserId { get; set; }
    }

    public class UpdateRecipeRatingsDTO : CreateRecipeIngredientDTO
    {
        public int Id { get; set; }
        
    }


    public class ResponseRecipeRatingsDTO : CreateRecipeRatingsDTO
    {
        public int Id { get; set; }
        public UserResponseDTO User {  get; set; }
    }

    public class UserResponseDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Image { get; set; }

    }

    public class SearchRecipeRatingsDTO : PagedSearch
    {
        public int? Id { get; set; }
        public int? RecipeId { get; set; }
        public int? RatingId { get; set; }
        public int? UserId { get; set; }
    }
}
