using ApplicationInterfaces.ExternalServices;
using ApplicationInterfaces.ExternalServices.Dtos;
using Microsoft.Extensions.Logging;

namespace Infrastructures.ExternalServices;

public class LoggingContextProvider : IContextProvider
{
    private readonly ILogger<LoggingContextProvider> _logger;
    private string _content = string.Empty;

    public LoggingContextProvider(ILogger<LoggingContextProvider> logger)
        => _logger = logger;

    public void SetContent(string content)
        => _content = content;

    public Task<Context> GetContextAsync(CancellationToken cancellationToken = default)
    {
        Console.WriteLine(_content);
        return Task.FromResult(new Context());
    }

    public Task<Context> GetContextAsync(Context prevContext, CancellationToken cancellationToken = default)
    {
        Console.WriteLine(_content);
        return Task.FromResult(prevContext);
    }
}

