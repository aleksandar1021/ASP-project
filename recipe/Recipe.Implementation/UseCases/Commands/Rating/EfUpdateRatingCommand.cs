using FluentValidation;
using Newtonsoft.Json;
using Recipe.API.Core;
using Recipe.Application.DTO;
using Recipe.Application.UseCases.Commands.Rating;
using Recipe.DataAccess;
using Recipe.Domain;
using Recipe.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Implementation.UseCases.Commands.Rating
{
    public class EfUpdateRatingCommand : EfUseCase, IUpdateRatingCommand
    {
        UpdateRatingValidator _validator;
        public EfUpdateRatingCommand(RecipeContext context, UpdateRatingValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 28;

        public string Name => "Update rating";

        public void Execute(UpdateRatingDTO data)
        {
            Domain.Rating rating = Context.Ratings.Find(data.Id);

            if(rating == null)
            {
                throw new NotFoundException();
            }


            _validator.ValidateAndThrow(data);

            rating.RatingValue = data.RatingValue;
            rating.UpdatedAt = DateTime.UtcNow;

            Context.SaveChanges();
        }
    }
}
