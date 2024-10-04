using Recipe.API.Core;
using Recipe.Application.UseCases.Commands.RecipeRatings;
using Recipe.DataAccess;
using Recipe.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Implementation.UseCases.Commands.RecipeRatings
{
    public class EfDeleteRecipeRatingsCommand : EfUseCase, IDeleteRecipeRatingsCommand
    {
        public EfDeleteRecipeRatingsCommand(RecipeContext context) : base(context)
        {
        }

        public int Id => 31;

        public string Name => "Delete ratings for recipe";

        public void Execute(int data)
        {
            RecipeRating rr = Context.RecipeRatings.Find(data);

            if(rr == null) 
            {
                throw new NotFoundException();
            }

            Context.RecipeRatings.Remove(rr);

            Context.SaveChanges();
        }
    }
}
