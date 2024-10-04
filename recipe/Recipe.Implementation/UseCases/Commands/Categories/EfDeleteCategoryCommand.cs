using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Recipe.API.Core;
using Recipe.Application.DTO;
using Recipe.Application.UseCases.Commands.Categories;
using Recipe.DataAccess;
using Recipe.Domain;
using Recipe.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Implementation.UseCases.Commands.Categories
{
    public class EfDeleteCategoryCommand : EfUseCase, IDeleteCategoryCommand
    {
        private DeleteCategoryValidator _validator;
        public EfDeleteCategoryCommand(RecipeContext context, DeleteCategoryValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 11;

        public string Name => "Delete category";

        public void Execute(TableIdDTO data)
        {
            Category category = Context.Categories.Include(x => x.Recipes).FirstOrDefault(x => x.Id == data.Id);

            if(category == null)
            {
                throw new NotFoundException();
            }

            if (category.Recipes.Any())
            {
                throw new ConflictException();
            }

            _validator.ValidateAndThrow(data);

            

            Context.Categories.Remove(category);

            Context.SaveChanges();
        }
    }
}
