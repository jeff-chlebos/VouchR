namespace VouchR.Domain.Exceptions;

public sealed class SubscriptionInGracePeriodException : DomainException
{
    public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;

    public SubscriptionInGracePeriodException(Guid subscriberId, string productId)
        : base($"The subscription for product ID: '{productId}' for subscriber ID: '{subscriberId}' is in the grace period. No further actions can be taken until it either expires or is renewed")
    {
    }
}
