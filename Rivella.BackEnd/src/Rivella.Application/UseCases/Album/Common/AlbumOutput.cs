namespace Rivella.Application.UseCases.Album.Common;

public record AlbumOutput(
    int Id,
    Guid Code,
    string Name,
    string QrCode,
    DateTime RevelationDate,
    List<PhotoOutput> Photos
)
{
    public static AlbumOutput FromAlbum(Domain.Entity.Album album)
    {
        return new AlbumOutput(
            album.Id,
            album.Code,
            album.Name,
            Convert.ToBase64String(album.QrCode),
            album.RevelationDate,
            album.Photos.Select(photo => 
                new PhotoOutput(
                    photo.Description, 
                    photo.Url,
                    photo.DateUpload
                )
            ).ToList()
        );
    }
}

public record PhotoOutput(
    string? Description,
    string Url,
    DateTime DateUpload
);


