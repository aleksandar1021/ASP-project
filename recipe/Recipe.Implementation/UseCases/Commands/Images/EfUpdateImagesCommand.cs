using FluentValidation;
using Microsoft.EntityFrameworkCore;
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
    public class EfUpdateImagesCommand : EfUseCase, IUpdateImageCommand
    {
        private UpdateImageValidator _validator;
        public EfUpdateImagesCommand(RecipeContext context, UpdateImageValidator valiator) : base(context)
        {
            _validator = valiator;
        }

        public int Id => 36;

        public string Name => "Update Image for recipe";

        public void Execute(UpdateImageDTO data)
        {
            _validator.ValidateAndThrow(data);

            var images = Context.Images.Where(x => x.RecipeId == data.RecipeId);

            foreach(var oldImage in images)
            {
                var oldImagePath = Path.Combine("wwwroot", "recipePhotos", oldImage.Path);
                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }
            }


            Context.Images.RemoveRange(images);

            List<Image> imagesList = new List<Image>();

            foreach (var image in data.Images)
            {
                Image newImage = new Image
                {
                    Path = image,
                    RecipeId = data.RecipeId
                };
                imagesList.Add(newImage);

                var tempImageName = Path.Combine("wwwroot", "temp", image);
                var destinationFileName = Path.Combine("wwwroot", "recipePhotos", image);
                System.IO.File.Move(tempImageName, destinationFileName);
            }
            Context.Images.AddRange(imagesList);

            Context.SaveChanges();
        }
    }
}
