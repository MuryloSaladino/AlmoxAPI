using Almox.API.Extensions;
using Almox.API.Middlewares.Authenticate;
using Almox.API.Services;
using Almox.API.Security.Session;
using Almox.Application;
using Almox.Application.Config;
using Almox.Application.Contracts;
using Almox.Persistence;
using Almox.Persistence.Context;
using Almox.Application.Common.Session;
using System.Text.Json.Serialization;
using Almox.Persistence.Seeding;

DotEnv.Load();

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigurePersistence();
builder.Services.ConfigureApplication();

builder.Services.ConfigureCorsPolicy();

builder.Services
    .AddControllers()
    .AddJsonOptions(options => options
        .JsonSerializerOptions
        .Converters
        .Add(new JsonStringEnumConverter())
    );
    
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserSession, UserSession>();
builder.Services.AddScoped<IAuthenticator, AuthenticationService>();
builder.Services.AddScoped<IPasswordEncrypter, PasswordEncrypterService>();


var app = builder.Build();

var serviceScope = app.Services.CreateScope();
var dataContext = serviceScope.ServiceProvider.GetService<AlmoxContext>()
    ?? throw new InvalidOperationException("Failed to resolve AlmoxContext from service provider.");

dataContext.Database.EnsureCreated();
await dataContext.SeedData();

app.UseMiddleware<AuthenticateMiddleware>();

app.UseSwagger();
app.UseSwaggerUI();
app.UseCors();
app.UserErrorHandler();
app.MapControllers();
app.Run();
