using ApplicationInterfaces.ExternalServices;
using ApplicationInterfaces.ExternalServices.Dtos;
using ApplicationInterfaces.ExternalServices.Dtos.Enums;

namespace Infrastructures.ExternalServices;

public class WebSearchContextProvider : IContextProvider
{
    private readonly WebSearchServiceFactory _factory;

    public WebSearchContextProvider(WebSearchServiceFactory factory)
        => _factory = factory;

    public async Task<Context> GetContextAsync(CancellationToken cancellationToken = default)
    {
        Console.WriteLine("🔍 Web検索中");

        var service = _factory.Create(WebSearchEngineType.Google);
        var output = await service.SearchAsync(
            new WebSearchInput("hogeta"),
            cancellationToken
        );

        var context = new Context(
            new ContextItem(SourceType.WebSearch, "ほげーた")
        );

        Console.WriteLine("🔍 Web検索終了");
        return context;
    }

    public async Task<Context> GetContextAsync(Context prevContext, CancellationToken cancellationToken = default)
    {
        Console.WriteLine("🔍 Web検索中");
        Console.WriteLine("== 過去のコンテキスト ==");
        foreach (var item in prevContext.ContextItems)
        {
            Console.WriteLine($"{item.SourceType}: {item.Content}");
        }
        Console.WriteLine("=====================");

        var service = _factory.Create(WebSearchEngineType.Google);
        var output = await service.SearchAsync(
            new WebSearchInput("hogeta"),
            cancellationToken
        );

        prevContext.Add(
            new Context(
            new ContextItem(SourceType.WebSearch, "ほげーた")
            )
        );

        Console.WriteLine("🔍 Web検索終了");
        return prevContext;
    }
}
