using Almox.Domain.Common.Enums;
using Almox.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Almox.Persistence.Tables;

public static class RequestTableConfigurationExtensions
{
    public static void ConfigureRequestTable(this ModelBuilder modelBuilder)
        => modelBuilder.Entity<Request>(entity =>
        {
            entity.ToTable("requests");

            entity.ConfigureBaseTableProps();

            entity.Property(e => e.UserId)
                .HasColumnName("user_id")
                .IsRequired();
            entity.HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId);

            entity.HasMany(e => e.RequestItems)
                .WithOne(ri => ri.Request)
                .HasForeignKey(ri => ri.RequestId);

            entity.Property(e => e.Priority)
                .HasColumnName("priority")
                .HasColumnType("smallint")
                .HasDefaultValue(RequestPriority.Irrelevant);
            
            entity.Property(e => e.Observations)
                .HasColumnName("observations")
                .HasColumnType("varchar(255)");

            entity.Property(e => e.Status)
                .HasColumnName("status")
                .HasColumnType("smallint")
                .HasDefaultValue(RequestStatus.Draft)
                .IsRequired();
        });
}
