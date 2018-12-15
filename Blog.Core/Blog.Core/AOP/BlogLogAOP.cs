using System;
using System.IO;
using System.Linq;
using Castle.DynamicProxy;

namespace Blog.Core.AOP
{
    /// <summary>
    /// 拦截器BlogLogAOP 继承IInterceptor接口
    /// </summary>
    public class BlogLogAOP : IInterceptor
    {
        /// <summary>
        /// 实例化IInterceptor的唯一方法
        /// </summary>
        /// <param name="invocation">Invocation.</param>
        public void Intercept(IInvocation invocation)
        {
            //记录拦截方法信息的日志信息
            var dataIntercept = $"{DateTime.Now.ToString("yyyyMMddHHmmss")} " +
                $"当前执行方法：{ invocation.Method.Name} " +
                $"参数是： {string.Join(", ", invocation.Arguments.Select(a => (a ?? "").ToString()).ToArray())} \r\n";

            //在被拦截的方法执行完毕后，继续执行当前方法
            invocation.Proceed();

            dataIntercept += ($"方法执行完毕，返回结果：{invocation.ReturnValue}");

            #region 输出到当前项目日志

            var path = Directory.GetCurrentDirectory() + @"\Log";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            var fileName = path + $@"\InterceptLog-{DateTime.Now.ToString("yyyyMMddHHmmss")}.log";

            var sw = File.AppendText(fileName);

            sw.WriteLine(dataIntercept);
            sw.Close();

            #endregion
        }
    }
}
