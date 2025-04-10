using FluentValidation;
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
    public class EfCreateRatingCommand : EfUseCase, ICreateRatingCommand
    {
        CreateRatingValidator _validator;
        public EfCreateRatingCommand(RecipeContext context, CreateRatingValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 27;

        public string Name => "Create rating";

        public void Execute(RatingDTO data)
        {
            _validator.ValidateAndThrow(data);

            Domain.Rating newRating = new Domain.Rating
            {
                RatingValue = data.RatingValue
            };

            Context.Ratings.Add(newRating);
            Context.SaveChanges();
        }
    }
}
