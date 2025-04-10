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
    public class BaseCommentValidator<T> : AbstractValidator<T> where T : CreateCommentDTO
    {
        private RecipeContext _ctx;
        public BaseCommentValidator(RecipeContext ctx)
        {
            _ctx = ctx;


            RuleFor(x => x.ParentId).Must(IfExistParentId)
                                    .WithMessage("Parent comment not exist.");

            RuleFor(x => x.Text).NotEmpty()
                                .WithMessage("Comment text is required.")
                                .Must(x => x.Length < 250)
                                .WithMessage("Maximum characters for comment text is 250.");



            RuleFor(x => x.RecipeId).NotEmpty()
                                    .WithMessage("Recipe Id is required.")
                                    .Must(x => ctx.Recipes.Any(u => u.Id == x))
                                    .WithMessage("Recipe not exist.");
        }


        private bool IfExistParentId(int? parentId)
        {
            if (!parentId.HasValue)
            {
                return true;
            }
            return _ctx.Comments.Any(x => x.Id == parentId && x.IsActive);
        }
        
    }
}
