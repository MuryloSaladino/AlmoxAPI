using Almox.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Almox.Persistence.Entities;

public static class DeliveryItemEntityCreationExtensions
{
    public static void ConfigureDeliveryItemEntity(this ModelBuilder modelBuilder)
        => modelBuilder.Entity<DeliveryItem>(entity =>
        {
            entity.HasKey(e => new { e.ItemId, e.DeliveryId });

            entity.Property(e => e.DeliveryId)
                .IsRequired();
            entity.Property(e => e.ItemId)
                .IsRequired();

            entity.HasOne(e => e.Delivery)
                .WithMany(d => d.DeliveryItems)
                .HasForeignKey(e => e.DeliveryId);
            
            entity.HasOne(e => e.Item)
                .WithMany()
                .HasForeignKey(e => e.ItemId);

            entity.Property(e => e.Quantity)
                .HasColumnType("INT")
                .IsRequired();
        });
}
