using Microsoft.EntityFrameworkCore;
using Almox.Persistence.Tables;

namespace Almox.Persistence.Context;

public class AlmoxContext(DbContextOptions<AlmoxContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureCategoryTable();
        modelBuilder.ConfigureDeliveryTable();
        modelBuilder.ConfigureDeliveryItemTable();
        modelBuilder.ConfigureDeliveryHistoryTable();
        modelBuilder.ConfigureDepartmentTable();
        modelBuilder.ConfigureItemTable();
        modelBuilder.ConfigureOrderTable();
        modelBuilder.ConfigureOrderItemTable();
        modelBuilder.ConfigureOrderHistoryTable();
        modelBuilder.ConfigureUserTable();
    }
}