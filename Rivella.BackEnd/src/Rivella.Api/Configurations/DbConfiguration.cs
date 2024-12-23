using Microsoft.EntityFrameworkCore;
using Rivella.Infra.Data.Context;

namespace Rivella.Api.Configurations;

public static class DbConfiguration
{
    public static IServiceCollection AddDbConnection(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("RivellaDb");
        Console.WriteLine("Teste: " + connectionString);
        Console.WriteLine("TESTE: " + Environment.GetEnvironmentVariable("RivellaDb"));
        services.AddDbContext<RivellaContext>(options => options.UseNpgsql(
            connectionString
        ));
        return services;
    }
}