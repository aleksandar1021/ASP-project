using FluentValidation;
using Recipe.Application.DTO;
using Recipe.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Implementation.Validators
{
    public class BaseRecipeIngredientValidator<T> : AbstractValidator<T> where T : CreateRecipeIngredientDTO
    {
        public BaseRecipeIngredientValidator(RecipeContext ctx)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.RecipeId).NotEmpty()
                                    .WithMessage("Recipe Id is required.")
                                    .Must(x => ctx.Recipes.Any(r => r.Id == x))
                                    .WithMessage("Recipe not exist.");

            RuleFor(x => x.IngredientId).NotEmpty()
                                    .WithMessage("Ingredient Id is required.")
                                    .Must(x => ctx.Ingredients.Any(r => r.Id == x))
                                    .WithMessage("Ingredient not exist.");
        }
    }
}
