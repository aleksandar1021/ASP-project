using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using Recipe.API;
using Recipe.API.Core;
using Recipe.Application;
using Recipe.Application.DTO;
using Recipe.Application.UseCases.Commands.Categories;
using Recipe.Application.UseCases.Commands.Ingredients;
using Recipe.Application.UseCases.Commands.RecipeIngredients;
using Recipe.Application.UseCases.Commands.Recipes;
using Recipe.Application.UseCases.Commands.Users;
using Recipe.Application.UseCases.Queries.AuditLogs;
using Recipe.Application.UseCases.Queries.Categories;
using Recipe.Application.UseCases.Queries.Ingredients;
using Recipe.Application.UseCases.Queries.Recipes;
using Recipe.Application.UseCases.Queries.Users;
using Recipe.DataAccess;
using Recipe.Domain;
using Recipe.Implementation;
using Recipe.Implementation.Logging.UseCases;
using Recipe.Implementation.UseCases.Commands.Categories;
using Recipe.Implementation.UseCases.Commands.Ingredients;
using Recipe.Implementation.UseCases.Commands.RecipeIngredients;
using Recipe.Implementation.UseCases.Commands.Recipes;
using Recipe.Implementation.UseCases.Commands.Users;
using Recipe.Implementation.UseCases.Queries.AuditLog;
using Recipe.Implementation.UseCases.Queries.Categories;
using Recipe.Implementation.UseCases.Queries.Ingredients;
using Recipe.Implementation.UseCases.Queries.Recipes;
using Recipe.Implementation.UseCases.Queries.Users;
using Recipe.Implementation.Validators;
using System.Data;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var settings = new AppSettings();
builder.Configuration.Bind(settings);

builder.Services.AddSingleton(settings.Jwt);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddTransient<RecipeContext>(x => new RecipeContext(settings.ConnectionString));
builder.Services.AddScoped<IDbConnection>(x => new SqlConnection(settings.ConnectionString));

builder.Services.AddTransient<JwtTokenCreator>();

builder.Services.AddUseCases();

builder.Services.AddHttpContextAccessor();

builder.Services.AddTransient<IExceptionLogger, DbExceptionHandler>();
builder.Services.AddTransient<ITokenStorage, InMemoryTokenStorage>();

builder.Services.AddTransient<IApplicationActorProvider>(x =>
{
    var accessor = x.GetService<IHttpContextAccessor>();

    var request = accessor.HttpContext.Request;

    var authHeader = request.Headers.Authorization.ToString();

    var context = x.GetService<RecipeContext>();

    return new JwtApplicationActorProvider(authHeader);
});
builder.Services.AddTransient<IApplicationActor>(x =>
{
    var accessor = x.GetService<IHttpContextAccessor>();
    if (accessor.HttpContext == null)
    {
        return new UnauthorizedActor();
    }

    return x.GetService<IApplicationActorProvider>().GetActor();
});



builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(cfg =>
{
    cfg.RequireHttpsMetadata = false;
    cfg.SaveToken = true;
    cfg.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = settings.Jwt.Issuer,
        ValidateIssuer = true,
        ValidAudience = "Any",
        ValidateAudience = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.Jwt.SecretKey)),
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
    cfg.Events = new JwtBearerEvents
    {
        OnTokenValidated = context =>
        {
         

            Guid tokenId = context.HttpContext.Request.GetTokenId().Value;

            var storage = builder.Services.BuildServiceProvider().GetService<ITokenStorage>();

            if (!storage.Exists(tokenId))
            {
                context.Fail("Invalid token");
            }


            return Task.CompletedTask;

        }
    };
});



var app = builder.Build();

app.UseMiddleware<GlobalExcenpionMiddlewareHandling>();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.UseStaticFiles();

app.Run();