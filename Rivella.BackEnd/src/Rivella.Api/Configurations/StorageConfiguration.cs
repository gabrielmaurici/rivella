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
        var teste = configuration.GetValue<string>("CLOUDINARY");
        services.AddSingleton(new Cloudinary(configuration.GetValue<string>("CLOUDINARY")));
        services.AddTransient<IStorageService, StorageService>();
        
        return services;
    }
}