using Gateway.Extensions;

namespace Gateway.Clients
{
    public class OrderClient : IOrderClient
    {
        private readonly HttpClient _httpClient;

        public OrderClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> SendAsync(HttpContext context)
        {
            var uri = _httpClient.BaseAddress ?? throw new ArgumentNullException("No BaseAddress");

            var result = await _httpClient.SendAsync(
                context.CreateProxyHttpRequest(uri), 
                HttpCompletionOption.ResponseHeadersRead, 
                context.RequestAborted);

            return result;
        }
    }
}
