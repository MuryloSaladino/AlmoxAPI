using Microsoft.EntityFrameworkCore;
using Almox.Domain.Entities;

namespace Almox.Persistence.Context;

public class AlmoxContext(DbContextOptions<AlmoxContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
            .HasKey(u => u.Id);
    }
}