using Almox.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Almox.Persistence.TableMappings;

public class DeliveryItemConfiguration : IEntityTypeConfiguration<DeliveryItem>
{
    public void Configure(EntityTypeBuilder<DeliveryItem> builder)
    {
        builder.ToTable("delivery_items");

        builder.HasKey(di => new { di.ItemId, di.DeliveryId });

        builder.Property(di => di.DeliveryId)
            .HasColumnName("delivery_id")
            .IsRequired();

        builder.Property(di => di.ItemId)
            .HasColumnName("item_id")
            .IsRequired();

        builder.Property(di => di.Quantity)
            .HasColumnName("quantity")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(di => di.SupplierPrice)
            .HasColumnName("supplier_price")
            .HasColumnType("decimal(10,2)")
            .IsRequired();
    }
}
