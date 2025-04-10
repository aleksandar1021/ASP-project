using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Recipe.Application;
using Recipe.Application.DTO;
using Recipe.Application.UseCases.Commands.Recipes;
using Recipe.DataAccess;
using Recipe.Domain;
using Recipe.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Implementation.UseCases.Commands.Recipes
{
    public class EfUpdateRecipeCommand : EfUseCase, IUpdateRecipeCommand
    {
        private UpdateRecipesValidator _validator;
        private IApplicationActor _actor;
        public EfUpdateRecipeCommand(RecipeContext context, UpdateRecipesValidator validator, IApplicationActor actor) : base(context)
        {
            _validator = validator;
            _actor = actor;
        }

        public int Id => 20;

        public string Name => "Update recipe";

        public void Execute(UpdateRecipeDTO data)
        {
            _validator.ValidateAndThrow(data);

            Domain.Recipes recipe = Context.Recipes
                                           .Include(x => x.Images)
                                           .FirstOrDefault(r => r.Id == data.Id);

            recipe.Title = data.Title;
            recipe.Description = data.Description;
            recipe.CategoryId = data.CategoryId;
            recipe.UserId = _actor.Id;
            recipe.UpdatedAt = DateTime.UtcNow;

  
            recipe.Steps = data.Steps.Select((s, index) => new Step
            {
                StepNumber = index + 1,
                Description = s.Description,
            }).ToList();

   
            recipe.RecipeIngredients = data.Ingredients.Select(i => new RecipeIngredient
            {
                IngredientId = i.Id,
                Quantity = i.Quantity
            }).ToList();

            var oldImages = recipe.Images.Select(i => i.Path).ToList();

      
            Context.Images.RemoveRange(recipe.Images);
            Context.SaveChanges();

     
            recipe.Images = data.Images.Select(i => new Image
            {
                Path = i
            }).ToList();

          
            foreach (var image in data.Images)
            {
                var tempImageName = Path.Combine("wwwroot", "temp", image);
                var destinationFileName = Path.Combine("wwwroot", "recipePhotos", image);
                System.IO.File.Move(tempImageName, destinationFileName);
            }

       
            Context.SaveChanges();

        
            foreach (var oldImage in oldImages)
            {
                var oldImagePath = Path.Combine("wwwroot", "recipePhotos", oldImage);
                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }
            }

        }
    }
}
