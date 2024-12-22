using Rivella.Application.UseCases.Album.Common;

namespace Rivella.Application.UseCases.Album.CreateAlbum;

public interface ICreateAlbum
{
    Task<AlbumOutput> CreateAsync(CreateAlbumInput input);
}