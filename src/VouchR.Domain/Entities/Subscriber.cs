namespace VouchR.Domain.Entities;

public sealed class Subscriber : AggregateRoot<Guid>
{
    private readonly IList<Subscription> _subscriptions;

    public IEnumerable <Subscription> Subscriptions => _subscriptions;

    internal Subscriber(Guid id)
    {
        Id = id;
        _subscriptions = new List<Subscription>();
    }

    public void ActivateSubscription(string productId, DateTime startDate, DateTime expiryDate, TimeSpan gracePeriod)
    {
        var isDateRangeInvalid = startDate >= expiryDate;
        if (isDateRangeInvalid) throw new InvalidSubscriptionDateRangeException(productId, startDate, expiryDate);

        var isProductInvalid = string.IsNullOrWhiteSpace(productId);
        if (isProductInvalid) throw new InvalidProductIdException();

        var sub = _subscriptions.SingleOrDefault(s => s.Id == productId);
        if (sub is not null)
        {
            if (sub.IsActive()) throw new SubscriptionActivatedException(Id, productId);
            if (sub.IsCanceled()) throw new SubscriptionCanceledException(Id, productId);
            if (sub.IsInGracePeriod()) throw new SubscriptionInGracePeriodException(Id, productId);
            _subscriptions.Remove(sub);
        }
        
        sub = new Subscription(productId, startDate, expiryDate, gracePeriod);
        _subscriptions.Add(sub);
        AddEvent(new SubscriptionActivated(sub));
    }

    public void CancelSubscription(string productId)
    {
        var sub = _subscriptions.SingleOrDefault(s => s.Id == productId)
            ?? throw new SubscriptionNotExistsException(Id, productId);

        if (sub.IsCanceled()) throw new SubscriptionCanceledException(Id, productId);
        if (sub.IsExpired()) throw new SubscriptionExpiredException(Id, productId);

        sub.Cancel();
        AddEvent(new SubscriptionCanceled(sub));
    }

    public void RenewSubscription(string productId, DateTime startDate, DateTime expiryDate)
    {
        var sub = _subscriptions.SingleOrDefault(s => s.Id == productId)
            ?? throw new SubscriptionNotExistsException(Id, productId);

        if (sub.IsCanceled()) throw new SubscriptionCanceledException(Id, productId);
        if (sub.IsExpired()) throw new SubscriptionExpiredException(Id, productId);

        sub.Renew(startDate, expiryDate);
        AddEvent(new SubscriptionRenewed(sub));
    }
}
