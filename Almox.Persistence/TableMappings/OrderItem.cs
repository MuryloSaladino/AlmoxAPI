using Almox.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Almox.Persistence.TableMappings;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.ToTable("order_items");

        builder.HasKey(oi => new { oi.ItemId, oi.OrderId });

        builder.Property(oi => oi.OrderId)
            .HasColumnName("order_id")
            .IsRequired();
        builder.Navigation(oi => oi.Item)
            .AutoInclude();

        builder.Property(oi => oi.ItemId)
            .HasColumnName("item_id")
            .IsRequired();

        builder.Property(oi => oi.Quantity)
            .HasColumnName("quantity")
            .HasColumnType("int")
            .IsRequired();
        
        builder.Property(oi => oi.Price)
            .HasColumnName("price")
            .HasColumnType("decimal(10,2)")
            .IsRequired();
    }
}
