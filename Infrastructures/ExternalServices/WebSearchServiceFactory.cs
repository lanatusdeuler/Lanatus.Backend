using ApplicationInterfaces.ExternalServices;
using ApplicationInterfaces.ExternalServices.Dtos.Enums;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructures.ExternalServices;

public class WebSearchServiceFactory
{
    private readonly IServiceProvider _serviceProvider;

    public WebSearchServiceFactory(IServiceProvider serviceProvider)
        => _serviceProvider = serviceProvider;

    public IWebSearchService Create(WebSearchEngineType engine)
        => engine switch
        {
            WebSearchEngineType.Google => _serviceProvider.GetRequiredService<GoogleSearchService>(),
            WebSearchEngineType.Bing => _serviceProvider.GetRequiredService<BingSearchService>(),
            _ => _serviceProvider.GetRequiredService<GoogleSearchService>()
        };
}
