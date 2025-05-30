using Domain.ExternalServices.Dtos;

namespace Domain.ExternalServices;

public interface IChatCompletionService
{
    Task<CreateChatCompletionOutput> CreateChatCompletionAsync(CreateChatCompletionInput input);
}
