using Recipe.API.Core;
using Recipe.Application.UseCases.Commands.Comments;
using Recipe.DataAccess;
using Recipe.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Implementation.UseCases.Commands.Comments
{
    public class EfDeleteCommentsCommand : EfUseCase, IDeleteCommentCommand
    {
        public EfDeleteCommentsCommand(RecipeContext context) : base(context)
        {
        }

        public int Id => 42;

        public string Name => "Delete comment";

        public void Execute(int data)
        {
            Comment comment = Context.Comments.Find(data);

            if(comment == null)
            {
                throw new NotFoundException();
            }

            Context.Comments.Remove(comment);
            Context.SaveChanges();
        }
    }
}
