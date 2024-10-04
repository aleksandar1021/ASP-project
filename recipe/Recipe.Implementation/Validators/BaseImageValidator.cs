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
    public class BaseImageValidator<T> : AbstractValidator<T> where T : CreateImageDTO
    {
        public BaseImageValidator(RecipeContext ctx)
        {
            RuleFor(x => x.RecipeId).NotEmpty()
                                    .WithMessage("Recipe Id is required.")
                                    .Must(x => ctx.Recipes.Any(r => r.Id != x))
                                    .WithMessage("Recipe not exists.");

            RuleFor(x => x.Images).NotEmpty()
                                    .WithMessage("Image path is required.");


            RuleFor(x => x.Images).NotEmpty()
                    .WithMessage("Minimum one image is required.")
                    .DependentRules(() =>
                    {
                        RuleForEach(x => x.Images).Must((x, fileName) =>
                        {
                            var path = Path.Combine("wwwroot", "temp", fileName);

                            var exists = Path.Exists(path);

                            return exists;
                        }).WithMessage("File not exist.");
                    });

        }
    }
}
