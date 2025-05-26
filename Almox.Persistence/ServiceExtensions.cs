using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Almox.Persistence.Context;
using Almox.Persistence.Repository;
using Almox.Persistence.Repository.Users;
using Almox.Application.Repository;
using Almox.Application.Repository.Users;
using Almox.Application.Repository.Categories;
using Almox.Persistence.Repository.Categories;
using Almox.Persistence.Repository.Deliveries;
using Almox.Application.Repository.Deliveries;
using Almox.Application.Repository.Departments;
using Almox.Persistence.Repository.Departments;
using Almox.Application.Repository.Items;
using Almox.Persistence.Repository.Items;
using Almox.Application.Repository.Orders;
using Almox.Persistence.Repository.Orders;
using Almox.Persistence.Exceptions;
using Almox.Application.Repository.Images;
using Almox.Persistence.Repository.Images;
using Microsoft.IdentityModel.Protocols.Configuration;
using Almox.Application.Contracts;

namespace Almox.Persistence;

public static class ServiceExtensions
{
    public static void ConfigurePersistence(this IServiceCollection services)
    {
        var connection = Environment.GetEnvironmentVariable("DATABASE_URL")
            ?? throw new InvalidConfigurationException("The environment needs \"DATABASE_URL\" variable");

        services.AddDbContext<AlmoxContext>(opt => opt.UseNpgsql(connection));
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IExceptionDataExtractor<DbUpdateException>, DbUpdateExceptionDataExtractor>();

        services.AddScoped<ICategoriesRepository, CategoriesRepository>();
        services.AddScoped<IDeliveriesRepository, DeliveriesRepository>();
        services.AddScoped<IDeliveryItemsRepository, DeliveryItemsRepository>();
        services.AddScoped<IDeliveryStatusUpdatesRepository, DeliveryStatusUpdateRepository>();
        services.AddScoped<IDepartmentRepository, DepartmentsRepository>();
        services.AddScoped<IImagesRepository, ImagesRepository>();
        services.AddScoped<IItemsRepository, ItemsRepository>();
        services.AddScoped<IOrdersRepository, OrdersRepository>();
        services.AddScoped<IOrderItemsRepository, OrderItemsRepository>();
        services.AddScoped<IOrderStatusUpdatesRepository, OrderStatusUpdateRepository>();
        services.AddScoped<IUsersRepository, UserRepository>();
    }
}