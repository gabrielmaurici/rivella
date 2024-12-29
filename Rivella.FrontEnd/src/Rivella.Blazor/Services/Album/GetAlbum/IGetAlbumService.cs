using Rivella.Blazor.Models.Album;

namespace Rivella.Blazor.Services.Album.GetAlbum;

public interface IGetAlbumService
{
    Task<AlbumResponseModel> GetAsync(Guid code);
}