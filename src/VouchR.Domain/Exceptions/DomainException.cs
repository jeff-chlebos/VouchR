namespace VouchR.Domain.Exceptions;

public abstract class DomainException : Exception
{
    public abstract HttpStatusCode StatusCode { get; }
    
    public DomainException(string message) : base(message)
    {
    }
}