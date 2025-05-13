using Microsoft.EntityFrameworkCore;
using Almox.Persistence.Entities;

namespace Almox.Persistence.Context;

public class AlmoxContext(DbContextOptions<AlmoxContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureCategoryEntity();
        modelBuilder.ConfigureDeliveryEntity();
        modelBuilder.ConfigureDeliveryItemEntity();
        modelBuilder.ConfigureDepartmentEntity();
        modelBuilder.ConfigureItemEntity();
        modelBuilder.ConfigureRequestEntity();
        modelBuilder.ConfigureRequestItemEntity();
        modelBuilder.ConfigureUserEntity();
    }
}