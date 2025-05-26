using Almox.Domain.Common.Enums;
using Almox.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Almox.Persistence.TableMappings;

public class OrderConfiguration : BaseEntityConfiguration<Order>
{
    public override void Configure(EntityTypeBuilder<Order> builder)
    {
        base.Configure(builder);

        builder.ToTable("orders");

        builder.Property(o => o.UserId)
            .HasColumnName("user_id")
            .IsRequired();

        builder.Property(o => o.Tracking)
            .HasColumnName("tracking")
            .HasColumnType("char(16)")
            .IsRequired();

        builder.Property(o => o.Priority)
            .HasColumnName("priority")
            .HasColumnType("smallint")
            .IsRequired();

        builder.Property(o => o.Status)
            .HasColumnName("status")
            .HasColumnType("smallint");

        builder.Property(o => o.Observations)
            .HasColumnName("observations")
            .HasColumnType("varchar(255)");
            
        builder.HasMany(o => o.OrderItems)
            .WithOne()
            .HasForeignKey(oi => oi.OrderId);

        builder.HasMany(o => o.StatusUpdates)
            .WithOne()
            .HasForeignKey(su => su.OrderId);
    }
}
