using Rivella.Application.Interfaces;
using Rivella.Application.UseCases.Album;
using Rivella.Application.UseCases.Album.CreateAlbum;
using Rivella.Application.UseCases.Photo.UploadPhoto;
using Rivella.Domain.Repository;
using Rivella.Infra.Data;
using Rivella.Infra.Data.Repository;

namespace Rivella.Api.Configurations;

public static class UseCasesConfiguration
{
    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        services.AddRepositories();
        services.AddServices();
        
        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<IAlbumRepository, AlbumRepository>();
        services.AddTransient<IPhotoRepository, PhotoRepository>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        
        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddTransient<ICreateAlbum, CreateAlbum>();
        services.AddTransient<IUploadPhoto, UploadPhoto>();
        services.AddTransient<IGetAlbum, GetAlbum>();
        
        return services;
    }
}