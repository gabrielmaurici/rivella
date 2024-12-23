using CloudinaryDotNet;
using Rivella.Application.Interfaces;
using Rivella.Infra.Storage.Service;

namespace Rivella.Api.Configurations;

public static class StorageConfiguration
{
    public static IServiceCollection AddStorageConfiguration(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        Console.WriteLine("cloud: " + configuration.GetConnectionString("CLOUDINARY"));
        Console.WriteLine("cloudEnv: " + Environment.GetEnvironmentVariable("CLOUDINARY"));
        services.AddSingleton(new Cloudinary(configuration.GetValue<string>("CLOUDINARY")));
        services.AddTransient<IStorageService, StorageService>();
        
        return services;
    }
}