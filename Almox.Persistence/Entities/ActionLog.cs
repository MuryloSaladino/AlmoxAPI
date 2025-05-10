using Almox.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Almox.Persistence.Entities;

public static class ActionLogEntityCreationExtensions
{
    public static void ConfigureActionLogEntity(this ModelBuilder modelBuilder)
        => modelBuilder.Entity<ActionLog>(entity =>
        {   
            entity.ConfigureBaseEntityProps();

            entity.Property(e => e.UserId)
                .IsRequired();
            entity.HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId);
                
            entity.Property(e => e.Description)
                .HasColumnType("VARCHAR(255)")
                .IsRequired();
        });
}