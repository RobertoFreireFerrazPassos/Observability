using Microsoft.AspNetCore.Mvc;

namespace CatalogApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken token)
        {
            try
            {
                await Task.Delay(TimeSpan.FromSeconds(4), token);

                return Ok("Product");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}