using System;

namespace Blog.Core.Common
{
    /// <summary>
    /// 这个Attribute就是在使用时候的验证，把它添加到要缓存数据的方法中，即可完成缓存的操作
    /// </summary>
    [AttributeUsage(AttributeTargets.Method,Inherited = true)]
    public class CachingAttribute : Attribute
    {
        //缓存过期时间
        public int AbsoluteExpiration { get; set; } = 30;
    }
}
