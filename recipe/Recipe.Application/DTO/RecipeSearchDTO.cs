using Recipe.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Application.DTO
{
    public class RecipeSearchDTO : PagedSearch
    {
        public int? Id { get; set; }
        public int? UserId { get; set; }
        public int? CategoryId { get; set; }
        public string Title { get; set; }
    }

    public class RecipeResponse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public  ICollection<string> Images { get; set; } 
        public  ICollection<RecipeRatingsDTO> RecipeRatings { get; set; }
        public  ICollection<ResponseIngredientDTO> RecipeIngredients { get; set; }
        public  ICollection<StepResponseDTO> Steps { get; set; }
    }

    public class RecipeResponseWithCommentsById : RecipeResponse
    {
        public ICollection<ResponseCommentDTO> Comments { get; set; }
    }

    public class ResponseCommentDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }
        public int? ParentId { get; set; }
        public ICollection<ResponseCommentDTO> Childrens { get; set; }
    }

    public class ResponseCommentWithoutChildsDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }
        public int? ParentId { get; set; }
        public int RecipeId { get; set; }
    }

    public class SearchCommentsDTO : PagedSearch
    {
        public int? Id { get; set; }
        public int? ParentId { get; set; }
        public  string Text { get; set; }
        public int? UserId { get; set; }
        public int? RecipeId { get; set; }
    }

    public class CommentResponsWithChildren : ResponseCommentDTO
    {
        public ICollection<CommentResponsWithChildren> Childrens;
    }

    public class CommentResponsWithChildrenForComments 
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }
        public int? ParentId { get; set; }
        public int RecipeId { get; set; }

        public IEnumerable<CommentResponsWithChildrenForComments> Childrens { get; set; }

    }

    public class StepResponseDTO 
    {
        public int StepNumber { get; set; }
        public string Description { get; set; }
    }

    public class RecipeRatingsDTO
    {
        public int UserId { get; set; }
        public int RatingId { get; set; }
        public int Rating { get; set; }
    }

}
