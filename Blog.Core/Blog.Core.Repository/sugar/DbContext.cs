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
            if(string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException("数据库连接字符串为空");
            }

            db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = connectionString,
                DbType = dbType,
                IsAutoCloseConnection = true,
                IsShardSameThread = true,
                ConfigureExternalServices = new ConfigureExternalServices
                {

                },
                MoreSettings = new ConnMoreSettings
                {
                    IsAutoRemoveDataCache = true
                },
            });
        }

        /// <summary>
        /// 私有构造函数
        /// </summary>
        /// <param name="isAutoCloseConnection">If set to <c>true</c> is auto close connection.</param>
        private DbContext(bool isAutoCloseConnection)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException("数据库连接字符串为空");
            }

            db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = connectionString,
                DbType = dbType,
                IsAutoCloseConnection = isAutoCloseConnection,
                IsShardSameThread = true,
                ConfigureExternalServices = new ConfigureExternalServices
                {

                },
                MoreSettings = new ConnMoreSettings
                {
                    IsAutoRemoveDataCache = true
                },
            });
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

        /// <summary>
        /// 获取数据库处理对象
        /// </summary>
        /// <returns>The entity db.</returns>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public SimpleClient<T> GetEntityDB<T>() where T :  class, new()
        {
            return new SimpleClient<T>(db);
        }

        /// <summary>
        /// 获取数据库对象
        /// </summary>
        /// <returns>The entity db.</returns>
        /// <param name="client">Client.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public SimpleClient<T> GetEntityDB<T>(SqlSugarClient client) where T : class, new()
        {
            return new SimpleClient<T>(client);
        }

        /// <summary>
        /// 根据数据库表生产实体类
        /// </summary>
        /// <param name="strPath">String path.</param>
        public void CreateClassFileByDBTable(string strPath)
        {
            CreateClassFileByDBTable(strPath, "Km.PosZC");
        }

        /// <summary>
        /// 根据数据库表生产实体类
        /// </summary>
        /// <param name="strPath">String path.</param>
        /// <param name="strNameSpace">String name space.</param>
        public void CreateClassFileByDBTable(string strPath,string strNameSpace)
        {
            CreateClassFileByDBTable(strPath, strNameSpace, null);
        }

        /// <summary>
        /// 根据数据库表生产实体类
        /// </summary>
        /// <param name="strPath">String path.</param>
        /// <param name="strNameSpace">String name space.</param>
        /// <param name="dstTableName">Dst table name.</param>
        public void CreateClassFileByDBTable(string strPath,
            string strNameSpace,
            string[] dstTableName)
        {

        }

        /// <summary>
        /// 根据数据库表生产实体类
        /// </summary>
        /// <param name="strPath">String path.</param>
        /// <param name="strNameSpace">String name space.</param>
        /// <param name="dstTableNames">Dst table names.</param>
        /// <param name="strInterface">String interface.</param>
        /// <param name="isSerializable">If set to <c>true</c> is serializable.</param>
        public void CreateClassFileByDBTable(
            string strPath,
            string strNameSpace,
            string[] dstTableNames,
            string strInterface,
            bool isSerializable = false)
        {
            if (dstTableNames != null && dstTableNames.Length > 0)
            {
                db.DbFirst.Where(dstTableNames).IsCreateDefaultValue().IsCreateAttribute()
                    .SettingClassTemplate(s => s = @"
                    {using}
                    namespace {NameSpace}
                    {
                        {ClassDescription}{SugarTable}" + (isSerializable ? "[Serializable]" : "") + @"
                        public partial class {ClassName}" + (string.IsNullOrEmpty(strInterface) ? "" : (" : " + strInterface)) + @"
                        {
                            public {ClassName} ()
                            {
                     {Constructor}
                            }
                     {PropertyName}
                            }
                     }
                     ")
                     .SettingPropertyTemplate(s => s = @"
                     {SugarColumn}
                     public {PropertyType} {PropertyName}
                     {
                        get
                        {
                            return _(PropertyName};
                        }
                        set
                        {
                            if(_{PropertyName} != value)
                            {
                                base.SetValeCall(" + "\"{PropertyName}\",_{PropertyName}" + @");
                            }
                            _{PropertyName}=value;
                        }
                    }")
                    .SettingPropertyDescriptionTemplate(s => s = "           private {PropertyType} _{PropertyName};\r\n" + s)
                    .SettingConstructorTemplate(s => s = "           this._{PropertyName} ={DefaultValue};")
                    .CreateClassFile(strPath, strNameSpace);
            }
            else
            {
                db.DbFirst.IsCreateAttribute().IsCreateDefaultValue()
                    .SettingClassTemplate(s => s = @"
                        {using}
                        namespace {Namespace}
                        {
                            {ClassDescription}{SugarTable}" + (isSerializable ? "[Serializable]" : "") + @"
                            public partial class {ClassName}" + (string.IsNullOrEmpty(strInterface) ? "" : (" : " + strInterface)) + @"
                            {
                                public {ClassName}()
                                {
                            {Constructor}
                                }
                            {PropertyName}
                                }
                        }
                        ")
                    .SettingPropertyTemplate(s => s = @"
                        {SugarColumn}
                        public {PropertyType} {PropertyName}
                        {
                            get
                            {
                                return _{PropertyName};
                            }
                            set
                            {
                                if(_{PropertyName} != value)
                                {
                                    base.SetValueCall(" + "\"{PropertyName}\",_{PropertyName}" + @");
                                }
                                _{PropertyName}=value;
                            }
                        }")
                    .SettingPropertyDescriptionTemplate(s => s = "      private {PropertyType} _{PropertyName};\r\n" + s)
                    .SettingConstructorTemplate(s => s = "       this._{PropertyName} ={DefaultValue};")
                    .CreateClassFile(strPath, strNameSpace);
            }
        }

        public void CreateTableByEntity<T>(bool isBackUpTable,params T[] dstEntitys) where T : class, new()
        {
            Type[] dstTypes = null;
            if (dstEntitys != null)
            {
                dstTypes = new Type[dstEntitys.Length];
                for (int i = 0; i < dstEntitys.Length; i++)
                {
                    T t = dstEntitys[i];
                    dstTypes[i] = typeof(T);
                }
            }

            CreateTableByEntity(isBackUpTable, dstTypes);
        }

        public void CreateTableByEntity(bool isBackUpTable, params Type[] dstEntitys)
        {
            if (isBackUpTable)
            {
                db.CodeFirst.BackupTable().InitTables(dstEntitys);
            }
            else
            {
                db.CodeFirst.InitTables(dstEntitys);
            }
        }

        public static DbContext GetDbContext(bool isAutoCloseConnection = true)
        {
            return new DbContext(isAutoCloseConnection);
        }

        public static void Init(string strConnectionString ,DbType enmDbType = SqlSugar.DbType.MySql)
        {
            connectionString = strConnectionString;
            dbType = enmDbType;
        }

        public static ConnectionConfig GetConnectionConfig(bool isAutoCloseConnection = true,bool isShardSameThread = false)
        {
            ConnectionConfig config = new ConnectionConfig()
            {
                ConnectionString = connectionString,
                DbType = dbType,
                IsAutoCloseConnection = isAutoCloseConnection,
                ConfigureExternalServices = new ConfigureExternalServices
                {

                },
                IsShardSameThread = isShardSameThread
            };

            return config;
        }

        public static SqlSugarClient GetCustomDB(ConnectionConfig config)
        {
            return new SqlSugarClient(config);
        }

        public static SimpleClient<T> GetCustopmEntityDB<T>(SqlSugarClient sugarClient) where T : class, new ()
        {
            return new SimpleClient<T>(sugarClient);
        }
    }
}
