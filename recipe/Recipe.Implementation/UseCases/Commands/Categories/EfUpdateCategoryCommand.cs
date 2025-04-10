using FluentValidation;
using Microsoft.EntityFrameworkCore;
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
    public class EfUpdateCategoryCommand : EfUseCase ,IUpdateCategoryCommand
    {
        private UpdateCategoryValidator _validator;
        public EfUpdateCategoryCommand(RecipeContext context, UpdateCategoryValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 12;

        public string Name => "update category";

        public void Execute(UpdateCategoryDTO data)
        {
            _validator.ValidateAndThrow(data);

            int catId = data.Id;

            Category category = Context.Categories.Include(x => x.Children)
                                           .FirstOrDefault(x => x.Id == catId);


            category.Name = data.Name;
            category.ParentId = data.ParentId;
            category.UpdatedAt = DateTime.UtcNow;

            foreach (var child in category.Children)
            {
                child.ParentId = null;
            }

            if (data.ChildIds != null && data.ChildIds.Any())
            {
                List<Category> categories = Context.Categories.Where(x => data.ChildIds.Contains(x.Id)).ToList();
                category.Children = categories;
            }

            Context.SaveChanges();
        }
    }
}
