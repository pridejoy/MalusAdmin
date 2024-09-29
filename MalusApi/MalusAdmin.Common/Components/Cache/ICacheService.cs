namespace MalusAdmin.Common;

/// <summary>
/// 缓存服务接口
/// </summary>
public interface ICacheService
{
    /// <summary>
    /// 验证缓存项是否存在
    /// </summary>
    /// <param name="key">缓存Key</param>
    /// <returns></returns>
    bool Exists(string key);

    /// <summary>
    /// 添加缓存
    /// </summary>
    /// <param name="key">缓存Key</param>
    /// <param name="value">缓存Value</param>
    /// <returns></returns>
    void Set<T>(string key, T value);

    /// <summary>
    /// 添加缓存
    /// </summary>
    /// <param name="key">缓存Key</param>
    /// <param name="value">缓存Value</param>
    /// <returns></returns>
    Task SetAsync<T>(string key, T value);

    /// <summary>
    /// 添加缓存
    /// </summary>
    /// <param name="key">缓存Key</param>
    /// <param name="value">缓存Value</param>
    /// <param name="timeoutSeconds">缓存时长(秒)</param>
    /// <returns></returns>
    void Set<T>(string key, T value, int timeoutSeconds = 0);

    /// <summary>
    /// 添加缓存
    /// </summary>
    /// <param name="key">缓存Key</param>
    /// <param name="value">缓存Value</param>
    /// <param name="timeoutSeconds">缓存时长(秒)</param>
    /// <returns></returns>
    Task SetAsync<T>(string key, T value, int timeoutSeconds = 0);

    /// <summary>
    /// 修改缓存
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    void Update<T>(string key, T value);

    /// <summary>
    /// 修改缓存
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    Task UpdateAsync<T>(string key, T value);

    /// <summary>
    /// 获取缓存
    /// </summary>
    /// <param name="key">缓存Key</param>
    /// <returns></returns>
    T Get<T>(string key);

    /// <summary>
    /// 获取缓存
    /// </summary>
    /// <param name="key">缓存Key</param>
    /// <returns></returns>
    Task<T> GetAsync<T>(string key);

    /// <summary>
    /// 根据多个key
    /// 批量获取缓存
    /// </summary>
    /// <param name="keys">缓存Keys</param>
    /// <returns></returns>
    List<T> MGet<T>(List<string> keys);

    /// <summary>
    /// 根据多个key
    /// 批量获取缓存
    /// </summary>
    /// <param name="keys">缓存Keys</param>
    /// <returns></returns>
    Task<List<T>> MGetAsync<T>(List<string> keys);

    /// <summary>
    /// 获取缓存
    /// 没有获取到就创建新的缓存
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key">缓存Key</param>
    /// <param name="value">缓存Value</param>
    /// <returns></returns>
    T GetOrCreate<T>(string key, T value);

    /// <summary>
    /// 获取缓存
    /// 没有获取到就创建新的缓存
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key">缓存Key</param>
    /// <param name="value">缓存Value</param>
    /// <returns></returns>
    Task<T> GetOrCreateAsync<T>(string key, T value);

    /// <summary>
    /// 获取缓存
    /// 没有获取到就创建新的缓存
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key">缓存Key</param>
    /// <param name="value">缓存Value</param>
    /// <param name="timeoutSeconds">缓存时长(秒)</param>
    /// <returns></returns>
    T GetOrCreate<T>(string key, T value, int timeoutSeconds = 0);

    /// <summary>
    /// 获取缓存
    /// 没有获取到就创建新的缓存
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key">缓存Key</param>
    /// <param name="value">缓存Value</param>
    /// <param name="timeoutSeconds">缓存时长(秒)</param>
    /// <returns></returns>
    Task<T> GetOrCreateAsync<T>(string key, T value, int timeoutSeconds = 0);

    /// <summary>
    /// 获取缓存
    /// 没有获取到就创建新的缓存
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key">缓存Key</param>
    /// <param name="create">缓存Value</param>
    /// <returns></returns>
    T GetOrCreate<T>(string key, Func<T> create);

    /// <summary>
    /// 获取缓存
    /// 没有获取到就创建新的缓存
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key">缓存Key</param>
    /// <param name="create">缓存Value</param>
    /// <returns></returns>
    Task<T> GetOrCreateAsync<T>(string key, Func<Task<T>> create);

    /// <summary>
    /// 获取缓存
    /// 没有获取到就创建新的缓存
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key">缓存Key</param>
    /// <param name="create">缓存Value</param>
    /// <param name="timeoutSeconds">缓存时长(秒)</param>
    /// <returns></returns>
    T GetOrCreate<T>(string key, Func<T> create, int timeoutSeconds = 0);

    /// <summary>
    /// 获取缓存
    /// 没有获取到就创建新的缓存
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key">缓存Key</param>
    /// <param name="create">缓存Value</param>
    /// <param name="timeoutSeconds">缓存时长(秒)</param>
    /// <returns></returns>
    Task<T> GetOrCreateAsync<T>(string key, Func<Task<T>> create, int timeoutSeconds = 0);

    /// <summary>
    /// 删除缓存
    /// </summary>
    /// <param name="key">缓存Key</param>
    /// <returns></returns>
    long Remove(string key);

    /// <summary>
    /// 批量删除缓存
    /// </summary>
    /// <returns></returns>
    long Remove(params string[] keys);

    /// <summary>
    /// 删除缓存
    /// </summary>
    /// <param name="key">缓存Key</param>
    /// <returns></returns>
    Task<long> RemoveAsync(string key);

    /// <summary>
    /// 批量删除缓存
    /// </summary>
    /// <returns></returns>
    Task<long> RemoveAsync(params string[] keys);

    /// <summary>
    /// 删除匹配的缓存
    /// 例如：pattern=ai，删除key为ai开头缓存
    /// </summary>
    /// <param name="pattern">匹配key</param>
    long RemoveByPattern(string pattern);

    /// <summary>
    /// 删除匹配的缓存
    /// 例如：pattern=ai，删除key为ai开头缓存
    /// </summary>
    /// <param name="pattern">匹配key</param>
    Task<long> RemoveByPatternAsync(string pattern);

    /// <summary>
    /// 获取所有的缓存Key
    /// </summary>
    /// <returns></returns>
    List<string> GetAllKeys();

 

    /// <summary>
    /// 获取匹配的缓存键
    /// 例如：pattern=ai，获取key为ai开头的缓存键
    /// </summary>
    /// <returns></returns>
    Task<List<string>> GetKeysByPatternAsync(string pattern);
}