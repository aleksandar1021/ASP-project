using FluentValidation;
using Recipe.Application.DTO;
using Recipe.Application.UseCases.Commands.Steps;
using Recipe.DataAccess;
using Recipe.Domain;
using Recipe.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Implementation.UseCases.Commands.Steps
{
    public class EfUpdateStepsCommand : EfUseCase, IUpdateStepCommand
    {
        UpdateStepValidator _validator;
        public EfUpdateStepsCommand(RecipeContext context, UpdateStepValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 33;

        public string Name => "Update step";

        public void Execute(UpdateStepDTO data)
        {
            _validator.ValidateAndThrow(data);

            Step step = Context.Steps.Find(data.Id);
            step.Description = data.Description;
            step.RecipeId = data.RecipeId;
            step.UpdatedAt = DateTime.UtcNow;

            Context.SaveChanges();
        }
    }
}
