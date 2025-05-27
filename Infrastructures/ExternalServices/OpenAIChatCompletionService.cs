using Domain.ExternalServices;
using ServiceInterfaces.Chats.Dtos;

namespace Infrastructures.ExternalServices;

public class OpenAIChatCompletionService : IChatCompletionService
{
    private readonly HttpClient _httpClient;

    public OpenAIChatCompletionService(HttpClient httpClient)
        => _httpClient = httpClient;

    public async Task<CreateChatCompletionOutput> CreateChatCompletionAsync(CreateChatCompletionInput input)
    {
    }
}
