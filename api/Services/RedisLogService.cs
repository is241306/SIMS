using StackExchange.Redis;
using System.Text.Json;
using api.Services.Interfaces;

namespace api.Services
{
    public class RedisLogService : IRedisLogService
    {
        private readonly IDatabase _db;
        private const string ListKey = "logs";

        public RedisLogService(IConnectionMultiplexer redis)
        {
            _db = redis.GetDatabase();
        }

        public async Task LogAsync(string level, string message, object? meta = null)
        {
            var entry = new
            {
                Timestamp = DateTime.UtcNow,
                Level = level,
                Message = message,
                Meta = meta
            };

            string json = JsonSerializer.Serialize(entry);
            await _db.ListRightPushAsync(ListKey, json);
        }

        public async Task<RedisValue[]> GetLatestLogsAsync(int count = 50)
        {
            return await _db.ListRangeAsync(ListKey, -count, -1);
        }
    }
}