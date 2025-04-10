using FluentValidation;
using Recipe.Application.DTO;
using Recipe.Application.UseCases.Commands.Images;
using Recipe.DataAccess;
using Recipe.Domain;
using Recipe.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Implementation.UseCases.Commands.Images
{
    public class EfCreateImagesCommand : EfUseCase, ICreateImageCommand
    {
        CreateImageValidator _validator;
        public EfCreateImagesCommand(RecipeContext context, CreateImageValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 35;

        public string Name => "Create images for recipe";

        public void Execute(CreateImageDTO data)
        {
            _validator.ValidateAndThrow(data);

            List<Image> images = new List<Image>();

            foreach(var image in data.Images)
            {
                Image newImage = new Image
                {
                    Path = image,
                    RecipeId = data.RecipeId
                };
                images.Add(newImage);

                var tempImageName = Path.Combine("wwwroot", "temp", image);
                var destinationFileName = Path.Combine("wwwroot", "recipePhotos", image);
                System.IO.File.Move(tempImageName, destinationFileName);
            }
            

            Context.Images.AddRange(images);
            Context.SaveChanges();  
        }
    }
}
