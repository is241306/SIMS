using StackExchange.Redis;

namespace api.Services.Interfaces
{
    public interface IRedisLogService
    {
        Task LogAsync(string level, string message, object? meta = null);

        Task<RedisValue[]> GetLatestLogsAsync(int count = 50);
    }
}