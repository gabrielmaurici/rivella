using Rivella.Domain.SeedWork;

namespace Rivella.Domain.Entity;

public class Photo : Entity<int>
{
    public Photo(int idAlbum, string url, string? userName, string? description, int id = 0) : base(id)
    {
        IdAlbum = idAlbum;
        Url = url;
        UserName = userName;
        Description = description;

        Validate();
    }

    public int IdAlbum { get; private set; }
    public string Url { get; private set; }
    public string? UserName { get; private set; }
    public string? Description { get; private set; }
    public DateTime DateUpload { get; private set; }
    
    private void Validate()
    {
        if (IdAlbum <= 0)
            throw new ArgumentException("IdAlbum é obrigatório", nameof(IdAlbum));
        
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