using FluentValidation;
using Recipe.Application.DTO;
using Recipe.Application.UseCases.Commands.RecipeIngredients;
using Recipe.DataAccess;
using Recipe.Domain;
using Recipe.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Implementation.UseCases.Commands.RecipeIngredients
{
    public class EfCreateRecipeIngredientsCommand : EfUseCase, ICreateRecipeIngredientCommand
    {
        CreateRecipeIngredientValidator _validator;
        public EfCreateRecipeIngredientsCommand(RecipeContext context, CreateRecipeIngredientValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 24;

        public string Name => "Insert ingredient for recipe";

        public void Execute(CreateRecipeIngredientDTO data)
        {
            _validator.ValidateAndThrow(data);

            RecipeIngredient newRI = new RecipeIngredient
            {
                RecipeId = data.RecipeId,
                IngredientId = data.IngredientId,
            };

            Context.RecipeIngredients.Add(newRI);
            Context.SaveChanges();
        }
    }
}
