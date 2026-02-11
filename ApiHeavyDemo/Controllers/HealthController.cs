using Microsoft.AspNetCore.Mvc;

namespace ApiHeavyDemo.Controllers
{
    [ApiController]
    [Route("api/health")]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        public IActionResult Check()
        {
            return Ok(new
            {
                status = "OK",
                service = "ApiHeavyDemo",
                time = DateTime.Now
            });
        }
    }
}
