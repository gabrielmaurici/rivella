using Rivella.Domain.SeedWork;

namespace Rivella.Domain.Exceptions;

public class RequiredFieldsException : BadRequestException
{
    public RequiredFieldsException(string message) : base(message)
    {
    }

    public RequiredFieldsException(string message, ArgumentException innerException) : base(message, innerException)
    {
    }
}