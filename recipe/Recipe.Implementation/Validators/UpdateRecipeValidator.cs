using FluentValidation;
using Microsoft.Identity.Client.Extensibility;
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
    public class UpdateRecipesValidator : BaseRecipeValidator<UpdateRecipeDTO>
    {
        protected readonly IApplicationActor _actor;
        public UpdateRecipesValidator(RecipeContext ctx, IApplicationActor actor) : base(ctx)
        {
            _actor = actor;

            RuleFor(x => x.Id).NotEmpty()
                              .WithMessage("Id is required.")
                              .Must(id => ctx.Recipes.Any(r => r.Id == id))
                              .WithMessage("Recipe not exist.")
                              .Must(x => x != actor.Id)
                              .WithMessage("You can only edit your recipe");
        }
    }
}
