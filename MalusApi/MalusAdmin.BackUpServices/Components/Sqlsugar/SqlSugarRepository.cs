using System.Linq.Expressions;
using SqlSugar;

namespace MalusAdmin.BackUpServices;

/// <summary>
/// SqlSugar 仓储实现类
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public class SqlSugarRepository<TEntity>
    where TEntity : class, new()
{
    private readonly string[] UpdateIgnoreColumns = { "CreatedTime", "CreatedUserId", "CreatedUserName" };

    #region 属性

    /// <summary>
    /// 初始化 SqlSugar 客户端
    /// </summary>
    private readonly ISqlSugarClient _db;

    /// <summary>
    /// 数据库上下文
    /// </summary>
    public ISqlSugarClient Context { get; }

    /// <summary>
    /// 独立数据库上下文
    /// </summary>
    private SqlSugarScopeProvider EntityContext { get; }

    /// <summary>
    /// 实体集合
    /// </summary>
    private ISugarQueryable<TEntity> Entities =>
        _db.AsTenant().GetConnectionScopeWithAttr<TEntity>().Queryable<TEntity>();

    /// <summary>
    /// 原生 Ado 对象
    /// </summary>
    private IAdo Ado { get; }

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="db"></param>
    public SqlSugarRepository(ISqlSugarClient db)
    {
        Context = _db = db;
        EntityContext = _db.AsTenant().GetConnectionScopeWithAttr<TEntity>();
        Ado = EntityContext.Ado;
    }

    #endregion

    #region 查询

    /// <summary>
    /// 获取总数
    /// </summary>
    /// <param name="whereExpression"></param>
    /// <returns></returns>
    public int Count(Expression<Func<TEntity, bool>> whereExpression)
    {
        return Entities.Count(whereExpression);
    }

    /// <summary>
    /// 获取总数
    /// </summary>
    /// <param name="whereExpression"></param>
    /// <returns></returns>
    public Task<int> CountAsync(Expression<Func<TEntity, bool>> whereExpression)
    {
        return Entities.CountAsync(whereExpression);
    }

    /// <summary>
    /// 检查是否存在
    /// </summary>
    /// <param name="whereExpression"></param>
    /// <returns></returns>
    public bool Any(Expression<Func<TEntity, bool>> whereExpression)
    {
        return Entities.Any(whereExpression);
    }

    /// <summary>
    /// 检查是否存在
    /// </summary>
    /// <param name="whereExpression"></param>
    /// <returns></returns>
    public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> whereExpression)
    {
        return await Entities.AnyAsync(whereExpression);
    }

    /// <summary>
    /// 通过主键获取实体
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    public TEntity Single(dynamic Id)
    {
        return Entities.InSingle(Id);
    }

    /// <summary>
    /// 获取一个实体
    /// </summary>
    /// <param name="whereExpression"></param>
    /// <returns></returns>
    public TEntity Single(Expression<Func<TEntity, bool>> whereExpression)
    {
        return Entities.Single(whereExpression);
    }

    /// <summary>
    /// 获取一个实体
    /// </summary>
    /// <param name="whereExpression"></param>
    /// <returns></returns>
    public async Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> whereExpression)
    {
        return await Entities.SingleAsync(whereExpression);
    }

    /// <summary>
    /// 获取一个实体
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<TEntity> SingleAsync(dynamic id)
    {
        return await Entities.InSingleAsync(id);
    }

    /// <summary>
    /// 获取一个实体
    /// </summary>
    /// <param name="whereExpression"></param>
    /// <returns></returns>
    public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> whereExpression)
    {
        return Entities.First(whereExpression);
    }

    /// <summary>
    /// 获取一个实体
    /// </summary>
    /// <param name="whereExpression"></param>
    /// <returns></returns>
    public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> whereExpression)
    {
        return await Entities.FirstAsync(whereExpression);
    }

    /// <summary>
    /// 获取列表
    /// </summary>
    /// <returns></returns>
    public List<TEntity> ToList()
    {
        return Entities.ToList();
    }

    /// <summary>
    /// 获取列表
    /// </summary>
    /// <param name="whereExpression"></param>
    /// <returns></returns>
    public List<TEntity> ToList(Expression<Func<TEntity, bool>> whereExpression)
    {
        return Entities.Where(whereExpression).ToList();
    }

    /// <summary>
    /// 获取列表
    /// </summary>
    /// <param name="whereExpression"></param>
    /// <param name="orderByExpression"></param>
    /// <param name="orderByType"></param>
    /// <returns></returns>
    public List<TEntity> ToList(Expression<Func<TEntity, bool>> whereExpression,
        Expression<Func<TEntity, object>> orderByExpression = null, OrderByType orderByType = OrderByType.Asc)
    {
        return Entities.OrderByIF(orderByExpression != null, orderByExpression, orderByType).Where(whereExpression)
            .ToList();
    }

    /// <summary>
    /// 获取列表
    /// </summary>
    /// <returns></returns>
    public Task<List<TEntity>> ToListAsync()
    {
        return Entities.ToListAsync();
    }

    /// <summary>
    /// 获取列表
    /// </summary>
    /// <param name="whereExpression"></param>
    /// <returns></returns>
    public Task<List<TEntity>> ToListAsync(Expression<Func<TEntity, bool>> whereExpression)
    {
        return Entities.Where(whereExpression).ToListAsync();
    }

    /// <summary>
    /// 获取列表
    /// </summary>
    /// <param name="whereExpression"></param>
    /// <param name="orderByExpression"></param>
    /// <param name="orderByType"></param>
    /// <returns></returns>
    public Task<List<TEntity>> ToListAsync(Expression<Func<TEntity, bool>> whereExpression,
        Expression<Func<TEntity, object>> orderByExpression = null, OrderByType orderByType = OrderByType.Asc)
    {
        return Entities.OrderByIF(orderByExpression != null, orderByExpression, orderByType).Where(whereExpression)
            .ToListAsync();
    }

    #endregion

    #region 新增

    public virtual IInsertable<TEntity> AsInsertable(TEntity entity)
    {
        return EntityContext.Insertable(entity);
    }

    public virtual IInsertable<TEntity> AsInsertable(params TEntity[] entities)
    {
        return EntityContext.Insertable(entities);
    }

    /// <summary>
    /// 新增一条记录
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public virtual int Insert(TEntity entity)
    {
        return EntityContext.Insertable(entity).ExecuteCommand();
    }

    /// <summary>
    /// 新增多条记录
    /// </summary>
    /// <param name="entities"></param>
    /// <returns></returns>
    public virtual int Insert(params TEntity[] entities)
    {
        return EntityContext.Insertable(entities).ExecuteCommand();
    }

    /// <summary>
    /// 新增多条记录
    /// </summary>
    /// <param name="entities"></param>
    /// <returns></returns>
    public virtual int Insert(IEnumerable<TEntity> entities)
    {
        return EntityContext.Insertable(entities.ToArray()).ExecuteCommand();
    }

    /// <summary>
    /// 新增一条记录返回自增Id
    /// </summary>
    /// <param name="insertObj"></param>
    /// <returns></returns>
    public virtual int InsertReturnIdentity(TEntity insertObj)
    {
        return EntityContext.Insertable(insertObj).ExecuteReturnIdentity();
    }

    /// <summary>
    /// 新增一条记录返回雪花Id
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public virtual long InsertReturnSnowflakeId(TEntity entity)
    {
        return EntityContext.Insertable(entity).ExecuteReturnSnowflakeId();
    }

    /// <summary>
    /// 新增一条记录返回实体
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public virtual TEntity InsertReturnEntity(TEntity entity)
    {
        return EntityContext.Insertable(entity).ExecuteReturnEntity();
    }


    /// <summary>
    /// 新增一条记录
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public virtual Task<int> InsertAsync(TEntity entity)
    {
        return EntityContext.Insertable(entity).ExecuteCommandAsync();
    }

    /// <summary>
    /// 新增多条记录
    /// </summary>
    /// <param name="entities"></param>
    /// <returns></returns>
    public virtual Task<int> InsertAsync(params TEntity[] entities)
    {
        return EntityContext.Insertable(entities).ExecuteCommandAsync();
    }

    /// <summary>
    /// 新增多条记录
    /// </summary>
    /// <param name="entities"></param>
    /// <returns></returns>
    public virtual Task<int> InsertAsync(IEnumerable<TEntity> entities)
    {
        if (entities != null && entities.Any())
            return EntityContext.Insertable(entities.ToArray()).ExecuteCommandAsync();
        return Task.FromResult(0);
    }

    /// <summary>
    /// 新增一条记录返回自增Id
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public virtual async Task<long> InsertReturnIdentityAsync(TEntity entity)
    {
        return await EntityContext.Insertable(entity).ExecuteReturnBigIdentityAsync();
    }

    /// <summary>
    /// 新增一条记录返回雪花Id
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public virtual async Task<long> InsertReturnSnowflakeIdAsync(TEntity entity)
    {
        return await EntityContext.Insertable(entity).ExecuteReturnSnowflakeIdAsync();
    }

    /// <summary>
    /// 新增一条记录返回实体
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public virtual async Task<TEntity> InsertReturnEntityAsync(TEntity entity)
    {
        return await EntityContext.Insertable(entity).ExecuteReturnEntityAsync();
    }

    #endregion

    #region 更新

    /// <summary>
    /// 更新一条记录
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public virtual int Update(TEntity entity)
    {
        return EntityContext.Updateable(entity).IgnoreColumns(UpdateIgnoreColumns).ExecuteCommand();
    }

    /// <summary>
    /// 更新多条记录
    /// </summary>
    /// <param name="entities"></param>
    /// <returns></returns>
    public virtual int Update(params TEntity[] entities)
    {
        return EntityContext.Updateable(entities).IgnoreColumns(UpdateIgnoreColumns).ExecuteCommand();
    }

    /// <summary>
    /// 更新多条记录
    /// </summary>
    /// <param name="entities"></param>
    /// <returns></returns>
    public virtual int Update(IEnumerable<TEntity> entities)
    {
        return EntityContext.Updateable(entities.ToArray()).IgnoreColumns(UpdateIgnoreColumns).ExecuteCommand();
    }

    /// <summary>
    /// 更新一条记录
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public virtual async Task<int> UpdateAsync(TEntity entity)
    {
        return await EntityContext.Updateable(entity).IgnoreColumns(UpdateIgnoreColumns).ExecuteCommandAsync();
    }

    /// <summary>
    /// 更新记录
    /// </summary>
    /// <param name="predicate">更新的条件</param>
    /// <param name="content">更新的内容</param>
    /// <returns></returns>
    public virtual int Update(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TEntity>> content)
    {
        return EntityContext.Updateable(content).Where(predicate).IgnoreColumns(UpdateIgnoreColumns).ExecuteCommand();
    }

    /// <summary>
    /// 更新记录
    /// </summary>
    /// <param name="predicate">更新的条件</param>
    /// <param name="content">更新的内容</param>
    /// <returns></returns>
    public virtual async Task<int> UpdateAsync(Expression<Func<TEntity, bool>> predicate,
        Expression<Func<TEntity, TEntity>> content)
    {
        return await EntityContext.Updateable(content).Where(predicate).IgnoreColumns(UpdateIgnoreColumns)
            .ExecuteCommandAsync();
    }

    /// <summary>
    /// 更新多条记录
    /// </summary>
    /// <param name="entities"></param>
    /// <returns></returns>
    public virtual Task<int> UpdateAsync(params TEntity[] entities)
    {
        return EntityContext.Updateable(entities).IgnoreColumns(UpdateIgnoreColumns).ExecuteCommandAsync();
    }

    /// <summary>
    /// 更新多条记录
    /// </summary>
    /// <param name="entities"></param>
    /// <returns></returns>
    public virtual Task<int> UpdateAsync(IEnumerable<TEntity> entities)
    {
        return EntityContext.Updateable(entities.ToArray()).IgnoreColumns(UpdateIgnoreColumns).ExecuteCommandAsync();
    }

    public virtual IUpdateable<TEntity> AsUpdateable(TEntity entity)
    {
        return EntityContext.Updateable(entity).IgnoreColumns(UpdateIgnoreColumns);
    }

    public virtual IUpdateable<TEntity> AsUpdateable(IEnumerable<TEntity> entities)
    {
        return EntityContext.Updateable(entities.ToArray()).IgnoreColumns(UpdateIgnoreColumns);
    }

    #endregion

    #region 删除

    /// <summary>
    /// 删除一条记录
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public virtual int Delete(TEntity entity)
    {
        return EntityContext.Deleteable(entity).ExecuteCommand();
    }

    /// <summary>
    /// 删除一条记录
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public virtual int Delete(object key)
    {
        return EntityContext.Deleteable<TEntity>().In(key).ExecuteCommand();
    }

    /// <summary>
    /// 删除多条记录
    /// </summary>
    /// <param name="keys"></param>
    /// <returns></returns>
    public virtual int Delete(params object[] keys)
    {
        return EntityContext.Deleteable<TEntity>().In(keys).ExecuteCommand();
    }

    /// <summary>
    /// 自定义条件删除记录
    /// </summary>
    /// <param name="whereExpression"></param>
    /// <returns></returns>
    public int Delete(Expression<Func<TEntity, bool>> whereExpression)
    {
        return EntityContext.Deleteable<TEntity>().Where(whereExpression).ExecuteCommand();
    }

    /// <summary>
    /// 删除一条记录
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public virtual Task<int> DeleteAsync(TEntity entity)
    {
        return EntityContext.Deleteable(entity).ExecuteCommandAsync();
    }

    /// <summary>
    /// 删除一条记录
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public virtual Task<int> DeleteAsync(object key)
    {
        return EntityContext.Deleteable<TEntity>().In(key).ExecuteCommandAsync();
    }

    /// <summary>
    /// 删除多条记录
    /// </summary>
    /// <param name="keys"></param>
    /// <returns></returns>
    public virtual Task<int> DeleteAsync(params object[] keys)
    {
        return EntityContext.Deleteable<TEntity>().In(keys).ExecuteCommandAsync();
    }

    /// <summary>
    /// 自定义条件删除记录
    /// </summary>
    /// <param name="whereExpression"></param>
    /// <returns></returns>
    public async Task<int> DeleteAsync(Expression<Func<TEntity, bool>> whereExpression)
    {
        return await EntityContext.Deleteable<TEntity>().Where(whereExpression).ExecuteCommandAsync();
    }

    #endregion

    #region 其他

    /// <summary>
    /// 根据表达式查询多条记录
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public virtual ISugarQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
    {
        return AsQueryable(predicate);
    }

    /// <summary>
    /// 根据表达式查询多条记录
    /// </summary>
    /// <param name="condition"></param>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public virtual ISugarQueryable<TEntity> Where(bool condition, Expression<Func<TEntity, bool>> predicate)
    {
        return AsQueryable().WhereIF(condition, predicate);
    }

    /// <summary>
    /// 构建查询分析器
    /// </summary>
    /// <returns></returns>
    public virtual ISugarQueryable<TEntity> AsQueryable()
    {
        return Entities;
    }

    /// <summary>
    /// 构建查询分析器
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public virtual ISugarQueryable<TEntity> AsQueryable(Expression<Func<TEntity, bool>> predicate)
    {
        return Entities.Where(predicate);
    }

    /// <summary>
    /// 直接返回数据库结果
    /// </summary>
    /// <returns></returns>
    public virtual List<TEntity> AsEnumerable()
    {
        return AsQueryable().ToList();
    }

    /// <summary>
    /// 直接返回数据库结果
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public virtual List<TEntity> AsEnumerable(Expression<Func<TEntity, bool>> predicate)
    {
        return AsQueryable(predicate).ToList();
    }

    /// <summary>
    /// 直接返回数据库结果
    /// </summary>
    /// <returns></returns>
    public virtual Task<List<TEntity>> AsAsyncEnumerable()
    {
        return AsQueryable().ToListAsync();
    }

    /// <summary>
    /// 直接返回数据库结果
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public virtual Task<List<TEntity>> AsAsyncEnumerable(Expression<Func<TEntity, bool>> predicate)
    {
        return AsQueryable(predicate).ToListAsync();
    }

    public virtual bool IsExists(Expression<Func<TEntity, bool>> whereExpression)
    {
        return Entities.Any(whereExpression);
    }

    public virtual Task<bool> IsExistsAsync(Expression<Func<TEntity, bool>> whereExpression)
    {
        return Entities.AnyAsync(whereExpression);
    }

    #endregion

    #region 仓储事务

    /// <summary>
    /// 切换仓储(注意使用环境)
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    /// <returns>仓储</returns>
    //public virtual SqlSugarRepository<T> Change<T>()
    //    where T : class, new()
    //{
    //    return App.GetService<SqlSugarRepository<T>>();
    //}

    /// <summary>
    /// 当前db
    /// </summary>
    public void CurrentBeginTran()
    {
        Ado.BeginTran();
    }

    /// <summary>
    /// 当前db
    /// </summary>
    public void CurrentCommitTran()
    {
        Ado.CommitTran();
    }

    /// <summary>
    /// 当前db
    /// </summary>
    public void CurrentRollbackTran()
    {
        Ado.RollbackTran();
    }

    /// <summary>
    /// 所有db
    /// </summary>
    public void BeginTran()
    {
        Context.AsTenant().BeginTran();
    }

    /// <summary>
    /// 所有db
    /// </summary>
    public void CommitTran()
    {
        Context.AsTenant().CommitTran();
    }

    /// <summary>
    /// 所有db
    /// </summary>
    public void RollbackTran()
    {
        Context.AsTenant().RollbackTran();
    }

    #endregion
}