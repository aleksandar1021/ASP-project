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
    public class EfCreateIngredientCommand : EfUseCase, ICreateIngredientCommand
    {
        private CreateIngredientValidator _validator;

        public EfCreateIngredientCommand(RecipeContext context, CreateIngredientValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 15;

        public string Name => "Create ingredient";

        public void Execute(NamedDTO data)
        {
            _validator.ValidateAndThrow(data);

            Ingredient newIngredient = new Ingredient
            {
                Name = data.Name
            };

            Context.Ingredients.Add(newIngredient);
            Context.SaveChanges();
        }
    }
}
