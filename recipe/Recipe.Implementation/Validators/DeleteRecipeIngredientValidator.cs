using FluentValidation;
using Recipe.Application;
using Recipe.Application.DTO;
using Recipe.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Implementation.Validators
{
    public class DeleteRecipeIngredientValidator :AbstractValidator<TableIdDTO>
    {
       
        public DeleteRecipeIngredientValidator(RecipeContext ctx, IApplicationActor actor)
        {
            RuleFor(x => x.Id).NotEmpty()
                              .WithMessage("Id is required")
                              .Must(x => ctx.RecipeIngredients.Any(ri => ri.Id == x))
                              .WithMessage("Ingredient for recipe not exist.")
                              .Must((dto, id) => dto.Id != actor.Id)
                              .WithMessage("You cannot change the ingredients for recipe to others users.");
        }
    }
}
