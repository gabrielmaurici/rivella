namespace Rivella.Application.UseCases.Photo.UploadPhoto;

public record UploadPhotoInput(
    int IdAlbum,
    string? UserName,
    string? Description,
    Stream Image
);