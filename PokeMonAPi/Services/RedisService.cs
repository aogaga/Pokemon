using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis;

namespace PokeMonAPi.Services;

public class RedisService(string configuration) : IRedis
{
    private readonly ConnectionMultiplexer _redis = ConnectionMultiplexer.Connect(configuration);

    public async Task<RedisValue> ReadValueAsync(string key)
    {
        var cache = _redis.GetDatabase();

        var result = await cache.StringGetAsync(key);

        return result;
    }

    public async Task WritetValueAsync(string key, string value,
        DistributedCacheEntryOptions distributedCacheEntryOptions)
    {
        var cache = _redis.GetDatabase();

        // Use StringSetAsync to store the value
        await cache.StringSetAsync(key, value, distributedCacheEntryOptions.AbsoluteExpirationRelativeToNow);
    }
}