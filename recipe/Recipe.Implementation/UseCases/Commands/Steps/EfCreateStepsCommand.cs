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
    public class EfCreateStepsCommand : EfUseCase, ICreateStepCommand
    {
        CreateStepValidator _validator;

        public EfCreateStepsCommand(RecipeContext context, CreateStepValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 32;

        public string Name => "Create step";

        public void Execute(CreateStepDTO data)
        {
            _validator.ValidateAndThrow(data);

            int maxStepNumber = Context.Steps.Max(s => s.StepNumber);

            Step newStep = new Step
            {
                Description = data.Description,
                RecipeId = data.RecipeId,
                StepNumber = maxStepNumber + 1
            };

            Context.Steps.Add(newStep);
            Context.SaveChanges();
        }
    }
}
