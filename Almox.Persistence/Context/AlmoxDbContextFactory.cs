using dotenv.net;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.IdentityModel.Protocols.Configuration;

namespace Almox.Persistence.Context;

public class AlmoxDbContextFactory : IDesignTimeDbContextFactory<AlmoxContext>
{
    public AlmoxContext CreateDbContext(string[] args)
    {
        DotEnv.Load(options: new DotEnvOptions(envFilePaths: ["../.env"]));

        var connection = Environment.GetEnvironmentVariable("DATABASE_URL")
            ?? throw new InvalidConfigurationException("The environment needs \"DATABASE_URL\" variable");
        var optionsBuilder = new DbContextOptionsBuilder<AlmoxContext>();

        optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable(connection));

        return new AlmoxContext(optionsBuilder.Options);
    }
}