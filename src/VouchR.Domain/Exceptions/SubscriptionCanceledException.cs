namespace VouchR.Domain.Exceptions;

public sealed class SubscriptionCanceledException : DomainException
{
    public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;

    public SubscriptionCanceledException(Guid subscriberId, string productId)
        : base($"The subscription for product ID: '{productId}' for subscriber ID: '{subscriberId}' has already been canceled. No further actions can be taken on a canceled subscription.")
    {
    }
}
