using FreeRedis;

namespace MalusAdmin.Common.Components.Cache;

public class RedisCacheService : ICacheService
{
    private readonly RedisClient cli;

    public RedisCacheService()
    {
        var redisconfig = AppSettings.Redis.ConnectionString;


        if (!AppSettings.IsDemo)
            //注释这行，我是从本地文件读取的
            redisconfig = File.ReadAllText("D:\\redisconfig.txt");

        cli = new RedisClient(redisconfig);
        cli.Serialize = obj => JsonConvert.SerializeObject(obj);
        cli.Deserialize = (json, type) => JsonConvert.DeserializeObject(json, type);
    }

    /// <summary>
    ///     判断key是否存在
    /// </summary>
    /// <param name="key">缓存Key</param>
    /// <returns></returns>
    public bool Exists(string key)
    {
        return cli.Exists(key);
    }

    /// <summary>
    ///     删除缓存
    /// </summary>
    /// <param name="key">缓存Key</param>
    /// <returns></returns>
    public long Remove(string key)
    {
        return cli.Del(key);
    }

    /// <summary>
    ///     批量删除缓存
    /// </summary>
    /// <returns></returns>
    public long Remove(params string[] keys)
    {
        return cli.Del(keys);
    }

    /// <summary>
    ///     删除缓存
    /// </summary>
    /// <param name="key">缓存Key</param>
    /// <returns></returns>
    public async Task<long> RemoveAsync(string key)
    {
        return await cli.DelAsync(key);
    }

    /// <summary>
    ///     批量删除缓存
    /// </summary>
    /// <returns></returns>
    public async Task<long> RemoveAsync(params string[] keys)
    {
        return await cli.DelAsync(keys);
    }

    /// <summary>
    ///     删除匹配的缓存
    ///     例如：pattern=ai，删除key为ai开头缓存
    /// </summary>
    /// <param name="pattern">匹配key</param>
    public long RemoveByPattern(string pattern)
    {
        var keys = cli.Keys(pattern);
        if (keys.Length == 0) return 0;
        return cli.Del(keys);
    }

    /// <summary>
    ///     删除匹配的缓存
    ///     例如：pattern=ai，删除key为ai开头缓存
    /// </summary>
    /// <param name="pattern">匹配key</param>
    public async Task<long> RemoveByPatternAsync(string pattern)
    {
        var keys = await cli.KeysAsync(pattern);
        if (keys.Length == 0) return 0;
        return await cli.DelAsync(keys);
    }

    /// <summary>
    ///     获取所有缓存键
    /// </summary>
    /// <returns></returns>
    public List<string> GetAllKeys()
    {
        return cli.Keys("*").ToList();
    }

    /// <summary>
    ///     获取匹配的缓存键
    ///     例如：pattern=ai，获取key为ai开头的缓存键
    /// </summary>
    /// <returns></returns>
    public async Task<List<string>> GetKeysByPatternAsync(string pattern)
    {
        var keys = await cli.KeysAsync($"{pattern}*");

        return keys.ToList();
    }

    #region 设置缓存

    /// <summary>
    ///     添加缓存
    /// </summary>
    /// <param name="key">缓存Key</param>
    /// <param name="value">缓存Value</param>
    /// <returns></returns>
    public void Set<T>(string key, T value)
    {
        cli.Set(key, value);
    }

    /// <summary>
    ///     添加缓存
    /// </summary>
    /// <param name="key">缓存Key</param>
    /// <param name="value">缓存Value</param>
    /// <returns></returns>
    public async Task SetAsync<T>(string key, T value)
    {
        await cli.SetAsync(key, value);
    }

    /// <summary>
    ///     添加缓存
    /// </summary>
    /// <param name="key">缓存Key</param>
    /// <param name="value">缓存Value</param>
    /// <param name="timeoutSeconds">缓存时长(秒)</param>
    /// <returns></returns>
    public void Set<T>(string key, T value, int timeoutSeconds = -1)
    {
        cli.Set(key, value, timeoutSeconds);
    }

    /// <summary>
    ///     添加缓存
    /// </summary>
    /// <param name="key">缓存Key</param>
    /// <param name="value">缓存Value</param>
    /// <param name="timeoutSeconds">缓存时长(秒)</param>
    /// <returns></returns>
    public async Task SetAsync<T>(string key, T value, int timeoutSeconds = -1)
    {
        await cli.SetAsync(key, value, timeoutSeconds);
    }

    #endregion

    #region 修改缓存

    /// <summary>
    ///     修改缓存
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    public void Update<T>(string key, T value)
    {
        // 当 key 不存在时，返回 -2 。 当 key 存在但没有设置剩余生存时间时，返回 -1 。 否则，以秒为单位返回 key 的剩余过期时间
        var ttl = cli.Ttl(key);
        if (ttl == -2) return;
        var expireSeconds = -1;
        if (ttl != -1) expireSeconds = Convert.ToInt32(ttl);
        cli.Set(key, value, expireSeconds);
    }

    /// <summary>
    ///     修改缓存
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    public async Task UpdateAsync<T>(string key, T value)
    {
        // 当 key 不存在时，返回 -2 。 当 key 存在但没有设置剩余生存时间时，返回 -1 。 否则，以秒为单位返回 key 的剩余过期时间
        var ttl = cli.Ttl(key);
        if (ttl == -2) return;
        var expireSeconds = -1;
        if (ttl != -1) expireSeconds = Convert.ToInt32(ttl);
        await cli.SetAsync(key, value, expireSeconds);
    }

