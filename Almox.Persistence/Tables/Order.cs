using Almox.Domain.Common.Enums;
using Almox.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Almox.Persistence.Tables;

public static class OrderTableConfigurationExtensions
{
    public static void ConfigureOrderTable(this ModelBuilder modelBuilder)
        => modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("orders");

            entity.ConfigureBaseTableProps();

            entity.Property(e => e.UserId)
                .HasColumnName("user_id")
                .IsRequired();
            entity.HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId);

            entity.HasMany(e => e.OrderItems)
                .WithOne()
                .HasForeignKey(ri => ri.OrderId);

            entity.HasMany(e => e.History)
                .WithOne()
                .HasForeignKey(h => h.OrderId);

            entity.Property(e => e.Priority)
                .HasColumnName("priority")
                .HasColumnType("smallint")
                .HasDefaultValue(OrderPriority.Irrelevant);
            
            entity.Property(e => e.Observations)
                .HasColumnName("observations")
                .HasColumnType("varchar(255)");

            entity.Property(e => e.Status)
                .HasColumnName("status")
                .HasColumnType("smallint");
        });
}
