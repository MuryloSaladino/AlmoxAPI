using Almox.Persistence.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Almox.Persistence.Context;

public class XpricefyDbContextFactory : IDesignTimeDbContextFactory<AlmoxContext>
{
    public AlmoxContext CreateDbContext(string[] args)
    {
        DotEnv.Load();

        var optionsBuilder = new DbContextOptionsBuilder<AlmoxContext>();
        optionsBuilder.UseNpgsql(DotEnv.Get("DATABASE_URL"));

        return new AlmoxContext(optionsBuilder.Options);
    }
}