using System.Collections;
using System.Reflection;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Caching.Memory;

namespace MalusAdmin.Common;

public class MemoryCacheService : ICacheService
{
    private readonly IMemoryCache _cache;

    public MemoryCacheService(IMemoryCache cache)
    {
        _cache = cache;
    }

    /// <summary>
    ///     是否存在
    /// </summary>
    /// <param name="key">缓存Key</param>
    /// <returns></returns>
    public bool Exists(string key)
    {
        if (string.IsNullOrEmpty(key)) throw new ArgumentNullException(nameof(key));
        return _cache.TryGetValue(key, out var value);
    }

    /// <summary>
    ///     获取缓存
    /// </summary>
    /// <param name="key">缓存Key</param>
    /// <returns></returns>
    public T Get<T>(string key)
    {
        if (string.IsNullOrEmpty(key)) throw new ArgumentNullException(nameof(key));
        return _cache.Get<T>(key);
    }


    /// <summary>
    ///     获取缓存
    /// </summary>
    /// <param name="key">缓存Key</param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public Task<T> GetAsync<T>(string key)
    {
        if (string.IsNullOrEmpty(key)) throw new ArgumentNullException(nameof(key));
        var v = _cache.Get<T>(key);
        return Task.FromResult(v);
    }

    /// <summary>
    ///     根据多个key
    ///     批量获取缓存
    /// </summary>
    /// <param name="keys">缓存Keys</param>
    /// <returns></returns>
    public List<T> MGet<T>(List<string> keys)
    {
        var list = new List<T>();
        foreach (var key in keys) list.Add(_cache.Get<T>(key));
        return list;
    }

    /// <summary>
    ///     根据多个key
    ///     批量获取缓存
    /// </summary>
    /// <param name="keys">缓存Keys</param>
    /// <returns></returns>
    public Task<List<T>> MGetAsync<T>(List<string> keys)
    {
        var list = new List<T>();
        foreach (var key in keys)
        {
            var v = GetAsync<T>(key);
            list.Add(v.Result);
        }

        return Task.FromResult(list);
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
        if (string.IsNullOrEmpty(key)) throw new ArgumentNullException(nameof(key));
        return _cache.GetOrCreate(key, entry => { return value; });
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
        if (string.IsNullOrEmpty(key)) throw new ArgumentNullException(nameof(key));
        return _cache.GetOrCreate(key, entry =>
        {
            var value = create();
            return value;
        });
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
        if (string.IsNullOrEmpty(key)) throw new ArgumentNullException(nameof(key));
        return _cache.GetOrCreate(key, entry =>
        {
            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(timeoutSeconds);
            return value;
        });
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
        if (string.IsNullOrEmpty(key)) throw new ArgumentNullException(nameof(key));
        return _cache.GetOrCreate(key, entry =>
        {
            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(timeoutSeconds);
            var value = create();
            return value;
        });
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
        if (string.IsNullOrEmpty(key)) throw new ArgumentNullException(nameof(key));
        return await _cache.GetOrCreateAsync(key, entry => { return Task.FromResult(value); });
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
        if (string.IsNullOrEmpty(key)) throw new ArgumentNullException(nameof(key));
        return await _cache.GetOrCreateAsync(key, async entry =>
        {
            var value = await create();
            return value;
        });
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
        if (string.IsNullOrEmpty(key)) throw new ArgumentNullException(nameof(key));
        return await _cache.GetOrCreateAsync(key, entry =>
        {
            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(timeoutSeconds);
            return Task.FromResult(value);
        });
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
        if (string.IsNullOrEmpty(key)) throw new ArgumentNullException(nameof(key));
        return await _cache.GetOrCreateAsync(key, async entry =>
        {
            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(timeoutSeconds);
            var value = await create();
            return value;
        });
    }

    /// <summary>
    ///     添加缓存
    /// </summary>
    /// <param name="key">缓存Key</param>
    /// <param name="value">缓存Value</param>
    /// <returns></returns>
    public void Set<T>(string key, T value)
    {
        if (string.IsNullOrEmpty(key)) throw new ArgumentNullException(nameof(key));
        _cache.Set(key, value);
    }

    /// <summary>
    ///     添加缓存
    /// </summary>
    /// <param name="key">缓存Key</param>
    /// <param name="value">缓存Value</param>
    /// <param name="timeoutSeconds">缓存时长(秒)</param>
    /// <returns></returns>
    public void Set<T>(string key, T value, int timeoutSeconds)
    {
        if (string.IsNullOrEmpty(key)) throw new ArgumentNullException(nameof(key));
        var entry = new MemoryCacheEntryOptions();
        entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(timeoutSeconds);
        _cache.Set(key, value, entry);
    }

    /// <summary>
    ///     添加缓存
    /// </summary>
    /// <param name="key">缓存Key</param>
    /// <param name="value">缓存Value</param>
    /// <returns></returns>
    public Task SetAsync<T>(string key, T value)
    {
        if (string.IsNullOrEmpty(key)) throw new ArgumentNullException(nameof(key));
        _cache.Set(key, value);
        return Task.CompletedTask;
    }

