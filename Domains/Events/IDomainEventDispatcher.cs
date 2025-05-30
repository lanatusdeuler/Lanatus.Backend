namespace Domains.Events;

public interface IDomainEventDispatcher<TDomainEvent>
    where TDomainEvent : IDomainEvent
{
    Task DispatchAsync(TDomainEvent domainEvent, CancellationToken cancellationToken = default);
}
