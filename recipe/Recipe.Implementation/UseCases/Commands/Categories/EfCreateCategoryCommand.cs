using FluentValidation;
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

    public class EfCreateCategoryCommand : EfUseCase, ICreateCategoryCommand
    {
        private CreateCategoryValidator _validator;
        public EfCreateCategoryCommand(RecipeContext context, CreateCategoryValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 9;

        public string Name => "Create category";

        public void Execute(CreateCategoryDTO data)
        {
            _validator.ValidateAndThrow(data);

            Category newCategory = new Category
            {
                Name = data.Name,
                ParentId = data.ParentId
            };

            Context.Categories.Add(newCategory);

            var childCategoriesOfCategory = Context.Categories
                                                   .Where(x => data.ChildIds.Contains(x.Id))
                                                   .ToList();

            newCategory.Children = childCategoriesOfCategory;

            Context.SaveChanges();
        }
    }
}