    #endregion

    #region 获取缓存

    /// <summary>
    ///     获取缓存对象
    /// </summary>
    /// <param name="key">缓存Key</param>
    /// <returns></returns>
    public T Get<T>(string key)
    {
        return cli.Get<T>(key);
    }

    /// <summary>
    ///     获取缓存对象string
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public string GetKeyString(string key)
    {
        return cli.Get(key);
    }

    /// <summary>
    ///     获取缓存对象
    /// </summary>
    /// <param name="key">缓存Key</param>
    /// <returns></returns>
    public Task<T> GetAsync<T>(string key)
    {
        return cli.GetAsync<T>(key);
    }

    /// <summary>
    ///     根据多个key
    ///     批量获取缓存
    /// </summary>
    /// <param name="keys">缓存Keys</param>
    /// <returns></returns>
    public List<T> MGet<T>(List<string> keys)
    {
        return cli.MGet<T>(keys.ToArray()).ToList();
    }

    /// <summary>
    ///     根据多个key
    ///     批量获取缓存
    /// </summary>
    /// <param name="keys">缓存Keys</param>
    /// <returns></returns>
    public async Task<List<T>> MGetAsync<T>(List<string> keys)
    {
        var values = await cli.MGetAsync<T>(keys.ToArray());
        return values.ToList();
    }

    /// <summary>
    ///     获取缓存
    ///     没有获取到就创建新的缓存
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key">缓存Key</param>
    /// <param name="value">缓存Value</param>
    /// <returns></returns>
    public T GetOrCreate<T>(string key, T value)
    {
        if (cli.Exists(key)) return cli.Get<T>(key);

        cli.Set(key, value);
        return value;
    }

    /// <summary>
    ///     获取缓存
    ///     没有获取到就创建新的缓存
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key">缓存Key</param>
    /// <param name="value">缓存Value</param>
    /// <returns></returns>
    public async Task<T> GetOrCreateAsync<T>(string key, T value)
    {
        if (await cli.ExistsAsync(key))
            value = await cli.GetAsync<T>(key);
        else
            await cli.SetAsync(key, value);
        return value;
    }

    /// <summary>
    ///     获取缓存
    ///     没有获取到就创建新的缓存
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key">缓存Key</param>
    /// <param name="value">缓存Value</param>
    /// <param name="timeoutSeconds">缓存时长(秒)</param>
    /// <returns></returns>
    public T GetOrCreate<T>(string key, T value, int timeoutSeconds = 0)
    {
        if (cli.Exists(key)) return cli.Get<T>(key);

        cli.Set(key, value, timeoutSeconds);
        return value;
    }

    /// <summary>
    ///     获取缓存
    ///     没有获取到就创建新的缓存
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key">缓存Key</param>
    /// <param name="value">缓存Value</param>
    /// <param name="timeoutSeconds">缓存时长(秒)</param>
    /// <returns></returns>
    public async Task<T> GetOrCreateAsync<T>(string key, T value, int timeoutSeconds = 0)
    {
        if (await cli.ExistsAsync(key))
            value = await cli.GetAsync<T>(key);
        else
            await cli.SetAsync(key, value, timeoutSeconds);
        return value;
    }

    /// <summary>
    ///     获取缓存
    ///     没有获取到就创建新的缓存
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key">缓存Key</param>
    /// <param name="create">缓存Value</param>
    /// <returns></returns>
    public T GetOrCreate<T>(string key, Func<T> create)
    {
        if (cli.Exists(key)) return cli.Get<T>(key);

        var value = create();
        if (value != null)
            cli.Set(key, value);
        return value;
    }

    /// <summary>
    ///     获取缓存
    ///     没有获取到就创建新的缓存
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key">缓存Key</param>
    /// <param name="create">缓存Value</param>
    /// <returns></returns>
    public async Task<T> GetOrCreateAsync<T>(string key, Func<Task<T>> create)
    {
        if (await cli.ExistsAsync(key)) return await cli.GetAsync<T>(key);

        var value = await create();
        if (value != null) await cli.SetAsync(key, value);
        return value;
    }

    /// <summary>
    ///     获取缓存
    ///     没有获取到就创建新的缓存
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key">缓存Key</param>
    /// <param name="create">缓存Value</param>
    /// <param name="timeoutSeconds">缓存时长(秒)</param>
    /// <returns></returns>
    public T GetOrCreate<T>(string key, Func<T> create, int timeoutSeconds = 0)
    {
        if (cli.Exists(key)) return cli.Get<T>(key);

        var value = create();
        if (value != null)
            cli.Set(key, value, timeoutSeconds);
        return value;
    }

    /// <summary>
    ///     获取缓存
    ///     没有获取到就创建新的缓存
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key">缓存Key</param>
    /// <param name="create">缓存Value</param>
    /// <param name="timeoutSeconds">缓存时长(秒)</param>
    /// <returns></returns>
    public async Task<T> GetOrCreateAsync<T>(string key, Func<Task<T>> create, int timeoutSeconds = 0)
    {
        if (await cli.ExistsAsync(key)) return await cli.GetAsync<T>(key);

        var value = await create();
        if (value != null)
            await cli.SetAsync(key, value, timeoutSeconds);
        return value;
    }

    #endregion
}