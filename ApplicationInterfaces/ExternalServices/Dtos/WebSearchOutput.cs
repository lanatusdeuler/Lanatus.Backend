using ApplicationInterfaces.ExternalServices.Dtos.Enums;

namespace ApplicationInterfaces.ExternalServices.Dtos;

public record WebSearchOutput
{
    public string Query { get; }

    public WebSearchEngineType EngineType { get; }

    public long TotalResultCount { get; }

    public IReadOnlyCollection<WebSearchResult> Results { get; } = [];

    public WebSearchOutput(
        string query,
        WebSearchEngineType engineType,
        long totalResultCount,
        IReadOnlyCollection<WebSearchResult> results
    )
    {
        Query = query;
        EngineType = engineType;
        TotalResultCount = totalResultCount;
        Results = results;
    }
}
