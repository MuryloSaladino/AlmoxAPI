using Almox.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Almox.Persistence.Entities;

public static class CategoryEntityCreationExtensions
{
    public static void ConfigureCategoryEntity(this ModelBuilder modelBuilder)
        =>  modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("categories");

            entity.ConfigureBaseEntityProps();

            entity.HasMany(c => c.Items)
                .WithMany(i => i.Categories)
                .UsingEntity<Dictionary<string, object>>("item_categories",
                    (ic) => ic.HasOne<Item>()
                        .WithMany()
                        .HasForeignKey("item_id"),
                    (ic) => ic.HasOne<Category>()
                        .WithMany()
                        .HasForeignKey("category_id"),
                    (ic) =>
                    {
                        ic.ToTable("item_categories");
                        ic.HasKey("item_id", "category_id");
                    });

            entity.Property(e => e.Name)
                .HasColumnName("name")
                .HasColumnType("varchar(35)")
                .IsRequired();
            entity.HasIndex(e => e.Name)
                .IsUnique();

            entity.Property(e => e.Description)
                .HasColumnName("description")
                .HasColumnType("varchar(255)")
                .IsRequired();
        });
}
