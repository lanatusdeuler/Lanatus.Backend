using ApplicationInterfaces.ExternalServices.Dtos;

namespace ApplicationInterfaces.ExternalServices;

public interface IContextProvider
{
    Task<Context> GetContextAsync(CancellationToken cancellationToken = default);

    Task<Context> GetContextAsync(Context prevContext, CancellationToken cancellationToken = default);
}
