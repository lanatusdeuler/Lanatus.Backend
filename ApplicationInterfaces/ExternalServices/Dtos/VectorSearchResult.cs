namespace ApplicationInterfaces.ExternalServices.Dtos;

public record VectorSearchResult
{
    public string Id { get; }

    public float Score { get; }

    public string Content { get; }

    public IDictionary<string, object>? Metadata { get; init; }

    public VectorSearchResult(
        string id,
        float score,
        string content,
        IDictionary<string, object>? metadata = null
    )
    {
        Id = id;
        Score = score;
        Content = content;
        Metadata = metadata;
    }
}
