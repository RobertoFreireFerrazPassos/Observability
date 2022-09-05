using CatalogApi.Dtos;
using LogLibrary.Services;
using Microsoft.AspNetCore.Mvc;

namespace CatalogApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogController : ControllerBase
    {
        private ILogRequestService _logRequestService;
        public CatalogController(ILogRequestService logRequestService)
        {
            _logRequestService = logRequestService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken token)
        {
            try
            {
                await Task.Delay(TimeSpan.FromSeconds(4), token);

                var response = new ProductDto()
                {
                    SkuCode = "9123467",
                    Name = "Ball",
                    Price = "23.40"
                };

                _logRequestService.AdditionalData.Add("response", response);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}