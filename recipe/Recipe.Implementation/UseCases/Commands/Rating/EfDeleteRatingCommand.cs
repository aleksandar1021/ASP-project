using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Recipe.API.Core;
using Recipe.Application.UseCases.Commands.Rating;
using Recipe.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Implementation.UseCases.Commands.Rating
{
    public class EfDeleteRatingCommand : EfUseCase, IDeleteRatingCommand
    {
        public EfDeleteRatingCommand(RecipeContext context) : base(context)
        {
        }

        public int Id => 29;

        public string Name => "Delete rating";

        public void Execute(int data)
        {
            Domain.Rating rating = Context.Ratings.Include(x => x.RecipeRatings).FirstOrDefault(x => x.Id == data);

            if(rating == null)
            {
                throw new NotFoundException();
            }

            if (rating.RecipeRatings.Any())
            {
                throw new ConflictException("The rating cannot be deleted");
            }

            Context.Ratings.Remove(rating);
            Context.SaveChanges();
        }
    }
}
