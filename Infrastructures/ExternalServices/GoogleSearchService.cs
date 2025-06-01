using ApplicationInterfaces.ExternalServices;
using ApplicationInterfaces.ExternalServices.Dtos;
using ApplicationInterfaces.ExternalServices.Dtos.Enums;
using Infrastructures.Configures;
using Infrastructures.ExternalServices.Dtos;
using Microsoft.Extensions.Options;

namespace Infrastructures.ExternalServices;

public class GoogleSearchService : IWebSearchService
{
    private readonly GoogleSearchQueryBuilder _queryBuilder;
    private readonly HttpClient _httpClient;
    private readonly GoogleSearchSettings _settings;

    public GoogleSearchService(
        GoogleSearchQueryBuilder queryBuilder,
        HttpClient httpClient,
        IOptions<GoogleSearchSettings> settings
    )
    {
        _queryBuilder = queryBuilder;
        _httpClient = httpClient;
        _settings = settings.Value;
    }

    public Task<WebSearchOutput> SearchAsync(WebSearchInput input, CancellationToken cancellationToken = default)
        => Task.FromResult(new WebSearchOutput(
            "Google Custom Search - 今日 四日市 天気",
            WebSearchEngineType.Google,
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
