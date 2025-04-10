using FluentValidation;
using Microsoft.IdentityModel.Tokens;
using Recipe.Application.DTO;
using Recipe.Application.UseCases.Commands.Users;
using Recipe.DataAccess;
using Recipe.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Recipe.Implementation.UseCases.Commands.Users
{
    public class EfCreateUserCommand : EfUseCase, ICreateUserCommand
    {
        private CreateUserValidator _validator;

        public EfCreateUserCommand(RecipeContext context, CreateUserValidator validator) : base(context)
        {
            _validator = validator;
        }
        public int Id => 1;
        public string Name => "Create user";

        private List<int> allowedCasesForUser = new List<int> 
        { 1, 4, 10, 13, 14, 18, 19, 20,21, 22, 23, 24, 25, 26, 30, 31,32, 33, 34, 35, 36, 37, 38, 39,
          40, 41, 42, 43, 45, 46, 47, 48, 49, 50, 51
        };
        public void Execute(CreateUserDTO data)
        {
            _validator.ValidateAndThrow(data);

            User user = new User
            {
                Email = data.Email,
                FirstName = data.FirstName,
                LastName = data.LastName,
                Password = BCrypt.Net.BCrypt.HashPassword(data.Password),
                Username = data.Username,
                Image = data.Image ?? "avatar.png",
                UserUseCases = allowedCasesForUser.Select(u => new UserUseCase
                {
                    UseCaseId = u
                }).ToList()
            };
            

            if(data.Image != null)
            {
                var tempImageName = Path.Combine("wwwroot", "temp", data.Image);
                var destinationFileName = Path.Combine("wwwroot", "userPhotos", data.Image);
                System.IO.File.Move(tempImageName, destinationFileName);
            }

            Context.Users.Add(user);
            Context.SaveChanges();
        }
    }
}
