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
    public class UpdateImageValidator : BaseImageValidator<UpdateImageDTO>
    {
        public UpdateImageValidator(RecipeContext ctx) : base(ctx)
        {
            RuleFor(x => x.Id).NotEmpty()
                              .WithMessage("Image Id is required.")
                              .Must(x => ctx.Images.Any(i => i.Id == x))
                              .WithMessage("Image not exist");
        }
    }
}
