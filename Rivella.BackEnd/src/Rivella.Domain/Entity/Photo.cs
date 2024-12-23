using System.ComponentModel.DataAnnotations.Schema;
using Rivella.Domain.SeedWork;

namespace Rivella.Domain.Entity;

public class Photo : Entity<int>
{
    public Photo(int albumId, string url, string? userName, string? description, int id = 0) : base(id)
    {
        AlbumId = albumId;
        Url = url;
        UserName = userName;
        Description = description;
        DateUpload = DateTime.Now;
        
        Validate();
    }

    public int AlbumId { get; private set; }
    public string Url { get; private set; }
    public string? UserName { get; private set; }
    public string? Description { get; private set; }
    public DateTime DateUpload { get; private set; }
    public virtual Album Album { get; private set; }
    
    private void Validate()
    {
        if (AlbumId <= 0)
            throw new ArgumentException("IdAlbum é obrigatório", nameof(AlbumId));
        
        if (string.IsNullOrWhiteSpace(Url))
            throw new ArgumentException("Url é obrigatório", nameof(Url));
    }
    
    public void Update(string? userName, string? description)
    {
        UserName = userName ?? UserName;
        Description = description ?? Description;
        
        Validate();
    }
}