using FluentValidation;
using Recipe.Application.DTO;
using Recipe.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Recipe.Implementation.Validators
{
    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryDTO>
    {
        private RecipeContext _ctx;
        public UpdateCategoryValidator(RecipeContext ctx)
        {
            _ctx = ctx;

            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Id).Must(x => ctx.Categories.Any(c => c.Id == x))
                              .WithMessage("Category not exist.");

            RuleFor(x => x.Name).NotNull()
                               .WithMessage("Name of category is required.")
                               .MinimumLength(5)
                               .WithMessage("Minimum number of characters is 5.")
                               .Must((dto, name) => !ctx.Categories.Any(c => c.Name == name && c.Id != dto.Id))
                               .WithMessage("Category name must be unique.");



            RuleFor(x => x.ParentId).Must(IfExistParentId)
                                    .WithMessage("Parent Id not exist.");

            RuleFor(x => x.ChildIds).Must(IfChildrenExist)
                                    .WithMessage("Not all children categories exist.");



        }

        private bool IfExistParentId(int? parentId)
        {
            if (!parentId.HasValue)
            {
                return true;
            }
            return _ctx.Categories.Any(x => x.Id == parentId && x.IsActive);
        }

        private bool IfChildrenExist(IEnumerable<int> ids)
        {
            if (ids == null || !ids.Any())
            {
                return true;
            }
            int brojIzBaze = _ctx.Categories.Count(x => x.IsActive && ids.Contains(x.Id));
            return brojIzBaze == ids.Count();
        }
    }
}
    

