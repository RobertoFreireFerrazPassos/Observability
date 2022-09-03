using Microsoft.AspNetCore.Mvc;

namespace Gateway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CancellationTokenController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancelationToken)
        {
            await Task.Delay(TimeSpan.FromSeconds(10), cancelationToken);

            return Ok("Response");
        }
    }
}