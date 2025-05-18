using Almox.Domain.Common.Enums;
using Almox.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Almox.Persistence.Tables;

public static class RequestHistoryTableConfigurationExtensions
{
    public static void ConfigureRequestHistoryTable(this ModelBuilder modelBuilder)
        => modelBuilder.Entity<RequestHistory>(entity =>
        {
            entity.ToTable("request_histories");

            entity.ConfigureBaseTableProps();

            entity.Property(e => e.UpdatedById)
                .HasColumnName("updated_by_id")
                .IsRequired();
            entity.HasOne(e => e.UpdatedBy)
                .WithMany()
                .HasForeignKey(e => e.UpdatedById);

            entity.Property(e => e.RequestId)
                .HasColumnName("request_id")
                .IsRequired();
            entity.HasOne(e => e.Request)
                .WithMany()
                .HasForeignKey(e => e.RequestId);

            entity.Property(e => e.Status)
                .HasColumnName("status")
                .HasColumnType("smallint")
                .HasDefaultValue(RequestStatus.Draft)
                .IsRequired();
        });
}
