using dotenv.net;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Almox.Persistence.Context;

public class AlmoxDbContextFactory : IDesignTimeDbContextFactory<AlmoxContext>
{
    public AlmoxContext CreateDbContext(string[] args)
    {
        DotEnv.Load(options: new DotEnvOptions(envFilePaths: ["../.env"]));

        var optionsBuilder = new DbContextOptionsBuilder<AlmoxContext>();
        optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("DATABASE_URL"));

        return new AlmoxContext(optionsBuilder.Options);
    }
}