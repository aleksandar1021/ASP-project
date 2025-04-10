using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Recipe.Application.DTO;
using Recipe.Application.UseCases.Commands.Users;
using Recipe.DataAccess;
using Recipe.Domain;
using Recipe.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Implementation.UseCases.Commands.Users
{
    public class EfDeleteUSerCommand : EfUseCase,IDeleteUserCommand
    {
        private ChangeStatusUserValidator _validator;
        public EfDeleteUSerCommand(RecipeContext context, ChangeStatusUserValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 8;

        public string Name => "Delete user";

        public void Execute(TableIdDTO data)
        {
            int userId = data.Id;
            User user = Context.Users
                                .Include(u => u.RecipeRatings)
                                .Include(u => u.UserUseCases)
                                .Include(u => u.Comments)
                                .Include(u => u.Recipes)
                                    .ThenInclude(r => r.RecipeRatings)
                                .Include(u => u.Recipes)
                                    .ThenInclude(r => r.RecipeIngredients)
                                .Include(u => u.Recipes)
                                    .ThenInclude(r => r.Steps)
                                .Include(u => u.Recipes)
                                    .ThenInclude(r => r.Images)
                                .Include(u => u.Follows)
                                .FirstOrDefault(u => u.Id == userId);

            if(user == null) 
            {
                throw new DllNotFoundException();
            }

            if(user.RecipeRatings.Any() || user.UserUseCases.Any() || user.Comments.Any() || user.Recipes.Any() || user.Follows.Any())
            {
                throw new ConflictException("User cannot be deleted.");
            }
            _validator.ValidateAndThrow(data);

            var userUseCases = user.UserUseCases;
            var userComments = user.Comments;
            var userRecipes = user.Recipes;
            var userFollows = user.Follows;
            var userRatings = user.RecipeRatings;

            Context.RecipeRatings.RemoveRange(userRecipes.SelectMany(r => r.RecipeRatings));
            Context.RecipeIngredients.RemoveRange(userRecipes.SelectMany(r => r.RecipeIngredients));
            Context.Steps.RemoveRange(userRecipes.SelectMany(r => r.Steps));
            Context.Images.RemoveRange(userRecipes.SelectMany(r => r.Images));

            Context.UserUseCases.RemoveRange(userUseCases);
            Context.Comments.RemoveRange(userComments);
            Context.Follows.RemoveRange(userFollows);
            Context.Recipes.RemoveRange(userRecipes);
            Context.RecipeRatings.RemoveRange(userRatings);
            Context.Users.Remove(user);

            var oldImagePath = Path.Combine("wwwroot", "userPhotos", user.Image);
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }

            Context.SaveChanges();
            

        }
    }
}