    /// <summary>
    ///     添加缓存
    /// </summary>
    /// <param name="key">缓存Key</param>
    /// <param name="value">缓存Value</param>
    /// <param name="timeoutSeconds">缓存时长(秒)</param>
    /// <returns></returns>
    public Task SetAsync<T>(string key, T value, int timeoutSeconds)
    {
        if (string.IsNullOrEmpty(key)) throw new ArgumentNullException(nameof(key));
        var entry = new MemoryCacheEntryOptions();
        entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(timeoutSeconds);
        _cache.Set(key, value);
        return Task.CompletedTask;
    }

    /// <summary>
    ///     修改缓存值
    ///     删除原有的，添加新的
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public void Update<T>(string key, T value)
    {
        if (string.IsNullOrEmpty(key)) throw new ArgumentNullException(nameof(key));
        if (Exists(key)) Remove(key);

        Set(key, value);
    }

    /// <summary>
    ///     修改缓存值
    ///     删除原有的，添加新的
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task UpdateAsync<T>(string key, T value)
    {
        if (string.IsNullOrEmpty(key)) throw new ArgumentNullException(nameof(key));
        if (Exists(key)) Remove(key);

        await SetAsync(key, value);
    }

    /// <summary>
    ///     删除缓存
    /// </summary>
    /// <param name="key">缓存Key</param>
    /// <returns></returns>
    public long Remove(string key)
    {
        if (string.IsNullOrEmpty(key)) throw new ArgumentNullException(nameof(key));
        try
        {
            _cache.Remove(key);
            return 1;
        }
        catch
        {
            return 01;
        }
    }

    /// <summary>
    ///     批量删除缓存
    /// </summary>
    /// <returns></returns>
    public long Remove(params string[] keys)
    {
        if (keys == null || keys.Length <= 0) throw new ArgumentNullException(nameof(keys));
        long count = 0;
        foreach (var item in keys)
            try
            {
                _cache.Remove(item);
                count++;
            }
            catch
            {
                count--;
            }

        return count < 0 ? 0 : count;
    }

    /// <summary>
    ///     删除缓存
    /// </summary>
    /// <param name="key">缓存Key</param>
    /// <returns></returns>
    public Task<long> RemoveAsync(string key)
    {
        if (string.IsNullOrEmpty(key)) throw new ArgumentNullException(nameof(key));

        return Task.FromResult(Remove(key));
    }

    /// <summary>
    ///     批量删除缓存
    /// </summary>
    /// <returns></returns>
    public Task<long> RemoveAsync(params string[] keys)
    {
        if (keys == null || keys.Length <= 0) throw new ArgumentNullException(nameof(keys));
        long count = 0;
        foreach (var item in keys)
            try
            {
                _cache.Remove(item);
                count++;
            }
            catch
            {
                count--;
            }

        count = count < 0 ? 0 : count;
        return Task.FromResult(count);
    }

    /// <summary>
    ///     删除匹配的缓存
    ///     例如：pattern=ai，删除key为ai开头缓存
    /// </summary>
    /// <param name="pattern">匹配key</param>
    public long RemoveByPattern(string pattern)
    {
        if (string.IsNullOrEmpty(pattern)) throw new ArgumentNullException(nameof(pattern));
        var cacheKeys = GetAllKeys();
        if (cacheKeys.Any() == false) return 0;

        var keys = cacheKeys.Where(k => Regex.IsMatch(k, pattern)).ToArray();
        if (keys.Any() == false) return 0;

        return Remove(keys);
    }

    /// <summary>
    ///     删除匹配的缓存
    ///     例如：pattern=ai，删除key为ai开头缓存
    /// </summary>
    /// <param name="pattern">匹配key</param>
    public async Task<long> RemoveByPatternAsync(string pattern)
    {
        if (string.IsNullOrEmpty(pattern)) throw new ArgumentNullException(nameof(pattern));
        var cacheKeys = GetAllKeys();
        if (cacheKeys.Any() == false) return 0L;

        var keys = cacheKeys.Where(k => Regex.IsMatch(k, pattern)).ToArray();
        if (keys.Any() == false) return 0L;

        return await RemoveAsync(keys);
    }

    /// <summary>
    ///     获取所有缓存键
    /// </summary>
    /// <returns></returns>
    public List<string> GetAllKeys()
    {
        const BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic;
        var entries = _cache.GetType().GetField("_entries", flags).GetValue(_cache);
        var cacheItems = entries as IDictionary;
        var keys = new List<string>();
        if (cacheItems == null) return keys;
        foreach (DictionaryEntry cacheItem in cacheItems) keys.Add(cacheItem.Key.ToString());
        return keys;
    }

    /// <summary>
    ///     获取匹配的缓存键
    ///     例如：pattern=ai，获取key为ai开头的缓存键
    /// </summary>
    /// <returns></returns>
    public async Task<List<string>> GetKeysByPatternAsync(string pattern)
    {
        const BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic;
        var entries = _cache.GetType().GetField("_entries", flags).GetValue(_cache);
        var cacheItems = entries as IDictionary;
        var keys = new List<string>();
        if (cacheItems == null) return keys;
        foreach (DictionaryEntry cacheItem in cacheItems)
            if (cacheItem.Key.ToString().StartsWith(pattern))
                keys.Add(cacheItem.Key.ToString());
        return await Task.FromResult(keys);
    }
}