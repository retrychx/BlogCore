using System;
using Blog.Core.Common.Helper;
using StackExchange.Redis;

namespace Blog.Core.Common.Redis
{
    public class RedisCacheManager : IRedisCacheManager
    {
        private readonly string redisConnectionString;

        public volatile ConnectionMultiplexer redisConnection;

        private readonly object redisConnectionLock = new object();

        public RedisCacheManager()
        {
            var redisConfiguration = Appsettings.app(new string[] { "AppSettings", "RedisCaching", "ConnectionString" });

            if (string.IsNullOrWhiteSpace(redisConfiguration))
            {
                throw new ArgumentException("redis config is empty", nameof(redisConnection));
            }

            this.redisConnectionString = redisConfiguration;
            this.redisConnection = GetRedisConnection();
        }

        private ConnectionMultiplexer GetRedisConnection()
        {
            //如果已经连接实例，直接返回
            if (this.redisConnection != null && this.redisConnection.IsConnected)
            {
                return this.redisConnection;
            }

            //加锁，防止在异步编程中，出现单利无效的问题
            lock (redisConnectionLock)
            {
                if (this.redisConnection != null)
                {
                    //释放redis连接
                    this.redisConnection.Dispose();
                }

                this.redisConnection = ConnectionMultiplexer.Connect(redisConnectionString);
            }

            return this.redisConnection;
        }

        public void Clear()
        {
            foreach (var endPoint in this.GetRedisConnection().GetEndPoints())
            {
                var server = this.GetRedisConnection().GetServer(endPoint);
                foreach (var key in server.Keys())
                {
                    redisConnection.GetDatabase().KeyDelete(key);
                }
            }
        }

        public TEntity Get<TEntity>(string key)
        {
            var value = redisConnection.GetDatabase().StringGet(key);

            if (value.HasValue)
            {
                return SerializeHelper.Deserialize<TEntity>(value);
            }

            return default(TEntity);
        }

        public bool Get(string key)
        {
            return redisConnection.GetDatabase().KeyExists(key);
        }

        public void Remove(string key)
        {
            redisConnection.GetDatabase().KeyDelete(key);
        }

        public void Set(string key, object value, TimeSpan cacheTime)
        {
            if (value != null)
            {
                redisConnection.GetDatabase().StringSet(key, SerializeHelper.Serialize(value), cacheTime);
            }
        }
    }
}
