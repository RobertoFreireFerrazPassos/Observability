using LogLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using OrderApi.Clients;

namespace OrderApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ICatalogClient _catalogClient;

        private ILogRequestService _logRequestService;

        public OrderController(
            ICatalogClient catalogClient,
            ILogRequestService logRequestService)
        {
            _catalogClient = catalogClient;
            _logRequestService = logRequestService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(CancellationToken token)
        {
            try
            {
                Request.Headers.TryGetValue("X-TraceId", out var traceIdHeader);

                var product = await _catalogClient.GetAsync(token, traceIdHeader);

                var result = new
                {
                    Product = product,
                    OrderId = Guid.NewGuid()
                };

                // Bug
                //_logRequestService.AdditionalData.Add("response", result);
                
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}