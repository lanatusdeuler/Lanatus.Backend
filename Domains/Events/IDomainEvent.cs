namespace Domains.Events;

/// <summary>
/// ドメインイベントを表すインターフェイス
/// </summary>
public interface IDomainEvent
{
    /// <summary>
    /// イベントを発行した集約の識別子
    /// </summary>
    Guid AggregateId { get; }

    /// <summary>
    /// イベントが発生した日時
    /// </summary>
    DateTimeOffset OccuredOn { get; }
}
