using System;
using SqlSugar;

namespace Blog.Core.Repository.sugar
{
    public class DbContext
    {
        private static string connectionString;
        private static DbType dbType;
        private SqlSugarClient db;

        /// <summary>
        /// 私有构造函数
        /// </summary>
        private DbContext()
        {

        }

        /// <summary>
        /// 连接字符串
        /// </summary>
        /// <value>The connection string.</value>
        public static string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }

        /// <summary>
        /// 数据库类型
        /// </summary>
        /// <value>The type of the db.</value>
        public static DbType DbType
        {
            get { return dbType; }
            set { dbType = value; }
        }

        /// <summary>
        /// 数据库连接对象
        /// </summary>
        /// <value>The db.</value>
        public SqlSugarClient Db
        {
            get { return db; }
            set { db = value; }
        }

        /// <summary>
        /// 数据库上下文实例
        /// </summary>
        /// <value>The context.</value>
        public static DbContext Context
        {
            get { return new DbContext(); }
        }
    }
}
