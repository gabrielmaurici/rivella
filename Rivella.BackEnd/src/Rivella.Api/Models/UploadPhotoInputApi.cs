using Rivella.Application.UseCases.Photo.UploadPhoto;

namespace Rivella.Api.Models;

public class UploadPhotoInputApi
{
    public int IdAlbum { get; set; }
    public string? UserName { get; set; }
    public string? Description { get; set; }
    public IFormFile Image { get; set; } = null!;

    public UploadPhotoInput ToUploadPhotoInput()
    {
        if (Image == null || Image.Length == 0)
        {
            throw new ArgumentException("Imagem é obrigatório.");
        }
        
        var memoryStream = new MemoryStream();
        Image.CopyTo(memoryStream);
        memoryStream.Position = 0;

        return new UploadPhotoInput(IdAlbum, UserName, Description, memoryStream);
    }
}