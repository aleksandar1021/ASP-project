using FluentValidation;
using Recipe.Application.DTO;
using Recipe.Application.UseCases.Commands.RecipeIngredients;
using Recipe.DataAccess;
using Recipe.Domain;
using Recipe.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Implementation.UseCases.Commands.RecipeIngredients
{
    public class EfUpdateRecipeIngredientsCommand : EfUseCase, IUpdateRecipeIngredientCommand
    {
        UpdateRecipeIngredientValidator _validator;
        public EfUpdateRecipeIngredientsCommand(RecipeContext context, UpdateRecipeIngredientValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 25;

        public string Name => "Update recipes ingredients";

        public void Execute(UpdateRecipeIngredientDTO data)
        {
            _validator.ValidateAndThrow(data);

            RecipeIngredient ri = Context.RecipeIngredients.Find(data.Id);

            ri.IngredientId = data.IngredientId;
            ri.RecipeId = data.RecipeId;
            ri.UpdatedAt = DateTime.UtcNow;

            Context.SaveChanges();
        }
    }
}
