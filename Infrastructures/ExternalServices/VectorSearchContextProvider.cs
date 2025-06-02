using ApplicationInterfaces.ExternalServices;
using ApplicationInterfaces.ExternalServices.Dtos;
using ApplicationInterfaces.ExternalServices.Dtos.Enums;

namespace Infrastructures.ExternalServices;

public class VectorSearchContextProvider : IContextProvider
{
    private readonly VectorSearchServiceFactory _factory;

    public VectorSearchContextProvider(VectorSearchServiceFactory factory)
        => _factory = factory;

    public async Task<Context> GetContextAsync(CancellationToken cancellationToken = default)
    {
        Console.WriteLine("🔍 Vector検索中");
        var service = _factory.Create(VectorSearchEngineType.Qdrant);
        var output = await service.SearchAsync(
            new VectorSearchInput(
                "hogeta",
                [],
                1,
                VectorSearchDistanceMetrics.Cosine,
                10
            ),
            cancellationToken
        );

        var context = new Context(
            new ContextItem(SourceType.VectorSearch, "ほげーた")
        );

        Console.WriteLine("🔍 Vector検索終了");
        return context;
    }

    public async Task<Context> GetContextAsync(Context prevContext, CancellationToken cancellationToken = default)
    {
        Console.WriteLine("🔍 Vector検索中");
        Console.WriteLine("== 過去のコンテキスト ==");
        foreach (var item in prevContext.ContextItems)
        {
            Console.WriteLine($"{item.SourceType}: {item.Content}");
        }
        Console.WriteLine("=====================");

        var service = _factory.Create(VectorSearchEngineType.Qdrant);
        var output = await service.SearchAsync(
            new VectorSearchInput(
                "hogeta",
                [],
                1,
                VectorSearchDistanceMetrics.Cosine,
                10
            ),
            cancellationToken
        );

        prevContext.Add(
            new Context(
                new ContextItem(SourceType.VectorSearch, "ほげーた")
            )
        );

        Console.WriteLine("🔍 Vector検索終了");
        return prevContext;
    }
}
