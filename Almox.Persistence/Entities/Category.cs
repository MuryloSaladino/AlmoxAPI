using Almox.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Almox.Persistence.Entities;

public static class CategoryEntityCreationExtensions
{
    public static void ConfigureCategoryEntity(this ModelBuilder modelBuilder)
        =>  modelBuilder.Entity<Category>(entity =>
        {
            entity.ConfigureBaseEntityProps();

            entity.HasMany(c => c.Items)
                .WithMany(i => i.Categories);

            entity.Property(e => e.Name)
                .HasColumnType("VARCHAR(35)")
                .IsRequired();

            entity.Property(e => e.Description)
                .HasColumnType("VARCHAR(255)")
                .IsRequired();
        });
}
