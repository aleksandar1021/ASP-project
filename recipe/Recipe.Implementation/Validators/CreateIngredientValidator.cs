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
    public class CreateIngredientValidator : AbstractValidator<NamedDTO>
    {
        public CreateIngredientValidator(RecipeContext ctx)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.Name).NotEmpty()
                                .WithMessage("Ingrdient name is required.")
                                .Must(x => !ctx.Ingredients.Any(i => i.Name == x))
                                .WithMessage("Ingredient name must be unique");
        }
    }
}
