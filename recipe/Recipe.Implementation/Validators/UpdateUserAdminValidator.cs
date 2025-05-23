﻿using FluentValidation;
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
    public class UpdateUserAdminValidator : BaseUserUpdateValidator
    {
        public UpdateUserAdminValidator(RecipeContext ctx, IApplicationActor actor) : base(ctx, actor)
        {
            base.CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Username)
                   .NotEmpty()
                   .Matches("^.{3,100}$")
                   .WithMessage("Username must contain a minimum of 3 characters and a maximum of 100")
                   .Must((dto, x) => !ctx.Users.Any(u => dto.UserId != u.Id && u.Username == x))
                   .WithMessage("Username is already in use.");


            RuleFor(x => x.Email)
                  .EmailAddress()
                  .WithMessage("Email address must be in format (user@gmail.com)")
                  .Must((dto, x) => !ctx.Users.Any(u => dto.UserId != u.Id && u.Username == x))
                  .WithMessage("Email is already in use.");

            RuleFor(x => x.Image).Must((x, fileName) =>
            {
                if (fileName == null)
                {
                    return true;
                }
                var path = Path.Combine("wwwroot", "temp", fileName);

                var exists = Path.Exists(path);

                return exists;
            }).WithMessage("File doesn't exist.");

        }

      

        
    }
}
