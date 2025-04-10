using Recipe.API.Core;
using Recipe.Application.UseCases.Commands.Steps;
using Recipe.DataAccess;
using Recipe.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Implementation.UseCases.Commands.Steps
{
    public class EfDeleteStepsCommand : EfUseCase, IDeleteStepCommand
    {
        public EfDeleteStepsCommand(RecipeContext context) : base(context)
        {
        }

        public int Id => 34;

        public string Name => "Delete step for recipe";

        public void Execute(int data)
        {
            Step step = Context.Steps.Find(data);

            if(step == null)
            {
                throw new NotFoundException();
            }

            Context.Steps.Remove(step);
            Context.SaveChanges();
        }
    }
}
