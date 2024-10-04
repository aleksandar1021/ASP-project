using FluentValidation;
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
    public class EfUpdateUserCommand : EfUseCase, IUpdateUserCommand
    {
        private UpdateUserValidator _validator;

        public EfUpdateUserCommand(RecipeContext context, UpdateUserValidator validator) : base(context)
        {
            _validator = validator;
        }
        public int Id => 4;

        public string Name => "Update user";

        public void Execute(UpdateUserDTO data)
        {
            _validator.ValidateAndThrow(data);

            User user = Context.Users.FirstOrDefault(u => u.Id == data.UserId);

            if (user == null)
            {
                throw new InvalidOperationException("User not exist");
            }

            user.Username = data.Username;
            user.Password = BCrypt.Net.BCrypt.HashPassword(data.Password);
            user.Email = data.Email;
            user.FirstName = data.FirstName;
            user.LastName = data.LastName;
            user.UpdatedAt = DateTime.UtcNow;
            user.Image = data.Image ?? "avatar.png";

            if (data.Image != null)
            {
                var tempImageName = Path.Combine("wwwroot", "temp", data.Image);
                var destinationFileName = Path.Combine("wwwroot", "userPhotos", data.Image);
                System.IO.File.Move(tempImageName, destinationFileName);
            }

            Context.SaveChanges();

        }
    }
}
