using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Recipe.Application.DTO;
using Recipe.Application.UseCases;
using Recipe.Application.UseCases.Queries.Categories;
using Recipe.DataAccess;
using Recipe.Domain;
using Recipe.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Recipe.Implementation.UseCases.Queries.Categories
{
    public class EfGetCategoryWithChildrenByIdQuery : EfUseCase, IGetCategoryWithChildrenByIdQuery
    {
        private SearchCategoriesByIdValidator _validator;
        public EfGetCategoryWithChildrenByIdQuery(RecipeContext context, SearchCategoriesByIdValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 14;

        public string Name => "Search categories with children by Id";



        public CategoryResponseWithChildrenDTO Execute(TableIdDTO data)
        {
            _validator.ValidateAndThrow(data);

            int catId = data.Id;
            Category c = Context.Categories.Find(catId);



            CategoryResponseWithChildrenDTO dto = new()
            {
                Id = c.Id,
                Name = c.Name
            };

           
            FillChildrenOfParents(dto);

            return dto;

        }



        private void FillChildrenOfParents(CategoryResponseWithChildrenDTO category)
        {

            int id = category.Id;

            category.Children = Context.Categories.Where(x => x.ParentId == id).Select(c => new CategoryResponseWithChildrenDTO
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();


            foreach (CategoryResponseWithChildrenDTO child in category.Children)
            {
                FillChildrenOfParents(child);
            }
        }
    }
}


