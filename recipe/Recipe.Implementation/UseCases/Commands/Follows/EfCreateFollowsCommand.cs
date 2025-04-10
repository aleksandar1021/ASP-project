using FluentValidation;
using Recipe.Application;
using Recipe.Application.DTO;
using Recipe.Application.UseCases.Commands.Follows;
using Recipe.DataAccess;
using Recipe.Domain;
using Recipe.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Implementation.UseCases.Commands.Follows
{
    public class EfCreateFollowsCommand : EfUseCase, ICreateFollowCommand
    {
        private CreateFollowValidator _validator;
        private IApplicationActor _actor;
        public EfCreateFollowsCommand(RecipeContext context, CreateFollowValidator validator, IApplicationActor actor) : base(context)
        {
            _validator = validator;
            _actor = actor;
        }

        public int Id => 38;

        public string Name => "Create follow for user";

        public void Execute(CreateFollowDTO data)
        {
            _validator.ValidateAndThrow(data);

            Follow newFollow = new Follow
            {
                UserId = _actor.Id,
                FollowId = data.UserId
            };

            Context.Follows.Add(newFollow);
            Context.SaveChanges();
        }
    }
}
