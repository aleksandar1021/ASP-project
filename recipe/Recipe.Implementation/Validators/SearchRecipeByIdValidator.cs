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
    public class SearchRecipeByIdValidator : AbstractValidator<TableIdDTO>
    {
        public SearchRecipeByIdValidator(RecipeContext ctx)
        {
            RuleFor(x => x.Id).Must(x => ctx.Recipes.Any(c => c.Id == x))
                              .WithMessage("Recipe not exist.");
        }
    }
}
