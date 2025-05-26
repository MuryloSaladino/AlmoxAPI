using Almox.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Almox.Persistence.TableMappings;

public class ItemConfiguration : BaseEntityConfiguration<Item>
{
    public override void Configure(EntityTypeBuilder<Item> builder)
    {
        base.Configure(builder);

        builder.ToTable("items");

        builder.Property(i => i.Name)
            .HasColumnName("name")
            .HasColumnType("varchar(50)")
            .IsRequired();

        builder.Property(i => i.Description)
            .HasColumnName("description")
            .HasColumnType("varchar(255)")
            .IsRequired();

        builder.Property(i => i.Price)
            .HasColumnName("price")
            .HasColumnType("decimal(10,2)")
            .IsRequired();

        builder.Property(i => i.Stock)
            .HasColumnName("stock")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(i => i.ImageUrl)
            .HasColumnName("image_url")
            .HasColumnType("varchar(255)");

        builder.HasMany(i => i.Categories)
            .WithMany()
            .UsingEntity<Dictionary<string, object>>("item_categories",
                (ic) => ic.HasOne<Category>()
                    .WithMany()
                    .HasForeignKey("category_id"),
                (ic) => ic.HasOne<Item>()
                    .WithMany()
                    .HasForeignKey("item_id"),
                (ic) =>
                {
                    ic.ToTable("item_categories");
                    ic.HasKey("item_id", "category_id");
                });
        builder.Navigation(i => i.Categories)
            .AutoInclude();
    }
}
