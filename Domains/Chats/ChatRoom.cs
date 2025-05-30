using System.Collections.ObjectModel;
using Domain.Chats.Events;

namespace Domain.Chats;

/// <summary>
/// 会話部屋
/// </summary>
public class ChatRoom
{
    public Collection<UserMessagePosted> Events { get; } = [];

    /// <summary>
    /// 会話部屋の識別子
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// 会話部屋での会話履歴
    /// </summary>
    public Collection<ChatMessage> ChatMessages { get; }

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="id"></param>
    /// <param name="chatMessages"></param>
    public ChatRoom(Guid id, Collection<ChatMessage> chatMessages)
    {
        Id = id;
        ChatMessages = chatMessages;
    }

    /// <summary>
    /// メッセージを投稿する
    /// </summary>
    /// <param name="chatMessage"></param>
    public void PostUserMessage(ChatMessage chatMessage)
    {
        Events.Add(new UserMessagePosted(Id, DateTime.Now, this, chatMessage));
        ChatMessages.Add(chatMessage);
    }
}
