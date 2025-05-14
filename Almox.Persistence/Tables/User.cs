using Almox.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Almox.Persistence.Tables;

public static class UserTableConfigurationExtensions
{
    public static void ConfigureUserTable(this ModelBuilder modelBuilder)
        => modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("users");

            entity.ConfigureBaseTableProps();

            entity.Property(e => e.DepartmentId)
                .HasColumnName("department_id")
                .IsRequired();
            entity.HasOne(e => e.Department)
                .WithMany(d => d.Users)
                .HasForeignKey(e => e.DepartmentId);
            
            entity.Property(e => e.Email)
                .HasColumnName("email")
                .HasColumnType("varchar(255)")
                .IsRequired();
            entity.HasIndex(e => e.Email)
                .IsUnique();

            entity.Property(e => e.Password)
                .HasColumnName("password")
                .HasColumnType("varchar(255)")
                .IsRequired();

            entity.Property(e => e.Username)
                .HasColumnName("username")
                .HasColumnType("varchar(255)")
                .IsRequired();
            entity.HasIndex(e => e.Username)
                .IsUnique();

            entity.Property(e => e.IsAdmin)
                .HasColumnName("is_admin")
                .HasColumnType("boolean")
                .HasDefaultValue(false);
        });
}
