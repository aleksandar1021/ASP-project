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
    public class BaseFollowValidator<T> : AbstractValidator<T> where T : CreateFollowDTO
    {
        public BaseFollowValidator(RecipeContext ctx)
        {
            RuleFor(x => x.UserId).NotEmpty()
                                  .WithMessage("User Id is required.")
                                  .Must(x => ctx.Users.Any(u => u.Id == x))
                                  .WithMessage("User not exist.");

            
        }
    }
}
