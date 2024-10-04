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
    public class CreateRecipeIngredientValidator : BaseRecipeIngredientValidator<CreateRecipeIngredientDTO>
    {
        public CreateRecipeIngredientValidator(RecipeContext ctx) : base(ctx)
        {
        }
    }
}
