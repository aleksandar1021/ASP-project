using FluentValidation;
using Microsoft.EntityFrameworkCore;
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
    public class EfUpdateCommentsCommand : EfUseCase, IUpdateCommentCommand
    {
        private UpdateCommentValidator _validator;
        private IApplicationActor _actor;
        public EfUpdateCommentsCommand(RecipeContext context, UpdateCommentValidator validator, IApplicationActor actor) : base(context)
        {
            _validator = validator;
            _actor = actor;
        }

        public int Id => 41;

        public string Name => "Update comment";

        public void Execute(UpdateCommentDTO data)
        {
            _validator.ValidateAndThrow(data);

            Comment comment = Context.Comments
                                     .Include(x => x.Children)
                                     .FirstOrDefault(x => x.Id == data.Id);


            comment.Text = data.Text;
            comment.ParentId = data.ParentId;
            comment.UserId = _actor.Id;
            comment.RecipeId = data.RecipeId;
            comment.UpdatedAt = DateTime.UtcNow;

            foreach (var child in comment.Children)
            {
                child.ParentId = null;
            }

            if (data.ChildsIds != null && data.ChildsIds.Any())
            {
                List<Comment> comments = Context.Comments.Where(x => data.ChildsIds.Contains(x.Id)).ToList();
                comment.Children = comments;
            }

            Context.SaveChanges();
        }
    }
}
