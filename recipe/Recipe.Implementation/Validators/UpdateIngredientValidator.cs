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
    public class UpdateIngredientValidator : AbstractValidator<UpdateNamedDTO>
    {
        public UpdateIngredientValidator(RecipeContext ctx)
        {
            RuleFor(x => x.Id).NotEmpty()
                              .WithMessage("Ingredient Id is required.")
                              .Must(x => ctx.Ingredients.Any(i => i.Id == x))
                              .WithMessage("Ingredient not exist");

            RuleFor(x => x.Name).NotNull()
                               .WithMessage("Name of ingredient is required.")
                               .MinimumLength(3)
                               .WithMessage("Minimum number of characters is 3.")
                               .Must((dto, name) => !ctx.Ingredients.Any(c => c.Name == name && c.Id != dto.Id))
                               .WithMessage("Ingredient name must be unique.");
        }
    }
}
