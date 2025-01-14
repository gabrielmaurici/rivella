namespace Rivella.Domain.Exceptions;

public class AlbumNotFound : KeyNotFoundException
{
    private const string ErrorMessage = "Album não encontrado";
    
    public AlbumNotFound() : base(ErrorMessage)
    {
    }

    public AlbumNotFound(Exception exception) : base(ErrorMessage, exception)
    {
    }
}