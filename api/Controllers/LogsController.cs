using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using api.Services.Interfaces;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LogsController : ControllerBase
    {
        private readonly IRedisLogService _redisLogService;

        public LogsController(IRedisLogService redisLogService)
        {
            _redisLogService = redisLogService;
        }

        [HttpGet("latest")]
        public async Task<IActionResult> GetLatestLogs(int count = 50)
        {
            // Fetch the latest logs from Redis
            var logs = await _redisLogService.GetLatestLogsAsync(count);

            // Deserialize JSON entries for readability
            var deserialized = logs.Select(x => JsonSerializer.Deserialize<object>(x)).ToList();

            return Ok(deserialized);
        }
    }
}