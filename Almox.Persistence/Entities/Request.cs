using Almox.Domain.Entities;
using Almox.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Almox.Persistence.Entities;

public static class RequestEntityCreationExtensions
{
    public static void ConfigureRequestEntity(this ModelBuilder modelBuilder)
        => modelBuilder.Entity<Request>(entity =>
        {
            entity.ConfigureBaseEntityProps();

            entity.Property(e => e.UserId)
                .IsRequired();
            entity.HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId);

            entity.HasMany(e => e.RequestItems)
                .WithOne(ri => ri.Request)
                .HasForeignKey(ri => ri.RequestId);

            entity.Property(e => e.Priority)
                .HasColumnType("SMALLINT")
                .HasDefaultValue(1);
            
            entity.Property(e => e.Observations)
                .HasColumnType("VARCHAR(255)");

            entity.Property(e => e.Status)
                .HasDefaultValue(Status.DRAFT)
                .IsRequired();
        });
}
