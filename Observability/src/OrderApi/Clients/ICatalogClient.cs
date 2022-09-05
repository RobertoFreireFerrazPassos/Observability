using Microsoft.Extensions.Primitives;

namespace OrderApi.Clients
{
    public interface ICatalogClient
    {
        Task<string> GetAsync(CancellationToken token, StringValues header);
    }
}
