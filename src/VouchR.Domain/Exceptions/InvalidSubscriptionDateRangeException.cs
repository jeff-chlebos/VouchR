namespace VouchR.Domain.Exceptions;

public sealed class InvalidSubscriptionDateRangeException : DomainException
{
    public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;

    public InvalidSubscriptionDateRangeException(string productId, DateTime startDate, DateTime expiryDate)
        : base($"Invalid date range for subscription with Product ID '{productId}'. Start date '{startDate}' must be earlier than expiry date '{expiryDate}'.")
    {
    }
}
