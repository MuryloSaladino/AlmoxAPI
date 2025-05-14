using Almox.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Almox.Persistence.Tables;

public static class DepartmentTableConfigurationExtensions
{
    public static void ConfigureDepartmentTable(this ModelBuilder modelBuilder)
        => modelBuilder.Entity<Department>(entity =>
        {
            entity.ToTable("departments");

            entity.ConfigureBaseTableProps();

            entity.HasMany(e => e.Users)
                .WithOne(u => u.Department)
                .HasForeignKey(u => u.DepartmentId);
            
            entity.Property(e => e.Name)
                .HasColumnName("name")
                .HasColumnType("varchar(50)")
                .IsRequired();
            entity.HasIndex(e => e.Name)
                .IsUnique();
        });
}
