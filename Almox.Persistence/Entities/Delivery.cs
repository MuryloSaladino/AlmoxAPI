using Almox.Domain.Entities;
using Almox.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Almox.Persistence.Entities;

public static class DeliveryEntityCreationExtensions
{
    public static void ConfigureDeliveryEntity(this ModelBuilder modelBuilder)
        => modelBuilder.Entity<Delivery>(entity => 
        {
            entity.ConfigureBaseEntityProps();

            entity.Property(e => e.UserId)
                .IsRequired();
            entity.HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId);

            entity.HasMany(e => e.DeliveryItems)
                .WithOne()
                .HasForeignKey(di => di.DeliveryId);

            entity.Property(e => e.Observations)
                .HasColumnType("TEXT");

            entity.Property(e => e.Date)
                .HasColumnType("TIMESTAMP")
                .IsRequired();

            entity.Property(e => e.Status)
                .HasDefaultValue(Status.DRAFT)
                .IsRequired();
        });
}
