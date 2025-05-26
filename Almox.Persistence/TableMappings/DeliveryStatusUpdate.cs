using Almox.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Almox.Persistence.TableMappings;

public class DeliveryStatusUpdateConfiguration : IEntityTypeConfiguration<DeliveryStatusUpdate>
{
    public void Configure(EntityTypeBuilder<DeliveryStatusUpdate> builder)
    {
        builder.ToTable("delivery_status_updates");

        builder.Property(dsu => dsu.UpdatedById)
            .HasColumnName("updated_by_id")
            .IsRequired();

        builder.Property(dsu => dsu.DeliveryId)
            .HasColumnName("delivery_id")
            .IsRequired();

        builder.Property(dsu => dsu.UpdatedAt)
            .HasColumnName("updated_at")
            .HasColumnType("timestamptz")
            .IsRequired();

        builder.Property(dsu => dsu.Status)
            .HasColumnName("status")
            .HasColumnType("smallint")
            .IsRequired();

        builder.Property(dsu => dsu.Observations)
            .HasColumnName("observations")
            .HasColumnType("varchar(255)");
    }
}
