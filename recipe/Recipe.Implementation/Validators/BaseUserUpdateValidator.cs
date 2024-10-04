﻿using FluentValidation;
using Recipe.Application;
using Recipe.Application.DTO;
using Recipe.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Implementation.Validators
{
    public class BaseUserUpdateValidator : AbstractValidator<UpdateUserDTO>
    {
        protected readonly IApplicationActor _actor;
        public BaseUserUpdateValidator(RecipeContext ctx, IApplicationActor actor)
        {
            _actor = actor;

            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.UserId).NotEmpty()
                                  .WithMessage("User Id is required")
                                  .Must(x => ctx.Users.Any(u => u.Id == x))
                                  .WithMessage("User not exist.");

            RuleFor(x => x.FirstName)
                   .NotEmpty()
                   .Matches("^[A-Z][a-zA-Z]{2,29}$")
                   .WithMessage("The name must start with a capital letter and contain a minimum of 3 characters and a maximum of 30");

            RuleFor(x => x.LastName)
                   .NotEmpty()
                   .Matches("^[A-Z][a-zA-Z]{2,29}$")
                   .WithMessage("The lastname must start with a capital letter and contain a minimum of 3 characters and a maximum of 30");

            RuleFor(x => x.Password)
                  .NotEmpty()
                  .Matches("^(?=.*[A-Z])(?=.*[0-9])(?=.*[^A-Za-z0-9]).{8,}$")
                  .WithMessage("The password must contain at least 8 characters and must contain at least one capital letter, one number and one special character.");

        }
    }
}
