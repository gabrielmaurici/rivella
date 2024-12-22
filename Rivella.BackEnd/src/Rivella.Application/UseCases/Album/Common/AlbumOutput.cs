using Rivella.Domain.Entity;

namespace Rivella.Application.UseCases.Album.Common;

public record AlbumOutput(
    int Id,
    Guid Code,
    string Name,
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
            album.RevelationDate,
            album.Photos.Select(photo => 
                new PhotoOutput(
                    photo.UserName, 
                    photo.Description, 
                    photo.Url
                )
            ).ToList()
        );
    }
}

public record PhotoOutput(
    string? UserName,
    string? Description,
    string Url
);


