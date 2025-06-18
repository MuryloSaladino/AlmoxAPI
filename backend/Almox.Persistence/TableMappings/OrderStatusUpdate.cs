using Almox.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Almox.Persistence.TableMappings;

public class OrderStatusUpdateConfiguration : IEntityTypeConfiguration<OrderStatusUpdate>
{
    public void Configure(EntityTypeBuilder<OrderStatusUpdate> builder)
    {
        builder.ToTable("order_status_updates");

        builder.HasKey(osu => new { osu.OrderId, osu.Status });

        builder.Property(osu => osu.OrderId)
            .HasColumnName("order_id")
            .IsRequired();

        builder.Property(osu => osu.UpdatedById)
            .HasColumnName("updated_by_id")
            .IsRequired();

        builder.Property(osu => osu.UpdatedAt)
            .HasColumnName("updated_at")
            .HasColumnType("timestamptz")
            .IsRequired();

        builder.Property(osu => osu.Status)
            .HasColumnName("status")
            .HasColumnType("smallint")
            .IsRequired();

        builder.Property(osu => osu.Observations)
            .HasColumnName("observations")
            .HasColumnType("varchar(255)");
    }
}
