using ApplicationInterfaces.ExternalServices.Dtos.Enums;

namespace ApplicationInterfaces.ExternalServices.Dtos;

public record VectorSearchOutput
{
    public string Query { get; }

    public VectorSearchEngineType EngineType { get; }

    public long TotalMatcheCount { get; }

    public IReadOnlyCollection<VectorSearchResult> Results { get; } = [];

    public VectorSearchOutput(
        string query,
        VectorSearchEngineType engineType,
        long totalMatchCount,
        IReadOnlyCollection<VectorSearchResult> results
    )
    {
        Query = query;
        EngineType = engineType;
        TotalMatcheCount = totalMatchCount;
        Results = results;
    }
}