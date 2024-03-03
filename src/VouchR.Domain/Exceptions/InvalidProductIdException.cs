namespace VouchR.Domain.Exceptions;

public sealed class InvalidProductIdException : DomainException
{
    public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;

    public InvalidProductIdException()
        : base($"Product ID cannot be null, empty or white space.")
    {
    }
}
