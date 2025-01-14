namespace Rivella.Domain.SeedWork;

public abstract class InternalErrorException : Exception
{
    protected InternalErrorException(string message) : base(message)
    {
    }

    protected InternalErrorException(string message, Exception innerException) : base(message, innerException)
    {
    }
}