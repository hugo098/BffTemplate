namespace BffTemplate.Application.Exceptions;
public class InternalServerException : Exception
{
    public string? Details { get; }

    public InternalServerException()
    {
    }

    public InternalServerException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public InternalServerException(string message) : base(message)
    {
    }

    public InternalServerException(string message, string details) : base(message)
    {
        Details = details;
    }
}
