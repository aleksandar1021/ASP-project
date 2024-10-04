using FluentValidation;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using Recipe.Application;
using Recipe.Application.DTO;
using Recipe.Application.UseCases.Commands.Recipes;
using Recipe.DataAccess;
using Recipe.Domain;
using Recipe.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Implementation.UseCases.Commands.Recipes
{
    public class EfCreateRecipesCommand : EfUseCase, ICreateRecipesCommand
    {
        private CreateRecipesValidator _validator;
        private IApplicationActor _actor;
        public EfCreateRecipesCommand(RecipeContext context, CreateRecipesValidator validator, IApplicationActor actor) : base(context)
        {
            _validator = validator;
            _actor = actor;
        }

        public int Id => 19;

        public string Name => "Create recipe";

        public void Execute(RecipeDTO data)
        {
            _validator.ValidateAndThrow(data);

            Domain.Recipes recipe = new Domain.Recipes();

            recipe.Title = data.Title;
            recipe.Description = data.Description;
            recipe.CategoryId = data.CategoryId;
            recipe.UserId = _actor.Id;


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

            Context.Recipes.Add(recipe);

            Context.SaveChanges();
        }
    }
}
