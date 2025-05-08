namespace MalusAdmin.Servers;

/// <summary>
/// 系统缓存服务接口
/// </summary>
public interface ISysCacheService
{
    /// <summary>
    /// 获取所有缓存的key
    /// </summary>
    /// <returns></returns>
    List<string> GetAllKeys();

    /// <summary>
    /// 根据key获取缓存的value
    /// </summary>
    /// <param name="key">缓存Key</param>
    /// <returns></returns>
    dynamic GetKeys(string key);

    /// <summary>
    /// 删除缓存
    /// </summary>
    /// <param name="key">缓存Key</param>
    /// <returns></returns>
    Task<long> RemoveAsync(string key);
}
