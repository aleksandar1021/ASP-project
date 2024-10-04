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
    public class CreateRecipeRatingsValidator : AbstractValidator<CreateRecipeRatingsDTO>
    {
        public CreateRecipeRatingsValidator(RecipeContext ctx)
        {
            RuleFor(x => x.RecipeId).NotEmpty()
                                    .WithMessage("Recipe Id is required.")
                                    .Must(x => ctx.Recipes.Any(r => r.Id == x))
                                    .WithMessage("Recipe not exist");

            RuleFor(x => x.RatingId).NotEmpty()
                                    .WithMessage("Rating Id is required.")
                                    .Must(x => ctx.Ratings.Any(r => r.Id == x))
                                    .WithMessage("Rating not exist");

            RuleFor(x => x.UserId).NotEmpty()
                                    .WithMessage("User Id is required.")
                                    .Must(x => ctx.Users.Any(r => r.Id == x))
                                    .WithMessage("User not exist")
                                    .Must((dto, x) => !ctx.RecipeRatings.Any(rr => rr.UserId == x && rr.RecipeId == dto.RecipeId))
                                    .WithMessage("You can rate one recipe only once");
        }
    }
}
