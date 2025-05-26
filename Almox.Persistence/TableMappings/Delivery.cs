using Almox.Domain.Common.Enums;
using Almox.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Almox.Persistence.TableMappings;

public class DeliveryConfiguration : BaseEntityConfiguration<Delivery>
{
    public override void Configure(EntityTypeBuilder<Delivery> builder)
    {
        base.Configure(builder);

        builder.ToTable("deliveries");

        builder.Property(d => d.Supplier)
            .HasColumnName("supplier")
            .HasColumnType("varchar(35)")
            .IsRequired();

        builder.Property(d => d.Tracking)
            .HasColumnName("tracking")
            .HasColumnType("char(16)")
            .IsRequired();

        builder.Property(d => d.ExpectedDate)
            .HasColumnName("expected_date")
            .HasColumnType("timestamptz")
            .IsRequired();

        builder.Property(d => d.Status)
            .HasColumnName("status")
            .HasColumnType("smallint")
            .IsRequired();

        builder.HasMany(d => d.DeliveryItems)
            .WithOne()
            .HasForeignKey(di => di.DeliveryId);

        builder.HasMany(d => d.StatusUpdates)
            .WithOne()
            .HasForeignKey(su => su.DeliveryId);
    }
}
