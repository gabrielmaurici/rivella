namespace Rivella.Blazor.Models.Album;

public record AlbumResponseModel(
    int Id,
    Guid Code,
    string Name,
    DateTime RevelationDate,
    List<PhotoOutput> Photos
);

public record PhotoOutput(
    string? UserName,
    string? Description,
    string Url,
    DateTime DateUpload
);