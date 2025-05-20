using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Almox.Persistence.Context;
using Almox.Persistence.Repository;
using Almox.Persistence.Repository.Users;
using Almox.Application.Repository;
using Almox.Application.Repository.UsersRepository;
using Almox.Application.Repository.CategoriesRepository;
using Almox.Persistence.Repository.Categories;
using Almox.Persistence.Repository.Deliveries;
using Almox.Application.Repository.DeliveriesRepository;
using Almox.Application.Repository.DepartmentsRepository;
using Almox.Persistence.Repository.Departments;
using Almox.Application.Repository.ItemsRepository;
using Almox.Persistence.Repository.Items;
using Almox.Application.Repository.OrdersRepository;
using Almox.Persistence.Config;
using Almox.Persistence.Repository.Orders;
using Almox.Application.Contracts;
using Almox.Persistence.Exceptions;
using Almox.Application.Repository.ImageRepository;
using Almox.Persistence.Repository.Images;

namespace Almox.Persistence;

public static class ServiceExtensions
{
    public static void ConfigurePersistence(this IServiceCollection services)
    {
        var connection = DotEnv.Get("DATABASE_URL");

        services.AddDbContext<AlmoxContext>(opt => opt.UseNpgsql(connection));
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IErrorSummaryExtractor<DbUpdateException>, DbUpdateErrorSummaryExtractor>();

        services.AddScoped<ICategoriesRepository, CategoriesRepository>();
        services.AddScoped<IDeliveriesRepository, DeliveriesRepository>();
        services.AddScoped<IDeliveryItemsRepository, DeliveryItemsRepository>();
        services.AddScoped<IDeliveryHistoryRepository, DeliveryHistoryRepository>();
        services.AddScoped<IDepartmentRepository, DepartmentsRepository>();
        services.AddScoped<IItemsRepository, ItemsRepository>();
        services.AddScoped<IImagesRepository, ImagesRepository>();
        services.AddScoped<IOrdersRepository, OrdersRepository>();
        services.AddScoped<IOrderHistoryRepository, OrderHistoryRepository>();
        services.AddScoped<IOrderItemsRepository, OrderItemsRepository>();
        services.AddScoped<IUsersRepository, UserRepository>();
    }
}