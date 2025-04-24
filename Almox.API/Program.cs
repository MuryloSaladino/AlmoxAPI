using Almox.API.Extensions;
using Almox.API.Middlewares.Authenticate;
using Almox.API.Middlewares.Authorize;
using Almox.Application;
using Almox.Application.Config;
using Almox.Persistence;
using Almox.Persistence.Context;

DotEnv.Load();

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigurePersistence();
builder.Services.ConfigureApplication();

builder.Services.ConfigureCorsPolicy();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

var serviceScope = app.Services.CreateScope();
var dataContext = serviceScope.ServiceProvider.GetService<AlmoxContext>();
dataContext?.Database.EnsureCreated();

app.UseMiddleware<AuthenticationMiddleware>();
app.UseMiddleware<AuthorizationMiddleware>();

app.UseSwagger();
app.UseSwaggerUI();
app.UseCors();
app.UserErrorHandler();
app.MapControllers();
app.Run();
