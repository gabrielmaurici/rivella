namespace Rivella.Domain.SeedWork;

public abstract class BadRequestException : ArgumentException
{
    protected BadRequestException(string message) : base(message)
    {
    }

    protected BadRequestException(string message, Exception innerException) : base(message, innerException)
    {
    }
}