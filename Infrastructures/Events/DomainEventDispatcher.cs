using Domains.Events;

namespace Infrastructures.Events;

public class DomainEventDispatcher<TDomainEvent> : IDomainEventDispatcher<TDomainEvent>
    where TDomainEvent : IDomainEvent
{
    private readonly IEnumerable<IDomainEventHandler<TDomainEvent>> _handlers;

    public DomainEventDispatcher(IEnumerable<IDomainEventHandler<TDomainEvent>> handlers)
        => _handlers = handlers;

    public async Task DispatchAsync(TDomainEvent domainEvent, CancellationToken cancellationToken = default)
    {
        foreach (var handler in _handlers)
        {
            await handler.HandleAsync(domainEvent, cancellationToken);
        }
    }
}
