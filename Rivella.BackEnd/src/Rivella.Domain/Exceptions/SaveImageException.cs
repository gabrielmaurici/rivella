using Rivella.Domain.SeedWork;

namespace Rivella.Domain.Exceptions;

public class SaveImageException : InternalErrorException
{
    private const string ErrorMessage = "Erro ao gravar imagem";
    
    public SaveImageException() : base(ErrorMessage)
    {
    }

    public SaveImageException(Exception exception) : base(ErrorMessage, exception)
    {
    }
}