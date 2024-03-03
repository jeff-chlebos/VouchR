namespace VouchR.Domain.Exceptions;

public sealed class SubscriptionExpiredException : DomainException
{
    public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;

    public SubscriptionExpiredException(Guid subscriberId, string productId)
        : base($"The subscription for product ID: '{productId}' for subscriber ID: '{subscriberId}' is expired. No further actions can be taken on a expired subscription.")
    {
    }
}
