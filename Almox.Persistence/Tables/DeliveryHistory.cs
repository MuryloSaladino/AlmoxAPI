using Almox.Domain.Common.Enums;
using Almox.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Almox.Persistence.Tables;

public static class DeliveryHistoryTableConfigurationExtensions
{
    public static void ConfigureDeliveryHistoryTable(this ModelBuilder modelBuilder)
        => modelBuilder.Entity<DeliveryHistory>(entity =>
        {
            entity.ToTable("delivery_histories");

            entity.ConfigureBaseTableProps();

            entity.Property(e => e.UpdatedById)
                .HasColumnName("updated_by_id")
                .IsRequired();
            entity.HasOne(e => e.UpdatedBy)
                .WithMany()
                .HasForeignKey(e => e.UpdatedById);

            entity.Property(e => e.DeliveryId)
                .HasColumnName("delivery_id")
                .IsRequired();
            entity.HasOne(e => e.Delivery)
                .WithMany()
                .HasForeignKey(e => e.DeliveryId);

            entity.Property(e => e.Status)
                .HasColumnName("status")
                .HasColumnType("smallint")
                .HasDefaultValue(DeliveryStatus.Booked)
                .IsRequired();
        });
}
