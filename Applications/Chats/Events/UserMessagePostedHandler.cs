using ApplicationInterfaces.ExternalServices;
using Domains.Chats.Events;
using Domains.Chats.Repositories;
using Domains.Events;

namespace Applications.Chats.Events;

public class UserMessagePostedHandler : IDomainEventHandler<UserMessagePosted>
{
    private readonly IChatRoomRepository _chatRoomRepository;
    private readonly IChatCompletionService _chatCompletionService;

    public UserMessagePostedHandler(
        IChatRoomRepository chatRoomRepository,
        IChatCompletionService chatCompletionService
    )
    {
        _chatRoomRepository = chatRoomRepository;
        _chatCompletionService = chatCompletionService;
    }

    public async Task HandleAsync(UserMessagePosted domainEvent, CancellationToken cancellationToken = default)
    {
        var chatRoom = await _chatRoomRepository.GetByIdAsync(domainEvent.AggregateId);
    }
}
