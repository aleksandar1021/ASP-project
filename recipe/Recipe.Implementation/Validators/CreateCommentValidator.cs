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
    public class CreateCommentValidator : BaseCommentValidator<CreateCommentDTO>
    {
        private RecipeContext _ctx;
        public CreateCommentValidator(RecipeContext ctx) : base(ctx)
        {
            _ctx = ctx;

            RuleFor(x => x.ChildsIds).Must(IfChildrenExist)
                                   .WithMessage("Not all children comments exist.");
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
