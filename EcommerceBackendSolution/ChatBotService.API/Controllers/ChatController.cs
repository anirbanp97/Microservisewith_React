using ChatBotService.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatBotService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly IChatService _chatService;

        public ChatController(IChatService chatService)
        {
            _chatService = chatService;
        }

        [HttpPost("ask")]
        public async Task<IActionResult> Ask([FromQuery] string userId, [FromBody] string query)
        {
            await _chatService.SaveUserQueryAsync(userId, query);
            return Ok(new { reply = "(AI response will come here)" });
        }

        [HttpGet("history")]
        public async Task<IActionResult> History([FromQuery] string userId)
        {
            var history = await _chatService.GetUserHistoryAsync(userId);
            return Ok(history);
        }
    }
}
