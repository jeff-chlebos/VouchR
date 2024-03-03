namespace VouchR.Domain.Exceptions;

public sealed class SubscriptionActivatedException : DomainException
{
    public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;

    public SubscriptionActivatedException(Guid subscriberId, string productId)
        : base($"An active subscription for product ID: '{productId}' already exists for subscriber ID: '{subscriberId}'. A new subscription cannot be activated until the current one expires.")
    {
    }
}
