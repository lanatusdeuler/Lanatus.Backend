using ApplicationInterfaces.ExternalServices;
using Domains.Chats.Events;
using Domains.Chats.Repositories;
using Domains.Events;

namespace Applications.Chats.Events;

public class UserMessagePostedHandler : INotificationHandler<UserMessagePosted>
{
    private readonly IChatRoomRepository _chatRoomRepository;
    private readonly IChatCompletionService _chatCompletionService;
    private readonly IContextCollectionService _contextCollectionService;

    public UserMessagePostedHandler(
        IChatRoomRepository chatRoomRepository,
        IChatCompletionService chatCompletionService,
        IContextCollectionService contextCollectionService
    )
    {
        _chatRoomRepository = chatRoomRepository;
        _chatCompletionService = chatCompletionService;
        _contextCollectionService = contextCollectionService;
    }

    public async Task HandleAsync(UserMessagePosted notification, CancellationToken ct)
    {
        var chatRoom = await _chatRoomRepository.GetByIdAsync(notification.AggregateId);
    }
}
