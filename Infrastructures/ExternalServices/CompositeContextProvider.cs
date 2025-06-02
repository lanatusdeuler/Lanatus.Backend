using ApplicationInterfaces.ExternalServices;
using ApplicationInterfaces.ExternalServices.Dtos;

namespace Infrastructures.ExternalServices;

public class CompositeContextProvider : IContextProvider
{
    private readonly List<IContextProvider> _providers = [];

    public void AddProvider(params IContextProvider[] provider)
        => _providers.AddRange(provider);

    public async Task<Context> GetContextAsync(CancellationToken cancellationToken = default)
    {
        var context = new Context();

        foreach (var provider in _providers)
        {
            context = await provider.GetContextAsync(context, cancellationToken);
        }

        return context;
    }

    public async Task<Context> GetContextAsync(Context prevContext, CancellationToken cancellationToken = default)
    {
        foreach (var provider in _providers)
        {
            prevContext = await provider.GetContextAsync(prevContext, cancellationToken);
        }

        return prevContext;
    }
}
