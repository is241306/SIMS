using StackExchange.Redis;

namespace api.Services.Interfaces
{
    public interface IRedisLogService
    {
        /// <summary>
        /// Add a log entry to Redis.
        /// </summary>
        Task LogAsync(string level, string message, object? meta = null);

        /// <summary>
        /// Get the latest N logs.
        /// </summary>
        Task<RedisValue[]> GetLatestLogsAsync(int count = 50);
    }
}