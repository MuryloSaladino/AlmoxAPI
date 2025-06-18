using Almox.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Almox.Persistence.TableMappings;

public class CategoryConfiguration : BaseEntityConfiguration<Category>
{
    public override void Configure(EntityTypeBuilder<Category> builder)
    {
        base.Configure(builder);

        builder.ToTable("categories");

        builder.Property(c => c.Name)
            .HasColumnName("name")
            .HasColumnType("varchar(35)")
            .IsRequired();
        builder.HasIndex(c => c.Name)
            .IsUnique();
    }
}