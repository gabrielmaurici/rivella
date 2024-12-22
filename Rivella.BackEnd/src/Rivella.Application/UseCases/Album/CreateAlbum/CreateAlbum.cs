using Rivella.Application.Interfaces;
using Rivella.Application.UseCases.Album.Common;
using Rivella.Domain.Repository;

namespace Rivella.Application.UseCases.Album.CreateAlbum;

public class CreateAlbum(
    IAlbumRepository albumRepository,
    IUnitOfWork unitOfWork) : ICreateAlbum
{
    public async Task<AlbumOutput> CreateAsync(CreateAlbumInput input)
    {
        var album = new Domain.Entity.Album(
            input.Name,
            input.RevelationDate
        );
        
        await albumRepository.InsertAsync(album);
        await unitOfWork.CommitAsync();
        
        return AlbumOutput.FromAlbum(album);
    }
}