using System;
using System.Text;
using Newtonsoft.Json;

namespace Blog.Core.Common.Helper
{
    /// <summary>
    /// 序列化
    /// </summary>
    public class SerializeHelper
    {
        /// <summary>
        /// 序列化
        /// </summary>
        /// <returns>The serialize.</returns>
        /// <param name="item">Item.</param>
        public static byte[] Serialize(object item)
        {
            var jsonString = JsonConvert.SerializeObject(item);

            return Encoding.UTF8.GetBytes(jsonString);
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <returns>The deserialize.</returns>
        /// <param name="value">Value.</param>
        /// <typeparam name="TEntity">The 1st type parameter.</typeparam>
        public static TEntity Deserialize<TEntity>(byte[] value)
        {
            if (value == null)
            {
                return default(TEntity);
            }

            var jsonString = Encoding.UTF8.GetString(value);

            return JsonConvert.DeserializeObject<TEntity>(jsonString);
        }
    }
}
