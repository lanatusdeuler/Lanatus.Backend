namespace Domain.Events;

/// <summary>
/// ドメインイベントハンドラ
/// </summary>
/// <typeparam name="TNotification"></typeparam>
public interface INotificationHandler<TNotification> where TNotification : IDomainEvent
{
    /// <summary>
    /// イベントを処理する
    /// </summary>
    /// <param name="notification"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task HandleAsync(TNotification notification, CancellationToken ct);
}
