using Almox.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Almox.Persistence.Tables;

public static class RequestItemTableConfigurationExtensions
{
    public static void ConfigureRequestItemTable(this ModelBuilder modelBuilder)
        => modelBuilder.Entity<RequestItem>(entity =>
        {
            entity.ToTable("request_items");

            entity.HasKey(e => new { e.ItemId, e.RequestId });

            entity.Property(e => e.RequestId)
                .HasColumnName("request_id")
                .IsRequired();
            entity.Property(e => e.ItemId)
                .HasColumnName("item_id")
                .IsRequired();

            entity.HasOne(e => e.Request)
                .WithMany(d => d.RequestItems)
                .HasForeignKey(e => e.RequestId);
            
            entity.HasOne(e => e.Item)
                .WithMany()
                .HasForeignKey(e => e.ItemId);

            entity.Property(e => e.Quantity)
                .HasColumnName("quantity")
                .HasColumnType("int")
                .IsRequired();

            entity.Property(e => e.FulfilledQuantity)
                .HasColumnName("fulfilled_quantity")
                .HasColumnType("int");
        });
}
