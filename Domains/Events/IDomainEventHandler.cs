namespace Domains.Events;

/// <summary>
/// ドメインイベントハンドラ
/// </summary>
/// <typeparam name="TDomainEvent"></typeparam>
public interface IDomainEventHandler<TDomainEvent>
    where TDomainEvent : IDomainEvent
{
    /// <summary>
    /// イベントを処理する
    /// </summary>
    /// <param name="domainEvent"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task HandleAsync(TDomainEvent domainEvent, CancellationToken cancellationToken);
}
