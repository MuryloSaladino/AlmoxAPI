using Almox.API.Services;
using Almox.Application;
using Almox.Application.Contracts;
using Almox.Persistence;
using Almox.Persistence.Context;
using Almox.Application.Common.Session;
using System.Text.Json.Serialization;
using Almox.Persistence.Seeding;
using Almox.API.Middlewares;
using Microsoft.AspNetCore.Http.Features;
using dotenv.net;
using Almox.API.Security.Config;
using Almox.API.Security.Filters;

DotEnv.Load(options: new DotEnvOptions(envFilePaths: ["../.env"]));

var builder = WebApplication.CreateBuilder(args);

// LAYERS CONFIG
builder.Services.ConfigurePersistence();
builder.Services.ConfigureApplication();

// CORS
builder.Services.ConfigureCorsPolicy();

// CONTROLLERS AND OPTIONS
builder.Services.AddControllers(op =>
{
    op.Filters.Add<AuthorizationFilter>();
}).AddJsonOptions(op =>
{
    op.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    op.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 104857600; // 100MB
});

// SWAGGER
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// SERVICES INJECTION
builder.Services.AddScoped<IRequestSession, RequestSession>();
builder.Services.AddScoped<IAuthenticator, AuthenticationService>();
builder.Services.AddScoped<IPasswordEncrypter, PasswordEncrypterService>();


var app = builder.Build();

// DATABASE SETUP WITH SEEDING
var serviceScope = app.Services.CreateScope();
var dataContext = serviceScope.ServiceProvider.GetService<AlmoxContext>()
    ?? throw new InvalidOperationException("Failed to resolve AlmoxContext from service provider.");
dataContext.Database.EnsureCreated();
await dataContext.SeedData();

app.UseSwagger();
app.UseSwaggerUI();
app.UseCors();
app.UseErrorHandler();
app.MapControllers();
app.Run();
