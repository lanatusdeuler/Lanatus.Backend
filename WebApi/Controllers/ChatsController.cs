using Infrastructures.ExternalServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

/// <summary>
/// チャット関連のコントローラ
/// </summary>
[Route("[controller]")]
[ApiController]
public class ChatsController : ControllerBase
{
    [HttpGet("test")]
    public async Task TestAsync(
        [FromServices] ContextProviderBuilder builder
    )
    {
        var provider = builder
            .AddVectorSearch()
            .AddWebSearch()
            .Build();

        var baseProvider = builder
            .AddVectorSearch()
            .AddWebSearch()
            .UseLogging("🔁別のProvider")
            .AddProvider(provider)
            .Build();

        var context = await baseProvider.GetContextAsync();

        foreach (var item in context.ContextItems)
        {
            Console.WriteLine($"{item.SourceType}: {item.Content}");
        }
    }
}
