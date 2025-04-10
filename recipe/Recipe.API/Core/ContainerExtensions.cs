using Recipe.Application.UseCases.Commands.Categories;
using Recipe.Application.UseCases.Queries.Users;
using Recipe.Application;
using Recipe.Implementation.Logging.UseCases;
using Recipe.Implementation.UseCases.Commands.Categories;
using Recipe.Implementation.UseCases.Queries.Users;
using Recipe.Implementation.Validators;
using Recipe.Implementation;
using System.IdentityModel.Tokens.Jwt;
using Recipe.Application.DTO;
using Recipe.Application.UseCases.Commands.Ingredients;
using Recipe.Application.UseCases.Commands.RecipeIngredients;
using Recipe.Application.UseCases.Commands.Recipes;
using Recipe.Application.UseCases.Commands.Users;
using Recipe.Application.UseCases.Queries.AuditLogs;
using Recipe.Application.UseCases.Queries.Categories;
using Recipe.Application.UseCases.Queries.Ingredients;
using Recipe.Application.UseCases.Queries.Recipes;
using Recipe.Implementation.UseCases.Commands.Ingredients;
using Recipe.Implementation.UseCases.Commands.RecipeIngredients;
using Recipe.Implementation.UseCases.Commands.Recipes;
using Recipe.Implementation.UseCases.Commands.Users;
using Recipe.Implementation.UseCases.Queries.AuditLog;
using Recipe.Implementation.UseCases.Queries.Categories;
using Recipe.Implementation.UseCases.Queries.Ingredients;
using Recipe.Implementation.UseCases.Queries.Recipes;
using Recipe.Application.UseCases.Commands.Rating;
using Recipe.Implementation.UseCases.Commands.Rating;
using Recipe.Application.UseCases.Commands.RecipeRatings;
using Recipe.Implementation.UseCases.Commands.RecipeRatings;
using Recipe.Application.UseCases.Commands.Steps;
using Recipe.Implementation.UseCases.Commands.Steps;
using Recipe.Application.UseCases.Commands.Images;
using Recipe.Implementation.UseCases.Commands.Images;
using Recipe.Application.UseCases.Commands.Follows;
using Recipe.Implementation.UseCases.Commands.Follows;
using Recipe.Application.UseCases.Commands.Comments;
using Recipe.Implementation.UseCases.Commands.Comments;
using Recipe.Application.UseCases.Queries.Steps;
using Recipe.Implementation.UseCases.Queries.Steps;
using Recipe.Application.UseCases.Queries.RecipeRatings;
using Recipe.Implementation.UseCases.Queries.RecipeRatings;
using Recipe.Application.UseCases.Queries.Rating;
using Recipe.Implementation.UseCases.Queries.Rating;
using Recipe.Application.UseCases.Queries.Images;
using Recipe.Implementation.UseCases.Queries.Images;
using Recipe.Application.UseCases.Queries.Follows;
using Recipe.Implementation.UseCases.Queries.Follows;
using Recipe.Application.UseCases.Queries.RecipeIngredients;
using Recipe.Implementation.UseCases.Queries.RecipeIngredients;
using Recipe.Application.UseCases.Queries.Comments;
using Recipe.Implementation.UseCases.Queries.Comments;
using Recipe.Application.UseCases.Queries.ErrorLogs;
using Recipe.Implementation.UseCases.Queries.ErrorLogs;

namespace Recipe.API.Core
{
    public static class ContainerExtensions
    {

