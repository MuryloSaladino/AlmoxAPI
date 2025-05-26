using Almox.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Almox.Persistence.TableMappings;

public class UserConfiguration : BaseEntityConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);

        builder.ToTable("users");

        builder.Property(e => e.DepartmentId)
            .HasColumnName("department_id")
            .IsRequired();
        builder.HasOne(e => e.Department)
            .WithMany(d => d.Users)
            .HasForeignKey(e => e.DepartmentId);

        builder.Property(e => e.Username)
            .HasColumnName("username")
            .HasColumnType("varchar(255)")
            .IsRequired();
        builder.HasIndex(e => e.Username)
            .IsUnique();

        builder.Property(e => e.Email)
            .HasColumnName("email")
            .HasColumnType("varchar(255)")
            .IsRequired();
        builder.HasIndex(e => e.Email)
            .IsUnique();

        builder.Property(e => e.Password)
            .HasColumnName("password")
            .HasColumnType("varchar(255)")
            .IsRequired();

        builder.Property(e => e.Role)
            .HasColumnName("role")
            .HasColumnType("smallint")
            .IsRequired();
    }
}
