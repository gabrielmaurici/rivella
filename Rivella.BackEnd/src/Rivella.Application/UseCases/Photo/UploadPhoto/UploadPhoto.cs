using Rivella.Application.Common;
using Rivella.Application.Interfaces;
using Rivella.Domain.Exceptions;
using Rivella.Domain.Repository;

namespace Rivella.Application.UseCases.Photo.UploadPhoto;

public class UploadPhoto(
    IAlbumRepository albumRepository,
    IPhotoRepository photoRepository,
    IStorageService storageService,
    IUnitOfWork unitOfWork) : IUploadPhoto
{
    public async Task Upload(UploadPhotoInput input)
    {
        var album = await albumRepository.GetAsync(input.IdAlbum) ??
            throw new AlbumNotFound();

        var filename = StorageFileName.Create(album.Id);
        var photoUrl = await storageService.Upload(filename, input.Image);
        var photo = new Domain.Entity.Photo(
            album.Id,
            photoUrl,
            input.Description,
            input.UploadDate
        );
        
        await photoRepository.InsertAsync(photo);
        await unitOfWork.CommitAsync();
    }
}