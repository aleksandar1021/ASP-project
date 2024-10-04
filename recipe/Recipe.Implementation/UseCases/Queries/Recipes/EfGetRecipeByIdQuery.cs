using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Recipe.Application.DTO;
using Recipe.Application.UseCases.Queries.Recipes;
using Recipe.DataAccess;
using Recipe.Domain;
using Recipe.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Implementation.UseCases.Queries.Recipes
{
    public class EfGetRecipeByIdQuery : EfUseCase, IGetRecipeByIdQuery
    {
        private SearchRecipeByIdValidator _validator;
        public EfGetRecipeByIdQuery(RecipeContext context, SearchRecipeByIdValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 23;

        public string Name => "Search recipe by id";



        public RecipeResponseWithCommentsById Execute(TableIdDTO data)
        {
            _validator.ValidateAndThrow(data);

            var recipe = Context.Recipes
                                  .Include(r => r.Comments)
                                  .ThenInclude(x => x.Children)
                                  .Include(x => x.Category)
                                  .Include(r => r.Images)
                                  .Include(r => r.RecipeRatings).ThenInclude(r => r.Rating)
                                  .Include(r => r.Steps)
                                  .Include(r => r.RecipeIngredients)
                                  .ThenInclude(x => x.Ingredient)
                                  .FirstOrDefault(r => r.Id == data.Id);

           



            var response = new RecipeResponseWithCommentsById
            {
                Id = recipe.Id,
                UserId = recipe.UserId,
                CategoryId = recipe.CategoryId,
                Title = recipe.Title,
                Description = recipe.Description,
                Images = recipe.Images?.Select(i => i.Path).ToList() ?? new List<string>(),
                RecipeRatings = recipe.RecipeRatings.Select(rr => new RecipeRatingsDTO
                {
                   UserId = rr.UserId,
                   RatingId = rr.RatingId,
                   Rating = rr.Rating.RatingValue
                }).ToList() ?? new List<RecipeRatingsDTO>(),
                RecipeIngredients = recipe.RecipeIngredients?.Select(ri => new ResponseIngredientDTO
                {
                    Id = ri.Id,
                    Ingredient = ri.Ingredient.Name,
                    Quantity = ri.Quantity
                }).ToList() ,
                Steps = recipe.Steps?.Select(s => new StepResponseDTO
                {
                    StepNumber = s.StepNumber,
                    Description = s.Description
                }).ToList() ?? new List<StepResponseDTO>(),
                Comments = GetCommentsWithChildren(recipe.Comments?.Where(c => c.ParentId == null).ToList() ?? new List<Comment>())
            };

            return response;
        }

        private List<ResponseCommentDTO> GetCommentsWithChildren(List<Comment> comments)
        {
            var result = new List<ResponseCommentDTO>();

            foreach (var comment in comments)
            {
                var commentWithChildren = new ResponseCommentDTO
                {
                    Id = comment.Id,
                    Text = comment.Text,
                    UserId = comment.UserId,
                    ParentId = comment.ParentId,
                    Childrens = GetCommentsWithChildren(comment.Children?.ToList() ?? new List<Comment>())
                };

                result.Add(commentWithChildren);
            }

            return result;
        }
    }
}