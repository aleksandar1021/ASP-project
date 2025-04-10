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
    public class DeleteIngredientValidator : AbstractValidator<TableIdDTO>
    {
        public DeleteIngredientValidator(RecipeContext ctx)
        {
            RuleFor(x => x.Id).NotEmpty()
                              .WithMessage("Ingredient Id is required.")
                              .Must(x => ctx.Ingredients.Any(i => i.Id == x))
                              .WithMessage("Ingredient not exist.");
        }
    }
}
