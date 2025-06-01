using System.Text;
using Microsoft.Extensions.Logging;

namespace Infrastructures.ExternalServices.Dtos;

public class GoogleSearchQueryBuilder
{
    private readonly Dictionary<string, string> _queries = [];
    private readonly ILogger<GoogleSearchQueryBuilder> _logger;

    public GoogleSearchQueryBuilder(ILogger<GoogleSearchQueryBuilder> logger)
        => _logger = logger;

    public GoogleSearchQueryBuilder AppendQuery(string? key, string? query)
    {
        if (key is null || query is null)
        {
            return this;
        }

        if (_queries.ContainsKey(key))
        {
            _logger.LogError("既に指定されているキーのクエリを設定しようとしました。");
            return this;
        }

        _queries.TryAdd(key, Uri.EscapeDataString(query));
        return this;
    }

    public string Build()
    {
        if (!_queries.ContainsKey("q"))
        {
            _logger.LogError("qは必須パラメータです");
            throw new ArgumentException();
        }

        if (!_queries.ContainsKey("cx"))
        {
            _logger.LogError("cxは必須パラメータです");
            throw new ArgumentException();
        }

        var builder = new StringBuilder("?");
        var pairs = _queries
            .Select(kvp => $"{kvp.Key}={kvp.Value}");

        builder.AppendJoin("&", pairs);
        return builder.ToString();
    }
}
