using FluentValidation;
using Microsoft.Identity.Client;
using Recipe.Application;
using Recipe.Application.DTO;
using Recipe.Application.UseCases.Commands.Comments;
using Recipe.DataAccess;
using Recipe.Domain;
using Recipe.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Implementation.UseCases.Commands.Comments
{
    public class EfCreateCommentsCommand : EfUseCase, ICreateCommentCommand
    {
        private CreateCommentValidator _validator;
        private IApplicationActor _actor;
        public EfCreateCommentsCommand(RecipeContext context, CreateCommentValidator validator, IApplicationActor actor) : base(context)
        {
            _validator = validator;
            _actor = actor;
        }

        public int Id => 40;

        public string Name => "Create comment";

        public void Execute(CreateCommentDTO data)
        {
            _validator.ValidateAndThrow(data);

            Comment newComment = new Comment
            {
                ParentId = data.ParentId,
                Text = data.Text,
                UserId = _actor.Id,
                RecipeId = data.RecipeId
            };

            Context.Comments.Add(newComment);

            var childsComments = Context.Comments.Where(x => data.ChildsIds.Contains(x.Id))
                                                   .ToList();

            newComment.Children = childsComments;

            Context.SaveChanges();

        }
    }
}
