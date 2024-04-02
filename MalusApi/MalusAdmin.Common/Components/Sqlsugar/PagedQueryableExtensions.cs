using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

/// <summary>
/// 分页拓展类
/// </summary>
public static class PagedQueryableExtensions
{
    /// <summary>
    /// 分页拓展
    /// </summary>
    /// <param name="query"></param>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <returns></returns>
    public static async Task<SqlSugarPagedList<TEntity>> ToPagedListAsync<TEntity>(this ISugarQueryable<TEntity> query, int pageIndex, int pageSize)
    {
        RefAsync<int> totalCount = 0;
        var items = await query.ToPageListAsync(pageIndex, pageSize, totalCount);
        var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
        return new SqlSugarPagedList<TEntity>
        {
            PageIndex = pageIndex,
            PageSize = pageSize,
            Items = items,
            TotalCount = (int)totalCount,
            TotalPages = totalPages,
            HasNextPages = pageIndex < totalPages,
            HasPrevPages = pageIndex - 1 > 0
        };
    }
}



/// <summary>
/// 分页泛型集合
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public class SqlSugarPagedList<TEntity>
{
    /// <summary>
    /// 页码
    /// </summary>
    public int PageIndex { get; set; }

    /// <summary>
    /// 页容量
    /// </summary>
    public int PageSize { get; set; }

    /// <summary>
    /// 总条数
    /// </summary>
    public int TotalCount { get; set; }

    /// <summary>
    /// 总页数
    /// </summary>
    public int TotalPages { get; set; }

    /// <summary>
    /// 当前页集合
    /// </summary>
    public IEnumerable<TEntity> Items { get; set; }

    /// <summary>
    /// 是否有上一页
    /// </summary>
    public bool HasPrevPages { get; set; }

    /// <summary>
    /// 是否有下一页
    /// </summary>
    public bool HasNextPages { get; set; }
}

/// <summary>
/// 分页集合
/// </summary>
public class PagedModel : SqlSugarPagedList<object>
{
}


public class PageList<T>
{
    public int PageNo { get; set; }
    public int PageSize { get; set; }
    public int TotalPage { get; set; }
    public int TotalRows { get; set; }
    public IEnumerable<T> Rows { get; set; }
}

/// <summary>
/// 小诺分页列表结果
/// </summary>
public static class PageResult
{
    /// <summary>
    /// 替换sqlsugar分页
    /// </summary>
    /// <param name="page"></param>
    /// <returns></returns>
    public static PageList<T> PagedResult<T>(this SqlSugarPagedList<T> page)
    {
        return new PageList<T>
        {
            PageNo = page.PageIndex,
            PageSize = page.PageSize,
            TotalPage = page.TotalPages,
            TotalRows = page.TotalCount,
            Rows = page.Items
        };
    }
}
