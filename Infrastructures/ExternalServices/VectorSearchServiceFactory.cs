using ApplicationInterfaces.ExternalServices;
using ApplicationInterfaces.ExternalServices.Dtos.Enums;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructures.ExternalServices;

public class VectorSearchServiceFactory
{
    private readonly IServiceProvider _serviceProvider;

    public VectorSearchServiceFactory(IServiceProvider serviceProvider)
        => _serviceProvider = serviceProvider;

    public IVectorSearchService Create(VectorSearchEngineType engine)
        => engine switch
        {
            _ => _serviceProvider.GetRequiredService<QdrantSearchService>()
        };
}
