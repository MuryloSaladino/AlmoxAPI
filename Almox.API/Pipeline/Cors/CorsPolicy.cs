namespace Almox.API.Pipeline.Cors;

public static class CorsPolicyExtensions
{
    public static void ConfigureCorsPolicy(this IServiceCollection services)
    {
        services.AddCors(opt =>
            opt.AddDefaultPolicy(builder => builder
                .WithOrigins(Environment.GetEnvironmentVariable("CORS_ORIGIN") ?? "*")
                .AllowCredentials()
                .AllowAnyMethod()
                .AllowAnyHeader()
            )
        );
    }
}