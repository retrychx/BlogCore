using System;
namespace Blog.Core.Common.Redis
{
    public interface IRedisCacheManager
    {
        /// <summary>
        /// 获取
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="key">Key.</param>
        /// <typeparam name="TEntity">The 1st type parameter.</typeparam>
        TEntity Get<TEntity>(string key);

        /// <summary>
        /// 设置
        /// </summary>
        /// <param name="key">Key.</param>
        /// <param name="value">Value.</param>
        /// <param name="cacheTime">Cache time.</param>
        void Set(string key, object value, TimeSpan cacheTime);

        /// <summary>
        /// 判断是否存在
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="key">Key.</param>
        bool Get(string key);

        /// <summary>
        /// 移除
        /// </summary>
        /// <param name="key">Key.</param>
        void Remove(string key);

        /// <summary>
        /// 清除
        /// </summary>
        void Clear();
    }
}
