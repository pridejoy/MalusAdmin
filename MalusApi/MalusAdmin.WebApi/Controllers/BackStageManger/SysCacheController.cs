using MalusAdmin.Servers;

namespace MalusAdmin.WebApi.Controllers;

/// <summary>
///     缓存服务
/// </summary>
[ApiExplorerSettings(GroupName = "后台管理")]
public class SysCacheController : ApiControllerBase
{
    private readonly SysCacheService _sysCacheService;

    public SysCacheController(SysCacheService sysCacheService)
    {
        _sysCacheService = sysCacheService;
    }


    /// <summary>
    ///     获取所有缓存的Key
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Permission("缓存-获取所有缓存的Key")]
    public async Task<List<string>> GetAllKeys()
    {
        return _sysCacheService.GetAllKeys();
    }

    /// <summary>
    ///     根据key获取缓存的value
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Permission("缓存-根据key获取缓存")]
    public dynamic GetKeys(string key)
    {
        return _sysCacheService.GetKeys(key);
    }


    /// <summary>
    ///     根据key获取缓存的value
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [Permission("缓存-根据key删除缓存")]
    public async Task<bool> DeleteKey(string key)
    {
        return await _sysCacheService.RemoveAsync(key) > 0;
    }
}