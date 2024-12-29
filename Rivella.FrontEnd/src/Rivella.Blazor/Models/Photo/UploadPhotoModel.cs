using Microsoft.AspNetCore.Components.Forms;

namespace Rivella.Blazor.Models.Photo;

public record UploadPhotoModel(
    int IdAlbum,
    string? UserName,
    string? Description,
    IBrowserFile Image
);