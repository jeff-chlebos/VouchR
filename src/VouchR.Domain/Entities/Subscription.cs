namespace VouchR.Domain.Entities;

public sealed class Subscription
{
    public string Id { get; } = string.Empty;
    public DateTime StartDate { get; private set; }
    public DateTime ExpiryDate { get; private set; }
    public DateTime? CancelDate { get; private set; }
    public TimeSpan GracePeriod { get; }

    private Subscription()
    {
    }

    internal Subscription(string id, DateTime startDate, DateTime expiryDate, TimeSpan gracePeriod)
    {
        Id = id;
        StartDate = startDate;
        ExpiryDate = expiryDate;
        GracePeriod = gracePeriod;
    }
    
    internal void Cancel()
        => CancelDate = DateTime.UtcNow;
    
    internal void Renew(DateTime startDate, DateTime expiryDate)
    {
        StartDate = startDate;
        ExpiryDate = expiryDate;
    }
    
    internal bool IsActive()
        => CancelDate is null
        && DateTime.UtcNow >= StartDate
        && DateTime.UtcNow <= ExpiryDate;
    
    internal bool IsCanceled()
        => CancelDate is not null
        && DateTime.UtcNow >= StartDate
        && DateTime.UtcNow <= ExpiryDate + GracePeriod;
    
    internal bool IsInGracePeriod()
        => CancelDate is null
        && DateTime.UtcNow > ExpiryDate
        && DateTime.UtcNow <= ExpiryDate + GracePeriod;
    
    internal bool IsExpired()
        => DateTime.UtcNow > ExpiryDate + GracePeriod;
}
