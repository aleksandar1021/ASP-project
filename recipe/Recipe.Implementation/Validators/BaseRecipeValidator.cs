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
    public class BaseRecipeValidator<T> : AbstractValidator<T> where T : RecipeDTO
    {
        protected readonly RecipeContext _ctx;

        public BaseRecipeValidator(RecipeContext ctx)
        {
            _ctx = ctx;

            

            RuleFor(x => x.CategoryId).NotEmpty()
                                      .WithMessage("Category Id is required.")
                                      .Must(x => ctx.Categories.Any(u => u.Id == x))
                                      .WithMessage("Category not exist.");

            RuleFor(x => x.Title).NotEmpty()
                                 .WithMessage("Category tile is required.")
                                 .Must(x => x.Length <= 100)
                                 .WithMessage("Title must be less than 100 characters.");

            RuleFor(x => x.Description).NotEmpty()
                                       .WithMessage("Category Description is required.")
                                       .Must(x => x.Length <= 250)
                                       .WithMessage("Description must be less than 250 characters.");

            RuleFor(x => x.Images).NotNull()
                                  .WithMessage("Images is required.");

            RuleFor(x => x.Ingredients)
                          .NotNull()
                          .WithMessage("Ingredients is required.")
                          .Must(x => x.Count() <= 100)
                          .WithMessage("Count of ingredients must be less than 100.")
                          .Must(IngredientsExistInDatabase)
                          .WithMessage("One or more ingredients do not exist.");

            RuleFor(x => x.Steps).NotNull()
                                 .WithMessage("Steps is required.")
                                 .Must(x => x.Count() <= 100)
                                 .WithMessage("Count of Steps must be less than 100.");

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

        private bool IngredientsExistInDatabase(IEnumerable<IngredientsDTO> ingredients)
        {
            var ingredientIds = ingredients.Select(i => i.Id).ToList();

            var existingIngredientIds = _ctx.Ingredients
                                            .Where(i => ingredientIds.Contains(i.Id))
                                            .Select(i => i.Id)
                                            .ToList();

            return ingredientIds.All(id => existingIngredientIds.Contains(id));
        }
    }
}
