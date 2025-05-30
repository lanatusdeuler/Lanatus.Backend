using System.Net.Mime;
using System.Text;
using System.Text.Json;
using ApplicationInterfaces.ExternalServices;
using ApplicationInterfaces.ExternalServices.Dtos;
using Infrastructures.ExternalServices.Dtos;

namespace Infrastructures.ExternalServices;

public class OpenAIChatCompletionService : IChatCompletionService
{
    private readonly HttpClient _httpClient;

    public OpenAIChatCompletionService(HttpClient httpClient)
        => _httpClient = httpClient;

    public async Task<CreateChatCompletionOutput> CreateChatCompletionAsync(CreateChatCompletionInput input)
    {
        var request = new OpenAIChatCompletionInput
        {
            Model = input.ModelName,
            Messages = input.Messages.Select(message => new OpenAIChatMessage
            {
                Role = message.Role,
                Content = message.Content
            }).ToList()
        };

        var json = JsonSerializer.Serialize(request);
        var content = new StringContent(json, Encoding.UTF8, MediaTypeNames.Application.Json);
        var response = await _httpClient.PostAsync("/v1/chat/completions", content);
        var result = await response.Content.ReadAsStringAsync();
        return new CreateChatCompletionOutput("assistant", "hoge");
    }
}
