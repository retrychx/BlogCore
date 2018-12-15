using System;
using Microsoft.Extensions.Caching.Memory;

namespace Blog.Core.AOP
{
    /// <summary>
    /// 实例化缓存接口ICaching
    /// </summary>
    public class MemoryCaching : ICaching
    {
        private IMemoryCache cache;

        public MemoryCaching(IMemoryCache cache)
        {
            this.cache = cache;
        }

        public object Get(string cacheKey)
        {
            return cache.Get(cacheKey);
        }

        public void Set(string cacheKey, object cacheValue)
        {
            cache.Set(cacheKey, cacheValue, TimeSpan.FromSeconds(7200));
        }
    }
}
