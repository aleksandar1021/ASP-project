using Recipe.API.Core;
using Recipe.Application.UseCases.Commands.Follows;
using Recipe.DataAccess;
using Recipe.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Implementation.UseCases.Commands.Follows
{
    public class EfDeleteFollowsCommand : EfUseCase, IDeleteFollowCommand
    {
        public EfDeleteFollowsCommand(RecipeContext context) : base(context)
        {
        }

        public int Id => 39;

        public string Name => "Delete follower";

        public void Execute(int data)
        {
            Follow follow = Context.Follows.Find(data);

            if(follow == null)
            {
                throw new NotFoundException();
            }

            Context.Follows.Remove(follow);
            Context.SaveChanges();
        }
    }
}
