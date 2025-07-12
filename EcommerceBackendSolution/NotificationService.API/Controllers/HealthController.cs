using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NotificationService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok("NotificationService is running.");
    }
}
