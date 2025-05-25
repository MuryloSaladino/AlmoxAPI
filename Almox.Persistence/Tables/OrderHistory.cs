using Almox.Domain.Common.Enums;
using Almox.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Almox.Persistence.Tables;

public static class OrderHistoryTableConfigurationExtensions
{
    public static void ConfigureOrderHistoryTable(this ModelBuilder modelBuilder)
        => modelBuilder.Entity<OrderHistory>(entity =>
        {
            entity.ToTable("order_histories");

            entity.ConfigureBaseTableProps();

            entity.Property(e => e.UpdatedById)
                .HasColumnName("updated_by_id")
                .IsRequired();
            entity.HasOne(e => e.UpdatedBy)
                .WithMany()
                .HasForeignKey(e => e.UpdatedById);

            entity.Property(e => e.OrderId)
                .HasColumnName("order_id")
                .IsRequired();
            entity.HasOne(e => e.Order)
                .WithMany(o => o.History)
                .HasForeignKey(e => e.OrderId);

            entity.Property(e => e.Status)
                .HasColumnName("status")
                .HasColumnType("smallint")
                .IsRequired();
        });
}
