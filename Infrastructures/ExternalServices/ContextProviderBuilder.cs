using ApplicationInterfaces.ExternalServices;

namespace Infrastructures.ExternalServices;

public class ContextProviderBuilder
{
    private readonly Func<WebSearchContextProvider> _webSearchDelegate;
    private readonly Func<VectorSearchContextProvider> _vectorSearchDelegate;
    private readonly Func<LoggingContextProvider> _loggingDelegate;
    private CompositeContextProvider _provider;

    public ContextProviderBuilder(
        Func<WebSearchContextProvider> webSearchDelegate,
        Func<VectorSearchContextProvider> vectorSearchDelegate,
        Func<LoggingContextProvider> loggingDelegate
    )
    {
        _webSearchDelegate = webSearchDelegate;
        _vectorSearchDelegate = vectorSearchDelegate;
        _loggingDelegate = loggingDelegate;
        _provider = new();
    }

    public ContextProviderBuilder AddWebSearch()
    {
        var provider = _webSearchDelegate();
        _provider.AddProvider(provider);
        return this;
    }

    public ContextProviderBuilder AddVectorSearch()
    {
        var provider = _vectorSearchDelegate();
        _provider.AddProvider(provider);
        return this;
    }

    public ContextProviderBuilder AddProvider(IContextProvider provider)
    {
        _provider.AddProvider(provider);
        return this;
    }

    public ContextProviderBuilder UseLogging(string content)
    {
        var provider = _loggingDelegate();
        provider.SetContent(content);
        _provider.AddProvider(provider);
        return this;
    }

    public IContextProvider Build()
    {
        var provider = _provider;
        _provider = new();

        return provider;
    }
}
