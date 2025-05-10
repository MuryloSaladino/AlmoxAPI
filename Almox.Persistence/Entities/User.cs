using Almox.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Almox.Persistence.Entities;

public static class UserEntityCreationExtensions
{
    public static void ConfigureUserEntity(this ModelBuilder modelBuilder)
        => modelBuilder.Entity<User>(entity =>
        {
            entity.ConfigureBaseEntityProps();

            entity.Property(e => e.DepartmentId)
                .IsRequired();
            entity.HasOne(e => e.Department)
                .WithMany(d => d.Users)
                .HasForeignKey(e => e.DepartmentId);
            
            entity.Property(e => e.Email)
                .HasColumnType("VARCHAR(255)")
                .IsRequired();
            entity.HasIndex(e => e.Email)
                .IsUnique();

            entity.Property(e => e.Password)
                .HasColumnType("VARCHAR(255)")
                .IsRequired();

            entity.Property(e => e.Username)
                .HasColumnType("VARCHAR(255)")
                .IsRequired();
            entity.HasIndex(e => e.Username)
                .IsUnique();

            entity.Property(e => e.IsAdmin)
                .HasColumnType("BOOLEAN")
                .HasDefaultValue(false);
        });
}
