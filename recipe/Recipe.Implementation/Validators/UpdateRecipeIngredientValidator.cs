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
    public class UpdateRecipeIngredientValidator : BaseRecipeIngredientValidator<UpdateRecipeIngredientDTO>
    {
        public UpdateRecipeIngredientValidator(RecipeContext ctx) : base(ctx)
        {
            RuleFor(x => x.Id).NotEmpty()
                              .WithMessage("Id is required.")
                              .Must(x => ctx.RecipeIngredients.Any(ri => ri.Id == x))
                              .WithMessage("Recipe ingredient not exist.");
        }
    }
}
