using System.Reflection;
using Almox.Application.Common.Behaviors;
using Almox.Application.Common.Exceptions;
using Almox.Application.Contracts;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Almox.Application;

public static class ServiceExtensions
{
    public static void ConfigureApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        services.AddScoped<IExceptionDataExtractor<AppException>, AppExceptionExtractor>();
    }
}
