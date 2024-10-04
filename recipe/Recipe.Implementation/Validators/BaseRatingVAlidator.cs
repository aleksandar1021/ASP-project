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
    public class BaseRatingValidator<T> : AbstractValidator<T> where T : RatingDTO
    {
        public BaseRatingValidator(RecipeContext ctx)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.RatingValue)
                        .NotEmpty()
                        .WithMessage("Rating value must be provided.")
                        .GreaterThanOrEqualTo(1)
                        .WithMessage("Rating value must be a positive number.")
                        .LessThanOrEqualTo(10)
                        .WithMessage("Rating value must be a number between 1 and 10.");
                       



        }
    }
}
