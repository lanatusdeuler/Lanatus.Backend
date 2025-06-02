using ApplicationInterfaces.ExternalServices;
using ApplicationInterfaces.ExternalServices.Dtos;
using ApplicationInterfaces.ExternalServices.Dtos.Enums;

namespace Infrastructures.ExternalServices;

public class QdrantSearchService : IVectorSearchService
{
    private readonly HttpClient _httpClient;

    public QdrantSearchService(HttpClient httpClient)
        => _httpClient = httpClient;

    public Task<VectorSearchOutput> SearchAsync(VectorSearchInput input, CancellationToken cancellationToken = default)
        => Task.FromResult(new VectorSearchOutput(
            "ほげーたってなに",
            VectorSearchEngineType.Qdrant,
            1,
            [new("1", 2.3f, "気位の高い", null)]
        ));
}
