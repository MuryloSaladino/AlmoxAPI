using Almox.Domain.Common.Enums;
using Almox.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Almox.Persistence.Tables;

public static class DeliveryTableConfigurationExtensions
{
    public static void ConfigureDeliveryTable(this ModelBuilder modelBuilder)
        => modelBuilder.Entity<Delivery>(entity => 
        {
            entity.ToTable("deliveries");

            entity.ConfigureBaseTableProps();

            entity.Property(e => e.UserId)
                .HasColumnName("user_id")
                .IsRequired();
            entity.HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId);

            entity.HasMany(e => e.DeliveryItems)
                .WithOne()
                .HasForeignKey(di => di.DeliveryId);

            entity.Property(e => e.Observations)
                .HasColumnName("observations")
                .HasColumnType("text");

            entity.Property(e => e.Date)
                .HasColumnName("date")
                .HasColumnType("timestamptz")
                .IsRequired();

            entity.Property(e => e.Status)
                .HasColumnName("status")
                .HasColumnType("smallint")
                .HasDefaultValue(DeliveryStatus.Booked)
                .IsRequired();
        });
}
