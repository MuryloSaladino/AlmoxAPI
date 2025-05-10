using Almox.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Almox.Persistence.Entities;

public static class DepartmentEntityCreationExtensions
{
    public static void ConfigureDepartmentEntity(this ModelBuilder modelBuilder)
        => modelBuilder.Entity<Department>(entity =>
        {
            entity.ConfigureBaseEntityProps();

            entity.HasMany(e => e.Users)
                .WithOne(u => u.Department)
                .HasForeignKey(u => u.DepartmentId);
            
            entity.Property(e => e.Name)
                .HasColumnType("VARCHAR(50)")
                .IsRequired();
        });
}
