using Microsoft.AspNetCore.Mvc;
using Recipe.DataAccess;
using Recipe.Domain;
using static System.Runtime.InteropServices.JavaScript.JSType;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Recipe.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InitialDataController : ControllerBase
    {
        RecipeContext ctx;

        public InitialDataController(RecipeContext _ctx)
        {
            ctx = _ctx;
        }


        // GET: api/<InitialDataController>
        [HttpGet]
        public IActionResult Get()
        {
            
            if(ctx.Users.Any())
            {
                return Conflict("Database is alredy filled.");
            }

            List<int> allowedCasesForUser = new List<int>
            { 
              1, 4, 10, 13, 14, 18, 19, 20,21, 22, 23, 24, 25, 26, 30, 31,32, 33, 34, 35, 36, 37, 38, 39,
              40, 41, 42, 43, 45, 46, 47, 48, 49, 50, 51
            };

            List<int> allowedCasesForAdmin = new List<int>
            { 
                1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,
                33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52
            };

            User user1 = new User
            {
                FirstName = "User",
                LastName = "User",
                Email = "user@gmail.com",
                Username = "user",
                Password = BCrypt.Net.BCrypt.HashPassword("Lozinka123!"),
                UserUseCases = allowedCasesForUser.Select(u => new UserUseCase
                {
                    UseCaseId = u
                }).ToList()
                

            };

            User user2 = new User
            {
                FirstName = "Admin",
                LastName = "Admin",
                Email = "admin@gmail.com",
                Username = "admin",
                Password = BCrypt.Net.BCrypt.HashPassword("Lozinka123!"),
                UserUseCases = allowedCasesForAdmin.Select(u => new UserUseCase
                {
                    UseCaseId = u
                }).ToList(),
                Follows = new List<Follow>
                {
                    new Follow
                    {
                        FollowUser = user1
                    }
                }

            };
            user1.Follows = new List<Follow>
            {
                new Follow
                {
                    FollowUser = user2
                }
            };


            Category cat1 = new Category
            {
                Name = "Salty"
            };

            Category cat2 = new Category
            {
                Name = "Sweet"
            };

            Category cat3 = new Category
            {
                Parent = cat2,
                Name = "Cakes"
            };

            Category cat4 = new Category
            {
                Parent = cat2,
                Name = "Ice cream"
            };

            Category cat5 = new Category
            {
                Parent = cat1,
                Name = "Meat"
            };


            Recipes recipe1 = new Recipes
            {
                User = user1,
                Category = cat5,
                Title = "Meat in mushroom sauce",
                Steps = new List<Step>
                {
                    new Step
                    {
                        StepNumber = 1,
                        Description = "Step 1"
                    },
                    new Step
                    {
                        StepNumber = 2,
                        Description = "Step 2"
                    },
                    new Step
                    {
                        StepNumber = 3,
                        Description = "Step 3"
                    }
                },
                Images = new List<Image> 
                { 
                    new Image
                    {
                        Path = "image1.jpg"
                    },
                    new Image
                    {
                        Path = "image2.jpg"
                    }
                }
            };

            Recipes recipe2 = new Recipes
            {
                User = user2,
                Category = cat2,
                Title = "Ice cream",
                Description = "Sweet ice cream",
                Steps = new List<Step>
                {
                    new Step
                    {
                        StepNumber = 1,
                        Description = "Step 1"
                    },
                    new Step
                    {
                        StepNumber = 2,
                        Description = "Step 2"
                    },
                    new Step
                    {
                        StepNumber = 3,
                        Description = "Step 3"
                    },
                    new Step
                    {
                        StepNumber = 3,
                        Description = "Step 4"
                    },
                    new Step
                    {
                        StepNumber = 3,
                        Description = "Step 5"
                    }
                },
                Images = new List<Image>
                {
                    new Image
                    {
                        Path = "image3.jpg"
                    },
                    new Image
                    {
                        Path = "image4.jpg"
                    },
                    new Image
                    {
                        Path = "image5.jpg"
                    }
                }
            };

            Rating rating1 = new Rating
            {
                RatingValue = 1
            };
            Rating rating2 = new Rating
            {
                RatingValue = 2
            };
            Rating rating3 = new Rating
            {
                RatingValue = 3
            };
            Rating rating4 = new Rating
            {
                RatingValue = 4
            };
            Rating rating5 = new Rating
            {
                RatingValue = 5
            };



            RecipeRating rr1 = new RecipeRating
            {
                Recipe = recipe1,
                Rating = rating5,
                User = user1
            };

            RecipeRating rr2 = new RecipeRating
            {
                Recipe = recipe2,
                Rating = rating4,
                User = user2
            };


            Ingredient ingredient1 = new Ingredient
            {
                Name = "Salt"
            };

            Ingredient ingredient2 = new Ingredient
            {
                Name = "Pepper"
            };

            Ingredient ingredient3 = new Ingredient
            {
                Name = "Cheese"
            };

            Ingredient ingredient4 = new Ingredient
            {
                Name = "Sugar"
            };

            Ingredient ingredient5 = new Ingredient
            {
                Name = "Oil"
            };

            Ingredient ingredient6 = new Ingredient
            {
                Name = "Onion"
            };

            Ingredient ingredient7 = new Ingredient
            {
                Name = "Milk"
            };


            RecipeIngredient ri1 = new RecipeIngredient
            {
                Recipe = recipe1,
                Ingredient = ingredient5,
                Quantity = "1 ml"
            };

            RecipeIngredient ri2 = new RecipeIngredient
            {
                Recipe = recipe1,
                Ingredient = ingredient1,
                Quantity = "10 g"
            };

            RecipeIngredient ri3 = new RecipeIngredient
            {
                Recipe = recipe1,
                Ingredient = ingredient2,
                Quantity = "5 g"
            };

            RecipeIngredient ri4 = new RecipeIngredient
            {
                Recipe = recipe2,
                Ingredient = ingredient4,
                Quantity = "50 g"
            };

            RecipeIngredient ri5 = new RecipeIngredient
            {
                Recipe = recipe2,
                Ingredient = ingredient7,
                Quantity = "100 ml"
            };


            Comment com1 = new Comment
            {
                Text = "Comment 1",
                User = user1,
                Recipe = recipe1
            };

            Comment com2 = new Comment
            {
                Text = "Child Comment",
                User = user2,
                Recipe = recipe1,
                Parent = com1
            };

            Comment com3 = new Comment
            {
                Text = "Comment 2",
                User = user2,
                Recipe = recipe2
            };


            ctx.Users.Add(user1);
            ctx.Users.Add(user2);

            ctx.Categories.Add(cat1);
            ctx.Categories.Add(cat2);
            ctx.Categories.Add(cat3);
            ctx.Categories.Add(cat4);
            ctx.Categories.Add(cat5);

            ctx.Recipes.Add(recipe1);
            ctx.Recipes.Add(recipe2);

            ctx.Ratings.Add(rating1);
            ctx.Ratings.Add(rating2);
            ctx.Ratings.Add(rating3);
            ctx.Ratings.Add(rating4);
            ctx.Ratings.Add(rating5);

            ctx.RecipeRatings.Add(rr1);
            ctx.RecipeRatings.Add(rr2);

            ctx.Ingredients.Add(ingredient1);
            ctx.Ingredients.Add(ingredient2);
            ctx.Ingredients.Add(ingredient3);
            ctx.Ingredients.Add(ingredient4);
            ctx.Ingredients.Add(ingredient5);
            ctx.Ingredients.Add(ingredient6);
            ctx.Ingredients.Add(ingredient7);

            ctx.RecipeIngredients.Add(ri1);
            ctx.RecipeIngredients.Add(ri2);
            ctx.RecipeIngredients.Add(ri3);
            ctx.RecipeIngredients.Add(ri4);
            ctx.RecipeIngredients.Add(ri5);

            ctx.Comments.Add(com1);
            ctx.Comments.Add(com2);
            ctx.Comments.Add(com3);

            ctx.SaveChanges();



            return StatusCode(201);
        }

        
    }
}
