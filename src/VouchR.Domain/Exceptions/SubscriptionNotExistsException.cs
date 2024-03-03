namespace VouchR.Domain.Exceptions;

public sealed class SubscriptionNotExistsException : DomainException
{
    public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;

    public SubscriptionNotExistsException(Guid subscriberId, string productId)
        : base($"The subscription for product ID: '{productId}' for subscriber ID: '{subscriberId}' not exists. No further actions can be taken until subscription is activated")
    {
    }
}
