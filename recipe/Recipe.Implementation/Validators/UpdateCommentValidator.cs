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
    public class UpdateCommentValidator : BaseCommentValidator<UpdateCommentDTO>
    {
        private RecipeContext _ctx;
        public UpdateCommentValidator(RecipeContext ctx) : base(ctx)
        {
            _ctx = ctx;

            RuleFor(x => x.Id).NotEmpty()
                              .WithMessage("Comment Id is required.")
                              .Must(x => ctx.Comments.Any(c => c.Id == x))
                              .WithMessage("Comment not exist.");

            RuleFor(x => x.ParentId).Must(IfExistParentId)
                                    .WithMessage("Parent Id not exist.");

            RuleFor(x => x.ChildsIds).Must(IfChildrenExist)
                                    .WithMessage("Not all children comments exist.");
        }

        private bool IfExistParentId(int? parentId)
        {
            if (!parentId.HasValue)
            {
                return true;
            }
            return _ctx.Comments.Any(x => x.Id == parentId && x.IsActive);
        }

        private bool IfChildrenExist(IEnumerable<int> ids)
        {
            if (ids == null || !ids.Any())
            {
                return true;
            }
            int brojIzBaze = _ctx.Comments.Count(x => x.IsActive && ids.Contains(x.Id));
            return brojIzBaze == ids.Count();
        }
    }
}
