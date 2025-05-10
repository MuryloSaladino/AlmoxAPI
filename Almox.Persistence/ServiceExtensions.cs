using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Almox.Application.Config;
using Almox.Persistence.Context;
using Almox.Persistence.Repository;
using Almox.Persistence.Repository.Users;
using Almox.Application.Repository;
using Almox.Application.Repository.UsersRepository;
using Almox.Application.Repository.ActionLogsRepository;
using Almox.Persistence.Repository.ActionLogs;
using Almox.Application.Repository.CategoriesRepository;
using Almox.Persistence.Repository.Categories;
using Almox.Persistence.Repository.Deliveries;
using Almox.Application.Repository.DeliveriesRepository;
using Almox.Application.Repository.DeliveryItemsRepository;
using Almox.Application.Repository.DepartmentsRepository;
using Almox.Persistence.Repository.Departments;
using Almox.Application.Repository.ItemsRepository;
using Almox.Persistence.Repository.Items;
using Almox.Application.Repository.RequestsRepository;
using Almox.Persistence.Repository.Requests;
using Almox.Application.Repository.RequestItemsRepository;

namespace Almox.Persistence;

public static class ServiceExtensions
{
    public static void ConfigurePersistence(this IServiceCollection services)
    {
        var connection = DotEnv.Get("DATABASE_URL");

        services.AddDbContext<AlmoxContext>(opt => opt.UseNpgsql(connection));
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IActionLogsRepository, ActionLogsRepository>();
        services.AddScoped<ICategoriesRepository, CategoriesRepository>();
        services.AddScoped<IDeliveriesRepository, DeliveriesRepository>();
        services.AddScoped<IDeliveryItemsRepository, DeliveryItemsRepository>();
        services.AddScoped<IDepartmentRepository, DepartmentsRepository>();
        services.AddScoped<IItemsRepository, ItemsRepository>();
        services.AddScoped<IRequestsRepository, RequestsRepository>();
        services.AddScoped<IRequestItemsRepository, RequestItemsRepository>();
        services.AddScoped<IUsersRepository, UserRepository>();
    }
}