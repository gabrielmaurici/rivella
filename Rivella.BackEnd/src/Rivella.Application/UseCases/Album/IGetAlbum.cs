using Rivella.Application.UseCases.Album.Common;

namespace Rivella.Application.UseCases.Album;

public interface IGetAlbum
{
    Task<AlbumOutput> GetAsync(Guid code);
}