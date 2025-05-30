using Domain.Events;

namespace Domain.Chats.Events;

/// <summary>
/// ユーザがメッセージを投稿した時に発生するドメインイベント
/// </summary>
public class UserMessagePosted : IDomainEvent
{
    /// <summary>
    /// イベントを発行した集約の識別子
    /// </summary>
    public Guid AggregateId { get; }

    /// <summary>
    /// イベントが発生した日時
    /// </summary>
    public DateTimeOffset OccuredOn { get; }

    /// <summary>
    /// 会話部屋
    /// </summary>
    public ChatRoom ChatRoom { get; }

    /// <summary>
    /// 投稿されたメッセージ
    /// </summary>
    public ChatMessage ChatMessage { get; }

    public UserMessagePosted(
        Guid aggregatedid,
        DateTimeOffset occuredOn,
        ChatRoom chatRoom,
        ChatMessage chatMessage
    )
    {
        AggregateId = aggregatedid;
        OccuredOn = occuredOn;
        ChatRoom = chatRoom;
        ChatMessage = chatMessage;
    }
}
