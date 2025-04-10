using FluentValidation;
using Recipe.Application.DTO;
using Recipe.Application.UseCases.Commands.RecipeRatings;
using Recipe.DataAccess;
using Recipe.Domain;
using Recipe.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Implementation.UseCases.Commands.RecipeRatings
{
    public class EfCreateRecipeRatingsCommand : EfUseCase, ICreateRecipeRatingsCommand
    {
        CreateRecipeRatingsValidator _validator;
        public EfCreateRecipeRatingsCommand(RecipeContext context, CreateRecipeRatingsValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 30;

        public string Name => "Create ratings for recipe";

        public void Execute(CreateRecipeRatingsDTO data)
        {
            _validator.ValidateAndThrow(data);

            RecipeRating NewRR = new RecipeRating
            {
                RecipeId = data.RecipeId,
                UserId = data.UserId,
                RatingId = data.RatingId,
            };

            Context.RecipeRatings.Add(NewRR);
            Context.SaveChanges();
        }
    }
}
