﻿using System;
using System.Linq;
using Blog.Core.Common;
using Castle.DynamicProxy;

namespace Blog.Core.AOP
{
    /// <summary>
    /// 面向切面的缓存使用
    /// </summary>
    public class BlogCacheAOP : IInterceptor
    {
        //通过注入的方式，把缓存操作接口通过构造函数注入
        private ICaching cache;

        public BlogCacheAOP(ICaching cache)
        {
            this.cache = cache;
        }

        //Intercept方法是拦截的关键所在，也是IInterceptor接口中的唯一定义
        public void Intercept(IInvocation invocation)
        {
            var method = invocation.MethodInvocationTarget ?? invocation.Method;

            var qCachingAttribute = method.GetCustomAttributes(true).FirstOrDefault(s => s.GetType() == typeof(CachingAttribute)) as CachingAttribute;

            if (qCachingAttribute != null)
            {
                //获取自定义缓存键
                var cacheKey = CustomCacheKey(invocation);
                //根据key获取相应的缓存值
                var cacheValue = cache.Get(cacheKey);
                if (cacheValue != null)
                {
                    //将当前获取到的缓存值，赋值给当前执行方法
                    invocation.ReturnValue = cacheValue;
                    return;
                }

                invocation.Proceed();

                //存入缓存
                if (!string.IsNullOrWhiteSpace(cacheKey))
                {
                    cache.Set(cacheKey, invocation.ReturnValue);
                }
            }
            else
            {
                invocation.Proceed(); //直接执行被拦截方法
            }
        }

        //自定义缓存键
        private string CustomCacheKey(IInvocation invocation)
        {
            var typeName = invocation.TargetType.Name;
            var methodName = invocation.Method.Name;
            // 获取参数列表，最多获取三个
            var methodArguments = invocation.Arguments.Select(GetArgumentValue).Take(3).ToList();

            var key = $"{typeName}:{methodName}:";
            foreach (var item in methodArguments)
            {
                key += $"{item}:";
            }

            return key.TrimEnd(':');
        }

        //object 转 string
        private string GetArgumentValue(object arg)
        {
            if (arg is int || arg is long || arg is string)
            {
                return arg.ToString();
            }

            if (arg is DateTime)
            {
                return ((DateTime)arg).ToString("yyyyMMddHHmmss");
            }

            return "";
        }
    }
}
