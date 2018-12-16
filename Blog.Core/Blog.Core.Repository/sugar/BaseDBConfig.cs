using System;
using Blog.Core.Common.Helper;

namespace Blog.Core.Repository.sugar
{
    public class BaseDBConfig
    {
        public static string ConnectionString = Appsettings.app(new string[] { "AppSettings", "SqlServer", "SqlServerConnection" });
    }
}