        public static void AddUseCases(this IServiceCollection services)
        {
            services.AddTransient<CreateUserValidator>();
            services.AddTransient<UpdateUserValidator>();
            services.AddTransient<UpdateUserAdminValidator>();
            services.AddTransient<ChangeStatusUserValidator>();
            services.AddTransient<CreateCategoryValidator>();
            services.AddTransient<DeleteCategoryValidator>();
            services.AddTransient<UpdateCategoryValidator>();
            services.AddTransient<SearchCategoriesByIdValidator>();
            services.AddTransient<CreateIngredientValidator>();
            services.AddTransient<UpdateIngredientValidator>();
            services.AddTransient<DeleteIngredientValidator>();
            services.AddTransient<CreateRecipesValidator>();
            services.AddTransient<UpdateRecipesValidator>();
            services.AddTransient<DeleteRecipeValidator>();
            services.AddTransient<SearchRecipeByIdValidator>();
            services.AddTransient<CreateRecipeIngredientValidator>();
            services.AddTransient<UpdateRecipeIngredientValidator>();
            services.AddTransient<DeleteRecipeIngredientValidator>();
            services.AddTransient<CreateRatingValidator>();
            services.AddTransient<UpdateRatingValidator>();
            services.AddTransient<CreateRecipeRatingsValidator>();
            services.AddTransient<CreateStepValidator>();
            services.AddTransient<UpdateStepValidator>();
            services.AddTransient<CreateImageValidator>();
            services.AddTransient<UpdateImageValidator>();
            services.AddTransient<CreateFollowValidator>();
            services.AddTransient<CreateCommentValidator>();
            services.AddTransient<UpdateCommentValidator>();


            services.AddTransient<UseCaseHandler>();
            services.AddTransient<UpdateUserUseCaseAccessValidator>();
            services.AddTransient<ICreateUserCommand, EfCreateUserCommand>();
            services.AddTransient<IUseCaseLogger, DbUseCaseLogger>();
            services.AddTransient<IUpdateUserUseCaseAccessCommand, EfUpdateUserUseCaseAccessCommand>();
            services.AddTransient<IGetAuditLogQuery, EfGetAuditLogQuery>();
            services.AddTransient<IUpdateUserCommand, EfUpdateUserCommand>();
            services.AddTransient<IUpdateAllUserCommand, EfUpdateAllUserCommand>();
            services.AddTransient<IDeactivateUserCommand, EfDeactivateUserCommand>();
            services.AddTransient<IActivateUserCommand, EfActivateUserCommand>();
            services.AddTransient<IDeleteUserCommand, EfDeleteUSerCommand>();
            services.AddTransient<ICreateCategoryCommand, EfCreateCategoryCommand>();
            services.AddTransient<IGetUsersQuery, EfGetUsersQuery>();
            services.AddTransient<IDeleteCategoryCommand, EfDeleteCategoryCommand>();
            services.AddTransient<IUpdateCategoryCommand, EfUpdateCategoryCommand>();
            services.AddTransient<IGetCategoriesQuery, EfGetCategoriesQuery>();
            services.AddTransient<IGetCategoryWithChildrenByIdQuery, EfGetCategoryWithChildrenByIdQuery>();
            services.AddTransient<ICreateIngredientCommand, EfCreateIngredientCommand>();
            services.AddTransient<IUpdateIngredientCommand, EfUpdateIngredientCommand>();
            services.AddTransient<IDeleteIngredientCommand, EfDeleteIngredientCommand>();
            services.AddTransient<IGetIngredientsQuery, EfGetIngredientsQuery>();
            services.AddTransient<ICreateRecipesCommand, EfCreateRecipesCommand>();
            services.AddTransient<IUpdateRecipeCommand, EfUpdateRecipeCommand>();
            services.AddTransient<IDeleteRecipeCommand, EfDeleteRecipeCommand>();
            services.AddTransient<IGetRecipesByFilterQuery, EfGetRecipesByFilterQuery>();
            services.AddTransient<IGetRecipeByIdQuery, EfGetRecipeByIdQuery>();
            services.AddTransient<ICreateRecipeIngredientCommand, EfCreateRecipeIngredientsCommand>();
            services.AddTransient<IUpdateRecipeIngredientCommand, EfUpdateRecipeIngredientsCommand>();
            services.AddTransient<IDeleteRecipeIngredientCommand, EfDeleteRecipeIngredientCommand>();
            services.AddTransient<ICreateRatingCommand, EfCreateRatingCommand>();
            services.AddTransient<IUpdateRatingCommand, EfUpdateRatingCommand>();
            services.AddTransient<IDeleteRatingCommand, EfDeleteRatingCommand>();
            services.AddTransient<ICreateRecipeRatingsCommand, EfCreateRecipeRatingsCommand>();
            services.AddTransient<IDeleteRecipeRatingsCommand, EfDeleteRecipeRatingsCommand>();
            services.AddTransient<ICreateStepCommand, EfCreateStepsCommand>();
            services.AddTransient<IUpdateStepCommand, EfUpdateStepsCommand>();
            services.AddTransient<IDeleteStepCommand, EfDeleteStepsCommand>();
            services.AddTransient<ICreateImageCommand, EfCreateImagesCommand>();
            services.AddTransient<IUpdateImageCommand, EfUpdateImagesCommand>();
            services.AddTransient<IDeleteImageCommand, EfDeleteImagesCommand>();
            services.AddTransient<ICreateFollowCommand, EfCreateFollowsCommand>();
            services.AddTransient<IDeleteFollowCommand, EfDeleteFollowsCommand>();
            services.AddTransient<IUpdateCommentCommand, EfUpdateCommentsCommand>();
            services.AddTransient<ICreateCommentCommand, EfCreateCommentsCommand>();
            services.AddTransient<IDeleteCommentCommand, EfDeleteCommentsCommand>();
            services.AddTransient<IGetUserUseCasesQuery, EfGetUserUseCasesQuery>();
            services.AddTransient<IGetStepsQuery, EfGetStepsQuery>();
            services.AddTransient<IGetRecipeRatingsQuery, EfGetRecipeRatingsQuery>();
            services.AddTransient<IGetRatingsQuery, EfGetRatingsQuery>();
            services.AddTransient<IGetImagesQuery, EfGetImagesQuery>();
            services.AddTransient<IGetFollowsQuery, EfGetFollowsQuery>();
            services.AddTransient<IGetRecipeIngredientsQuery, EfGetRecipeIngredientsQuery>();
            services.AddTransient<IGetCommentsQuery, EfGetCommentsQuery>();
            services.AddTransient<IGetCommentByIdQuery, EfGetCommentsByIdQuery>();
            services.AddTransient<IGetErrorLogsQuery, EfGetErrorLogsByIdQuery>();

        }

        public static Guid? GetTokenId(this HttpRequest request)
        {
            if (request == null || !request.Headers.ContainsKey("Authorization"))
            {
                return null;
            }

            string authHeader = request.Headers["Authorization"].ToString();

            if (authHeader.Split("Bearer ").Length != 2)
            {
                return null;
            }

            string token = authHeader.Split("Bearer ")[1];

            var handler = new JwtSecurityTokenHandler();

            var tokenObj = handler.ReadJwtToken(token);

            var claims = tokenObj.Claims;

            var claim = claims.First(x => x.Type == "jti").Value;

            var tokenGuid = Guid.Parse(claim);

            return tokenGuid;
        }
    }
}
