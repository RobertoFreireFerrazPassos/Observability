using Microsoft.Extensions.Primitives;

namespace OrderApi.Clients
{
    public class CatalogClient : ICatalogClient
    {
        private readonly HttpClient _httpClient;

        public CatalogClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetAsync(CancellationToken token, StringValues header)
        {
            using (var requestMessage = new HttpRequestMessage(HttpMethod.Get, "/Catalog"))
            {
                requestMessage.Headers.Add("X-TraceId", header.ToString());

                using (var response = await _httpClient.SendAsync(requestMessage, token))
                {
                    return await response.Content.ReadAsStringAsync();
                }
            }
        }
    }
}
