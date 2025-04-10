using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Recipe.API.Core;
using Recipe.Application.DTO;
using Recipe.Application.UseCases.Commands.Ingredients;
using Recipe.DataAccess;
using Recipe.Domain;
using Recipe.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Implementation.UseCases.Commands.Ingredients
{
    public class EfDeleteIngredientCommand : EfUseCase, IDeleteIngredientCommand
    {
        DeleteIngredientValidator _validator;

        public EfDeleteIngredientCommand(RecipeContext context, DeleteIngredientValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 17;

        public string Name => "Delete ingredient";

        public void Execute(TableIdDTO data)
        {
            Ingredient ingredient = Context.Ingredients.Include(x => x.RecipeIngredients).FirstOrDefault(x => x.Id == data.Id);

            if(ingredient == null)
            {
                throw new NotFoundException();
            }

            if (ingredient.RecipeIngredients.Any())
            {
                throw new ConflictException("The ingredient cannot be deleted.");
            }

            _validator.ValidateAndThrow(data);

            Context.Ingredients.Remove(ingredient);
            Context.SaveChanges();
        }
    }
}
