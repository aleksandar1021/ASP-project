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
    public class BaseStepValidator<T> : AbstractValidator<T> where T : CreateStepDTO
    {
        public BaseStepValidator(RecipeContext ctx)
        {
            RuleFor(x => x.RecipeId).NotEmpty()
                                    .WithMessage("Recipe Id is required.")
                                    .Must(x => ctx.Recipes.Any(r => r.Id == x))
                                    .WithMessage("Recipe not exist.");

            RuleFor(x => x.Description).NotEmpty()
                                    .WithMessage("Description is required.")
                                    .Must(x => x.Length < 250)
                                    .WithMessage("Maximum length is 250.");
        }
    }
}
