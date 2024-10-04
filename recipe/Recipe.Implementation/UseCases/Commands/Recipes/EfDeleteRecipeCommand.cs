using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Recipe.API.Core;
using Recipe.Application.DTO;
using Recipe.Application.UseCases.Commands.Recipes;
using Recipe.DataAccess;
using Recipe.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Implementation.UseCases.Commands.Recipes
{
    public class EfDeleteRecipeCommand : EfUseCase, IDeleteRecipeCommand
    {
        DeleteRecipeValidator _validator;
        public EfDeleteRecipeCommand(RecipeContext context, DeleteRecipeValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 21;

        public string Name => "Delete recipe";

        public void Execute(TableIdDTO data)
        {
            var recipe = Context.Recipes.Include(r => r.Comments)
                                                    .Include(r => r.Images)
                                                    .Include(r => r.RecipeRatings)
                                                    .Include(r => r.Steps)
                                                    .Include(r => r.RecipeIngredients)
                                                    .Include(r => r.Comments)
                                                    .FirstOrDefault(r => r.Id == data.Id);

            if(recipe == null)
            {
                throw new NotFoundException();
            }

           

            _validator.ValidateAndThrow(data);

            var recipeComments = recipe.Comments;
            var recipeImages = recipe.Images;
            var recipeRatings = recipe.RecipeRatings;
            var recipeSteps = recipe.Steps;
            var recipeIngradients = recipe.RecipeIngredients;

            Context.Comments.RemoveRange(recipeComments);
            Context.Images.RemoveRange(recipeImages);
            Context.RecipeRatings.RemoveRange(recipeRatings);
            Context.Steps.RemoveRange(recipeSteps);
            Context.RecipeIngredients.RemoveRange(recipeIngradients);

            foreach (var oldImage in recipe.Images)
            {
                var oldImagePath = Path.Combine("wwwroot", "recipePhotos", oldImage.Path);
                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }
            }

            Context.Recipes.Remove(recipe);

            Context.SaveChanges();
        }
    }
}
