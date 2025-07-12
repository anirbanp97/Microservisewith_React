using LoggingService.Infrastructure.Models;
using LoggingService.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoggingService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LogController : ControllerBase
    {
        private readonly LogService _logService;

        public LogController(LogService logService)
        {
            _logService = logService;
        }

        [HttpPost]
        public async Task<IActionResult> AddLog(LogEntry entry)
        {
            await _logService.AddLogAsync(entry);
            return Ok("Log saved.");
        }
    }
}
