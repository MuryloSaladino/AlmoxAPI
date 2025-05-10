using Almox.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Almox.Persistence.Entities;

public static class RequestItemEntityCreationExtensions
{
    public static void ConfigureRequestItemEntity(this ModelBuilder modelBuilder)
        => modelBuilder.Entity<RequestItem>(entity =>
        {
            entity.HasKey(e => new { e.ItemId, e.RequestId });

            entity.Property(e => e.RequestId)
                .IsRequired();
            entity.Property(e => e.ItemId)
                .IsRequired();

            entity.HasOne(e => e.Request)
                .WithMany(d => d.RequestItems)
                .HasForeignKey(e => e.RequestId);
            
            entity.HasOne(e => e.Item)
                .WithMany()
                .HasForeignKey(e => e.ItemId);

            entity.Property(e => e.Quantity)
                .HasColumnType("INT")
                .IsRequired();

            entity.Property(e => e.FulfilledQuantity)
                .HasColumnType("INT");
        });
}
