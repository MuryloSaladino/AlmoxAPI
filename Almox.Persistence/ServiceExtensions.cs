using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Almox.Application.Config;
using Almox.Domain.Repository;
using Almox.Domain.Repository.AlmoxRepository;
using Almox.Domain.Repository.UsersRepository;
using Almox.Persistence.Context;
using Almox.Persistence.Repository;
using Almox.Persistence.Repository.Almox;
using Almox.Persistence.Repository.Users;

namespace Almox.Persistence;

public static class ServiceExtensions
{
    public static void ConfigurePersistence(this IServiceCollection services)
    {
        var connection = DotEnv.Get("DATABASE_URL");

        services.AddDbContext<AlmoxContext>(opt => opt.UseNpgsql(connection));
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IUsersRepository, UserRepository>();
        services.AddScoped<IAlmoxRepository, SkillRepository>();
    }
}