using Almox.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Almox.Persistence.Entities;

public static class ItemEntityCreationExtensions
{
    public static void ConfigureItemEntity(this ModelBuilder modelBuilder)
        => modelBuilder.Entity<Item>(entity =>
        {
            entity.ToTable("items");

            entity.ConfigureBaseEntityProps();

            entity.Property(e => e.Name)
                .HasColumnName("name")
                .HasColumnType("varchar(50)")
                .IsRequired();
            entity.HasIndex(e => e.Name)
                .IsUnique();

            entity.Property(e => e.Quantity)
                .HasColumnName("quantity")
                .HasColumnType("int")
                .HasDefaultValue(0);
        });
}
