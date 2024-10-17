/// <summary>
/// 分页返回
/// </summary>
/// <typeparam name="T"></typeparam>
public class PageResult<T>
{
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int TotalPage { get; set; }
    public int Total { get; set; }
    public ICollection<T> Rows { get; set; }
}

/// <summary>
/// Scui分页
/// </summary>
public static class XnPageResult
{
    /// <summary>
    /// 替换sqlsugar分页
    /// </summary>
    /// <param name="page"></param>
    /// <returns></returns>
    public static dynamic XnPagedResult<T>(this SqlSugarPagedList<T> page)
    {
        return new
        {
            Page = page.PageIndex,
            page.PageSize,
            TotalPage = page.TotalPages,
            Total = page.TotalCount,
            Rows = page.Items
        };
    }
}