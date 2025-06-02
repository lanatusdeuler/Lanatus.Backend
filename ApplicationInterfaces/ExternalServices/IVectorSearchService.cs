using ApplicationInterfaces.ExternalServices.Dtos;

namespace ApplicationInterfaces.ExternalServices;

public interface IVectorSearchService
{
    Task<VectorSearchOutput> SearchAsync(VectorSearchInput input, CancellationToken cancellationToken);
}
