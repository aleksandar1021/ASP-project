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
    public class UpdateUserUseCaseAccessValidator : AbstractValidator<UpdateUserUseCaseDTO>
    {
        private static int userUseCaseIdForUpdate = 2;
        public UpdateUserUseCaseAccessValidator(RecipeContext ctx)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.UseCaseIds)
                  .NotEmpty().WithMessage("Use case ids is required.")
                  .Must(x => x.All(id => id > 0 && id <= UseCaseInfo.MaxUseCaseId))
                  .WithMessage("Use case id is not in range.")
                  .Must(x => x.Distinct().Count() == x.Count())
                  .WithMessage("Only unique id's are accepted.");

            RuleFor(x => x.UserId)
                  .Must(x => ctx.Users.Any(u => u.Id == x && u.IsActive))
                  .WithMessage("The requested user does not exist or is not active.")
                  .Must(x => ctx.UserUseCases.Any(u => u.UseCaseId == userUseCaseIdForUpdate && u.UserId == x))
                  .WithMessage("You do not have permission to modify user use cases.");
 
        }
    }
}
