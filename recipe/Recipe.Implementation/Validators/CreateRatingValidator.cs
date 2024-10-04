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
    public class CreateRatingValidator : BaseRatingValidator<RatingDTO>
    {
        public CreateRatingValidator(RecipeContext ctx) : base(ctx)
        {
            RuleFor(x => x.RatingValue)
                        .Must(x => !ctx.Ratings.Any(r => r.RatingValue == x))
                        .WithMessage("Rating value must be unique");
        }
    }
}
