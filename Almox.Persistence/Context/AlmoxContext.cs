using Microsoft.EntityFrameworkCore;

namespace Almox.Persistence.Context;

public class AlmoxContext(DbContextOptions<AlmoxContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AlmoxContext).Assembly);
    }
}