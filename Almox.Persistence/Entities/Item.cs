using Almox.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Almox.Persistence.Entities;

public static class ItemEntityCreationExtensions
{
    public static void ConfigureItemEntity(this ModelBuilder modelBuilder)
        => modelBuilder.Entity<Item>(entity =>
        {
            entity.ConfigureBaseEntityProps();

            entity.HasMany(e => e.Categories)
                .WithMany(c => c.Items);
            
            entity.Property(e => e.Name)
                .HasColumnType("VARCHAR(50)")
                .IsRequired();
            
            entity.Property(e => e.Quantity)
                .HasColumnType("INT")
                .HasDefaultValue(0);
        });
}
