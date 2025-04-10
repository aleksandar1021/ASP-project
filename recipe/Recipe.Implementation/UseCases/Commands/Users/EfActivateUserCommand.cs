using FluentValidation;
using Recipe.Application.DTO;
using Recipe.Application.UseCases.Commands.Users;
using Recipe.DataAccess;
using Recipe.Domain;
using Recipe.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Implementation.UseCases.Commands.Users
{
    public class EfActivateUserCommand : EfUseCase,IActivateUserCommand
    {
        private ChangeStatusUserValidator _validator;
        public EfActivateUserCommand(RecipeContext context, ChangeStatusUserValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 7;

        public string Name => "Activate user";

        public void Execute(TableIdDTO data)
        {
            _validator.ValidateAndThrow(data);

            int userId = data.Id;
            User user = Context.Users.Find(userId);

            user.IsActive = true;

            Context.SaveChanges();
        }
    }
}
