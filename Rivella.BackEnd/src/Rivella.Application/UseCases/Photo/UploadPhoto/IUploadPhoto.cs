namespace Rivella.Application.UseCases.Photo.UploadPhoto;

public interface IUploadPhoto
{
    Task Upload(UploadPhotoInput input);
}