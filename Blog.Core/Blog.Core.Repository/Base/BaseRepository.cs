using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Blog.Core.Common.Helper;
using Blog.Core.IRepository.Base;
using Blog.Core.Repository.sugar;
using SqlSugar;

namespace Blog.Core.Repository.Base
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, new()
    {
        private DbContext context;
        private SqlSugarClient db;
        private SimpleClient<TEntity> entityDB;

        public DbContext Context
        {
            get { return context; }
            set { context = value; }
        }

        internal SqlSugarClient Db
        {
            get { return db; }
            private set { db = value; }
        }

        internal SimpleClient<TEntity> EntityDB
        {
            get { return entityDB; }
            private set { entityDB = value; }
        }

        public BaseRepository()
        {
            //var connectionString = Appsettings.app(new string[] { "AppSettings", "SqlServer", "SqlServerConnection" });
            DbContext.Init(BaseDBConfig.ConnectionString);
            context = DbContext.GetDbContext();
            db = context.Db;
            entityDB = context.GetEntityDB<TEntity>(db);
        }

        public async Task<TEntity> QueryByID(object objId)
        {
            return await Task.Run(() => db.Queryable<TEntity>().InSingle(objId));
        }

        public async Task<TEntity> QueryByID(object objId, bool isUseCache)
        {
            return await Task.Run(() => db.Queryable<TEntity>().WithCacheIF(isUseCache).InSingle(objId));
        }

        public async Task<List<TEntity>> QueryByIDs(object[] ids)
        {
            return await Task.Run(() => db.Queryable<TEntity>().In(ids).ToList());
        }

        public async Task<int> Add(TEntity model)
        {
            var i = await Task.Run(() => db.Insertable(model).ExecuteReturnBigIdentity());

            return (int)i;
        }

        public async Task<bool> DeleteById(object id)
        {
            var i = await Task.Run(() => db.Deleteable<TEntity>(id).ExecuteCommand());

            return i > 0;
        }

        public async Task<bool> Delete(TEntity model)
        {
            var i = await Task.Run(() => db.Deleteable(model).ExecuteCommand());

            return i > 0;
        }

        public async Task<bool> DeleteByIds(object[] ids)
        {
            var i = await Task.Run(() => db.Deleteable<TEntity>().In(ids).ExecuteCommand());

            return i > 0;
        }

        public async Task<bool> Update(TEntity model)
        {
            var i = await Task.Run(() => db.Updateable(model).ExecuteCommand());

            return i > 0;
        }

        public async Task<bool> Update(TEntity entity, string strWhere)
        {
            return await Task.Run(() => db.Updateable(entity).Where(strWhere).ExecuteCommand() > 0);
        }

        public async Task<bool> Update(string strSql, SugarParameter[] parameters = null)
        {
            return await Task.Run(() => db.Ado.ExecuteCommand(strSql, parameters) > 0);
        }

        public async Task<bool> Update(TEntity entity, List<string> lstColumns, List<string> isIgnoreColumns = null, string strWhere = "")
        {
            IUpdateable<TEntity> up = await Task.Run(() => db.Updateable(entity));
            if (lstColumns != null && isIgnoreColumns.Count > 0)
            {
                up = await Task.Run(() => up.IgnoreColumns(it => isIgnoreColumns.Contains(it)));
            }
            if (lstColumns != null && lstColumns.Count > 0)
            {
                up = await Task.Run(() => up.UpdateColumns(it => lstColumns.Contains(it)));
            }
            if (!string.IsNullOrEmpty(strWhere))
            {
                up = await Task.Run(() => up.Where(strWhere));
            }

            return await Task.Run(() => up.ExecuteCommand()) > 0;
        }

        public async Task<List<TEntity>> Query()
        {
            return await Task.Run(() => entityDB.GetList());
        }

        public async Task<List<TEntity>> Query(string strWhere)
        {
            return await Task.Run(() => db.Queryable<TEntity>().WhereIF(!string.IsNullOrEmpty(strWhere), strWhere).ToList());
        }

        public async Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression)
        {
            return await Task.Run(() => entityDB.GetList(whereExpression));
        }

        public async Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression, string strOrderByFields)
        {
            return await Task.Run(() => db.Queryable<TEntity>().OrderByIF(!string.IsNullOrEmpty(strOrderByFields), strOrderByFields).WhereIF(whereExpression != null, whereExpression).ToList());
        }

        public async Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression, Expression<Func<TEntity, object>> orderByExpression, bool isAsc = true)
        {
            return await Task.Run(() => db.Queryable<TEntity>().OrderByIF(orderByExpression != null,
                orderByExpression, isAsc ? OrderByType.Asc : OrderByType.Desc).WhereIF(whereExpression != null,
                whereExpression).ToList());
        }

        public async Task<List<TEntity>> Query(string strWhere, string strOrderByFields)
        {
            return await Task.Run(() => db.Queryable<TEntity>().OrderByIF(!string.IsNullOrEmpty(strOrderByFields),
            strOrderByFields).WhereIF(!string.IsNullOrEmpty(strWhere), strWhere).ToList());
        }

        public async Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression, int intTop, string strOrderByFileds)
        {
            return await Task.Run(() => db.Queryable<TEntity>().OrderByIF(!string.IsNullOrEmpty(strOrderByFileds), strOrderByFileds).WhereIF(whereExpression != null, whereExpression).Take(intTop).ToList());
        }

        public async Task<List<TEntity>> Query(string strWhere, int intTop, string strOrderByFields)
        {
            return await Task.Run(() => db.Queryable<TEntity>().OrderByIF(!string.IsNullOrEmpty(strOrderByFields), strOrderByFields).WhereIF(!string.IsNullOrEmpty(strWhere), strWhere).Take(intTop).ToList());
        }

        public async Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression, int intPageIndex, int intPageSize, string strOrderByFields)
        {
            return await Task.Run(() => db.Queryable<TEntity>().OrderByIF(!string.IsNullOrEmpty(strOrderByFields), strOrderByFields).WhereIF(whereExpression != null, whereExpression).ToPageList(intPageIndex, intPageSize));
        }

        public async Task<List<TEntity>> Query(string strWhere, int intPageIndex, int intPageSize, string strOrderByFields)
        {
            return await Task.Run(() => db.Queryable<TEntity>().OrderByIF(!string.IsNullOrEmpty(strOrderByFields), strOrderByFields).WhereIF(!string.IsNullOrEmpty(strWhere), strWhere).ToPageList(intPageIndex, intPageSize)); throw new NotImplementedException();
        }

        public async Task<List<TEntity>> QueryPage(Expression<Func<TEntity, bool>> whereExpression, int intPageIndex = 0, int intPageSize = 20, string strOrderByFields = null)
        {
            return await Task.Run(() => db.Queryable<TEntity>()
            .OrderByIF(!string.IsNullOrEmpty(strOrderByFields), strOrderByFields)
            .WhereIF(whereExpression != null, whereExpression)
            .ToPageList(intPageIndex, intPageSize));
        }
    }
}
