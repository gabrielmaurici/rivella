using CloudinaryDotNet;
using Rivella.Application.Interfaces;
using Rivella.Infra.Storage.Service;

namespace Rivella.Api.Configurations;

public static class StorageConfiguration
{
    public static IServiceCollection AddStorageConfiguration(this IServiceCollection services)
    {
        var cloudinaryUrl = Environment.GetEnvironmentVariable("CLOUDINARY");
        services.AddSingleton(new Cloudinary(cloudinaryUrl));
        services.AddTransient<IStorageService, StorageService>();
        
        return services;
    }
}