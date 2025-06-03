using Simple.DynamicWebApi.Abstractions;
using ICacheService = MalusAdmin.Common.ICacheService;

namespace MalusAdmin.Servers;

/// <summary>
/// 缓存服务
/// </summary>
[ApiExplorerSettings(GroupName = nameof(ApiVersionGropInfo.BackStageManger))]
public class SysCacheService:  ApiControllerBase, ISysCacheService
{
    private readonly ICacheService _cacheService;

    public SysCacheService(ICacheService cacheService)
    {
        _cacheService = cacheService;
    }

    /// <summary>
    /// 获取所有缓存的key
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Permission("缓存-获取所有缓存的Key")]
    public List<string> GetAllKeys()
    {
        return _cacheService.GetAllKeys();
    }

    /// <summary>
    /// 根据key获取缓存的value
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Permission("缓存-根据key获取缓存")]
    public dynamic GetKeys(string key)
    {
        return _cacheService.Get<dynamic>(key);
    }


    /// <summary>
    /// 删除缓存
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [Permission("缓存-根据key删除缓存")]
    public async Task<long> RemoveAsync(string key)
    {
        return await _cacheService.RemoveAsync(key);
    }
}