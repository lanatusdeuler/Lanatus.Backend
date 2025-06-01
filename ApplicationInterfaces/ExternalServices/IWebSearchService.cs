using ApplicationInterfaces.ExternalServices.Dtos;

namespace ApplicationInterfaces.ExternalServices;

public interface IWebSearchService
{
    Task<WebSearchOutput> SearchAsync(WebSearchInput input, CancellationToken cancellationToken = default);
}
