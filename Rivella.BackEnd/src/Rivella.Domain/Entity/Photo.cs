using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Rivella.Domain.Exceptions;
using Rivella.Domain.SeedWork;

namespace Rivella.Domain.Entity;

public sealed class Photo : Entity<int>
{
    public Photo(
        int albumId,
        string url,
        string? description,
        DateTime dateUpload,
        int id = 0) : base(id)
    {
        AlbumId = albumId;
        Url = url;
        Description = description;
        DateUpload = dateUpload;
        
        Validate();
    }

    public int AlbumId { get; private init; }
    public string Url { get; private init; }
    public string? Description { get; private set; }
    public DateTime DateUpload { get; private set; }
    public Album? Album { get; private set; }
    
    private void Validate()
    {
        var errorsBuilder = new StringBuilder();
        if (AlbumId <= 0)
            errorsBuilder.Append("AlbumId é obrigatório, ");

        if (string.IsNullOrWhiteSpace(Url))
            errorsBuilder.Append("Url é obrigatório, ");

        if (errorsBuilder.Length > 0)
        {
            var errors = errorsBuilder
                .ToString()
                .TrimEnd();
            
            throw new RequiredFieldsException(
                errors.Remove(errors.Length - 1, 1)
            );
        }
    }
}