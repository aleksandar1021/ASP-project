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
    public class EfUpdateUserUseCaseAccessCommand : EfUseCase, IUpdateUserUseCaseAccessCommand
    {
        private UpdateUserUseCaseAccessValidator _validator;
        public EfUpdateUserUseCaseAccessCommand(RecipeContext context, UpdateUserUseCaseAccessValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 2;

        public string Name => "Update user access";

        public void Execute(UpdateUserUseCaseDTO data)
        {
            _validator.ValidateAndThrow(data);

            var allUserUseCases = Context.UserUseCases
                                      .Where(x => x.UserId == data.UserId)
                                      .ToList();

            Context.UserUseCases.RemoveRange(allUserUseCases);

            Context.UserUseCases.AddRange(data.UseCaseIds.Select(id =>
                                                                    new UserUseCase
                                                                    {
                                                                        UserId = data.UserId,
                                                                        UseCaseId = id
                                                                    }
                                                                 ));

            Context.SaveChanges();
        }
    }
}
