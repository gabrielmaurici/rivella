using Rivella.Blazor.Models.Photo;

namespace Rivella.Blazor.Services.Album.UploadPhoto;

public interface IUploadPhotoService
{
    Task UploadAsync(UploadPhotoModel model);
}