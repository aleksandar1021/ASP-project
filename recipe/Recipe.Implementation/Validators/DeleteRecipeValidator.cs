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
    public class DeleteRecipeValidator : AbstractValidator<TableIdDTO>
    {
        private readonly IApplicationActor _actor;
        public DeleteRecipeValidator(RecipeContext ctx, IApplicationActor actor)
        {
            _actor = actor;


            RuleFor(x => x.Id).NotEmpty()
                              .WithMessage("Recipe Id id required.")
                              .Must(x => ctx.Recipes.Any(r => r.Id == x))
                              .WithMessage("recipe not exist.")
                              .Must(x => _actor.Id != x)
                              .WithMessage("You can delete only your recipe");
        }
    }
}
