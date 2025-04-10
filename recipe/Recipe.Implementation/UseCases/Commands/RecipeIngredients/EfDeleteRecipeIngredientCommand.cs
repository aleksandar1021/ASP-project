using FluentValidation;
using Recipe.API.Core;
using Recipe.Application.DTO;
using Recipe.Application.UseCases.Commands.RecipeIngredients;
using Recipe.DataAccess;
using Recipe.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Implementation.UseCases.Commands.RecipeIngredients
{
    public class EfDeleteRecipeIngredientCommand : EfUseCase, IDeleteRecipeIngredientCommand
    {
        DeleteRecipeIngredientValidator _validator;
        public EfDeleteRecipeIngredientCommand(RecipeContext context, DeleteRecipeIngredientValidator validator) : base(context)
        {
            _validator = validator;
        }



        public int Id => 26;

        public string Name => "Delete ingredient for recipe";

        public void Execute(TableIdDTO data)
        {
            var ri = Context.RecipeIngredients.Find(data.Id);

            if(ri == null)
            {
                throw new NotFoundException();
            }
            _validator.ValidateAndThrow(data);


            Context.RecipeIngredients.Remove(ri);

            Context.SaveChanges();
        }
    }
}
