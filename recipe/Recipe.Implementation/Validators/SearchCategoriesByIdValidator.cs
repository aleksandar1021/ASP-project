using FluentValidation;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Recipe.Application.DTO;
using Recipe.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Implementation.Validators
{
    public class SearchCategoriesByIdValidator : AbstractValidator<TableIdDTO>
    {
        public SearchCategoriesByIdValidator(RecipeContext ctx)
        {
            RuleFor(x => x.Id).Must(x => ctx.Categories.Any(c => c.Id == x))
                              .WithMessage("Category not exist.");
        }
    }
}
