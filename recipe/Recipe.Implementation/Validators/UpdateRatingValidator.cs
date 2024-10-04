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
    public class UpdateRatingValidator : BaseRatingValidator<UpdateRatingDTO>
    {
        public UpdateRatingValidator(RecipeContext ctx) : base(ctx)
        {
            RuleFor(x => x.RatingValue).Must((dto, x) => !ctx.Ratings.Any(r => r.RatingValue == x && r.Id != dto.Id))
                                        .WithMessage("Rating value must be unique.");
        }
    }
}
