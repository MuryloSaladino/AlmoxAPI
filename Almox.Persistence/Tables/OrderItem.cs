using Almox.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Almox.Persistence.Tables;

public static class OrderItemTableConfigurationExtensions
{
    public static void ConfigureOrderItemTable(this ModelBuilder modelBuilder)
        => modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.ToTable("order_items");

            entity.HasKey(e => new { e.ItemId, e.OrderId });

            entity.Property(e => e.OrderId)
                .HasColumnName("order_id")
                .IsRequired();
            entity.Property(e => e.ItemId)
                .HasColumnName("item_id")
                .IsRequired();

            entity.HasOne(e => e.Order)
                .WithMany(d => d.OrderItems)
                .HasForeignKey(e => e.OrderId);
            
            entity.HasOne(e => e.Item)
                .WithMany()
                .HasForeignKey(e => e.ItemId);

            entity.Property(e => e.Quantity)
                .HasColumnName("quantity")
                .HasColumnType("int")
                .IsRequired();

            entity.Property(e => e.Observations)
                .HasColumnName("observations")
                .HasColumnType("varchar(255)");

            entity.Property(e => e.FulfilledQuantity)
                .HasColumnName("fulfilled_quantity")
                .HasColumnType("int");
        });
}
