using Rivella.Application.UseCases.Album.Common;
using Rivella.Domain.Repository;

namespace Rivella.Application.UseCases.Album.CreateAlbum;

public class GetAlbum(IAlbumRepository albumRepository) : IGetAlbum
{
    public async Task<AlbumOutput> GetAsync(Guid code)
    {
        var album = await albumRepository.GetAsync(code) ??
            throw new KeyNotFoundException($"Albúm não encontrado com código: {code}");

        return AlbumOutput.FromAlbum(album);
    }
}