using ApplicationInterfaces.ExternalServices.Dtos.Enums;

namespace ApplicationInterfaces.ExternalServices.Dtos;

public record VectorSearchInput
{
    public string Query { get; }

    public float[] EmbeddingVector { get; }

    public int TopK { get; }

    public VectorSearchDistanceMetrics DistanceMetric { get; set; } = VectorSearchDistanceMetrics.Cosine;

    public float ScoreThreshold { get; set; }

    public VectorSearchInput(
        string query,
        float[] embeddingVector,
        int topK,
        VectorSearchDistanceMetrics distanceMetrics,
        float scoreThreshold
    )
    {
        Query = query;
        EmbeddingVector = embeddingVector;
        TopK = topK;
        DistanceMetric = distanceMetrics;
        ScoreThreshold = scoreThreshold;
    }
}
