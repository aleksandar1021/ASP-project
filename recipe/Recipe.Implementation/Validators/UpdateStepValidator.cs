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
    public class UpdateStepValidator : BaseStepValidator<UpdateStepDTO>
    {
        public UpdateStepValidator(RecipeContext ctx) : base(ctx)
        {
            RuleFor(x => x.Id).NotEmpty()
                              .WithMessage("Step Id is required.")
                              .Must(x => ctx.Steps.Any(s => s.Id == x))
                              .WithMessage("Step Id not exist");
        }
    }
}
