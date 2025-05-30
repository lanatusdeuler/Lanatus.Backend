using ApplicationInterfaces.ExternalServices.Dtos;

namespace ApplicationInterfaces.ExternalServices;

public interface IChatCompletionService
{
    Task<CreateChatCompletionOutput> CreateChatCompletionAsync(CreateChatCompletionInput input);
}
