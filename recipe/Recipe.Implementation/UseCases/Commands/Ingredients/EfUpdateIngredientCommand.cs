using FluentValidation;
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
    public class EfUpdateIngredientCommand : EfUseCase, IUpdateIngredientCommand
    {
        private UpdateIngredientValidator _validator;
        public EfUpdateIngredientCommand(RecipeContext context, UpdateIngredientValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 16;

        public string Name => "Update ingredient";

        public void Execute(UpdateNamedDTO data)
        {
            _validator.ValidateAndThrow(data);

            Ingredient ingredient = Context.Ingredients.Find(data.Id);

            ingredient.Name = data.Name;
            ingredient.UpdatedAt = DateTime.UtcNow;

            Context.SaveChanges();
        }
    }
}
