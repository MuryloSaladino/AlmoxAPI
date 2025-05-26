using Almox.API.Services;
using Almox.API.Security;
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

DotEnv.Load(options: new DotEnvOptions(envFilePaths: ["../.env"]));

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigurePersistence();
builder.Services.ConfigureApplication();
builder.Services.ConfigureCorsPolicy();

builder.Services.AddControllers().AddJsonOptions(op =>
{
    op.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    op.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 104857600; // 100MB
});
    
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRequestSession, RequestSession>();
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
app.UseErrorHandler();
app.MapControllers();
app.Run();
