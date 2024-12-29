using Rivella.Blazor.Models.Album;

namespace Rivella.Blazor.Services.Album.CreateAlbum;

public interface ICreateAlbumService
{
    Task<AlbumResponseModel> CreateAsync(CreateAlbumModel albumModel);
}