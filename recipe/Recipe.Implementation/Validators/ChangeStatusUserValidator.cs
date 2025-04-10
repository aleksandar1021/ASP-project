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
    public class ChangeStatusUserValidator : AbstractValidator<TableIdDTO>
    {
        public ChangeStatusUserValidator(RecipeContext ctx)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Id).NotEmpty()
                                  .WithMessage("User Id is required.")
                                  .Must(x => ctx.Users.Any(u => u.Id == x))
                                  .WithMessage("User not exist.");
                                  
        }
    }
}
