using FluentValidation;
using Recipe.Application.DTO;
using Recipe.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Implementation.Validators
{
    public class DeleteCategoryValidator : AbstractValidator<TableIdDTO>
    {

        public DeleteCategoryValidator(RecipeContext ctx)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.Id).NotEmpty()
                              .WithMessage("Category Id is required.")
                              .Must(x => ctx.Categories.Any(c => c.Id == x))
                              .WithMessage("Category not exist.")
                              .Must(x => !ctx.Categories.Any(c => c.ParentId == x))
                              .WithMessage("Category have childrens.");
        }
    }
}
