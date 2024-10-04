using Recipe.API.Core;
using Recipe.Application.DTO;
using Recipe.Application.UseCases.Commands.Images;
using Recipe.Application.UseCases.Commands.Ingredients;
using Recipe.DataAccess;
using Recipe.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Implementation.UseCases.Commands.Images
{
    public class EfDeleteImagesCommand : EfUseCase, IDeleteImageCommand
    {
        public EfDeleteImagesCommand(RecipeContext context) : base(context)
        {
        }

        public int Id => 37;

        public string Name => "Delete image for recipe";

        public void Execute(int data)
        {
            Image image = Context.Images.Find(data);

            if(image == null)
            {
                throw new NotFoundException();
            }
            var oldImagePath = Path.Combine("wwwroot", "recipePhotos", image.Path);
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }
            


            Context.Images.Remove(image);
            Context.SaveChanges();
        }
    }
}
