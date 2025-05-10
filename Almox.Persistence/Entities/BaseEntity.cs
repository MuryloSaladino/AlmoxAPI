using Almox.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Almox.Persistence.Entities;

public static class BaseEntityConfigurationExtensions
{
    public static void ConfigureBaseEntityProps<T>(this EntityTypeBuilder<T> builder) 
        where T : BaseEntity
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .IsRequired();

        builder.Property(e => e.CreatedAt)
            .HasColumnType("TIMESTAMPTZ")
            .IsRequired();

        builder.Property(e => e.UpdatedAt)
            .HasColumnType("TIMESTAMPTZ");

        builder.Property(e => e.DeletedAt)
            .HasColumnType("TIMESTAMPTZ");
    }
}