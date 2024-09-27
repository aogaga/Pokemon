using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis;

namespace PokeMonAPi.Services
{
    public interface IRedis
    {
        public Task<RedisValue> ReadValueAsync(string key);
        public Task WritetValueAsync(string key, string value, DistributedCacheEntryOptions distributedCacheEntryOptions);
    }
}
