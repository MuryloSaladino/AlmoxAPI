using Almox.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Almox.Persistence.Tables;

public static class DeliveryItemTableConfigurationExtensions
{
    public static void ConfigureDeliveryItemTable(this ModelBuilder modelBuilder)
        => modelBuilder.Entity<DeliveryItem>(entity =>
        {
            entity.ToTable("delivery_items");

            entity.HasKey(e => new { e.ItemId, e.DeliveryId });

            entity.Property(e => e.DeliveryId)
                .HasColumnName("delivery_id")
                .IsRequired();
            entity.Property(e => e.ItemId)
                .HasColumnName("item_id")
                .IsRequired();

            entity.HasOne(e => e.Delivery)
                .WithMany(d => d.DeliveryItems)
                .HasForeignKey(e => e.DeliveryId);
            
            entity.HasOne(e => e.Item)
                .WithMany()
                .HasForeignKey(e => e.ItemId);

            entity.Property(e => e.Quantity)
                .HasColumnName("quantity")
                .HasColumnType("int")
                .IsRequired();
        });
}
