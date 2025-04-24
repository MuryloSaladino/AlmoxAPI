using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Almox.Application.Services;
using Almox.Domain.Common;
using Almox.Domain.Contracts;
using Almox.Domain.Entities;

namespace Almox.Application;

public static class ServiceExtensions
{
    public static void ConfigureApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        services.AddHttpContextAccessor();
        services.AddScoped(provider =>
        {
            var httpContextAccessor = provider.GetRequiredService<IHttpContextAccessor>();
            var context = httpContextAccessor.HttpContext;

            if (context?.Items["UserSession"] is UserSession session)
                return session;

            return new UserSession("Anonymous", null); 
        });

        services.AddScoped<IAuthenticator, AuthenticationService>();
        services.AddScoped<IPasswordEncrypter, PasswordEncrypterService>();
    }
}
