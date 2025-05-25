using Domain.Chats;
using Domain.Chats.Events;
using Domain.Chats.Repositories;
using Domain.Events;
using ServiceInterfaces.Chats;
using ServiceInterfaces.Chats.Dtos;

namespace ServiceImplementations.Chats;

/// <summary>
/// チャット関連のサービス
/// </summary>
public class ChatsService : IChatsService
{
    private readonly IChatRoomRepository _chatRoomRepository;
    private readonly INotificationHandler<UserMessagePosted> _notificationHandler;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="chatRoomRepository"></param>
    /// <param name="notificationHandler"></param>
    public ChatsService(
        IChatRoomRepository chatRoomRepository,
        INotificationHandler<UserMessagePosted> notificationHandler
    )
    {
        _chatRoomRepository = chatRoomRepository;
        _notificationHandler = notificationHandler;
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public async Task<PostUserMessageResponse> PostUserMessageAsync(PostUserMessageRequest request)
    {
        var chatRoom = await _chatRoomRepository.GetByIdAsync(Guid.NewGuid());
        chatRoom.PostUserMessage(new ChatMessage(
            Guid.NewGuid(),
            "user",
            "おはよう"
        ));

        var cts = CancellationTokenSource.CreateLinkedTokenSource();

        foreach (var userMessagePostEvent in chatRoom.Events)
        {
            await _notificationHandler.HandleAsync(userMessagePostEvent, cts.Token);
        }

        return new PostUserMessageResponse();
    }
}
