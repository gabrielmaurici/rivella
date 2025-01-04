using System.ComponentModel.DataAnnotations.Schema;
using Rivella.Domain.SeedWork;

namespace Rivella.Domain.Entity;

public sealed class Photo : Entity<int>
{
    public Photo(
        int albumId,
        string url,
        string? userName,
        string? description,
        DateTime dateUpload,
        int id = 0) : base(id)
    {
        AlbumId = albumId;
        Url = url;
        UserName = userName;
        Description = description;
        DateUpload = dateUpload;
        
        Validate();
    }

    public int AlbumId { get; private init; }
    public string Url { get; private init; }
    public string? UserName { get; private set; }
    public string? Description { get; private set; }
    public DateTime DateUpload { get; private set; }
    public Album? Album { get; private set; }
    
    private void Validate()
    {
        if (AlbumId <= 0)
            throw new ArgumentException("IdAlbum é obrigatório", nameof(AlbumId));
        
        if (string.IsNullOrWhiteSpace(Url))
            throw new ArgumentException("Url é obrigatório", nameof(Url));
    }
}