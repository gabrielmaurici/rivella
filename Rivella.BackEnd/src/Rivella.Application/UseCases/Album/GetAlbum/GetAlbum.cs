using Rivella.Application.UseCases.Album.Common;
using Rivella.Domain.Exceptions;
using Rivella.Domain.Repository;

namespace Rivella.Application.UseCases.Album.GetAlbum;

public class GetAlbum(IAlbumRepository albumRepository) : IGetAlbum
{
    public async Task<AlbumOutput> GetAsync(Guid code)
    {
        var album = await albumRepository.GetAsync(code) ??
            throw new AlbumNotFound();

        return AlbumOutput.FromAlbum(album);
    }
}