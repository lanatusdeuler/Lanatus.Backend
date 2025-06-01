using ApplicationInterfaces.ExternalServices;
using ApplicationInterfaces.ExternalServices.Dtos;
using ApplicationInterfaces.ExternalServices.Dtos.Enums;
using Infrastructures.Configures;
using Microsoft.Extensions.Options;

namespace Infrastructures.ExternalServices;

public class BingSearchService : IWebSearchService
{
    private readonly BingSearchSettings _settings;
    private readonly HttpClient _httpClient;

    public BingSearchService(
        IOptions<BingSearchSettings> settings,
        HttpClient httpClient
    )
    {
        _settings = settings.Value;
        _httpClient = httpClient;
    }

    public Task<WebSearchOutput> SearchAsync(WebSearchInput input, CancellationToken cancellationToken = default)
        => Task.FromResult(new WebSearchOutput(
            "Google Custom Search - 今日 四日市 天気",
            WebSearchEngineType.Bing,
            10,
            [
                new (
                    1,
                    new Uri("https://tenki.jp/forecast/5/27/5310/24202/1hour.html"),
                    "四日市市の1時間天気",
                    "四日市市の天気",
                    "application/json",
                    null,
                    null
                )
            ]
        ));
}
