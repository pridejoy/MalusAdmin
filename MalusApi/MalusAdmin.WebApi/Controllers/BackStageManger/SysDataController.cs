using MalusAdmin.Servers;
using Microsoft.AspNetCore.Authorization;

namespace MalusAdmin.WebApi.Controllers.BackStageManger;

/// <summary>
///     基础服务
/// </summary>
[ApiExplorerSettings(GroupName = "后台管理")]
[ResponseCache(Duration = 500)]
public class SysDataController : ApiControllerBase
{
    private readonly SysDataService _dataService;

    public SysDataController(SysDataService dataService)
    {
        _dataService = dataService;
    }


    /// <summary>
    ///     获取服务器信息
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [AllowAnonymous]
    public async Task<dynamic> GetSystemInfo()
    {
        return await _dataService.GetServerInfo();
    }


    /// <summary>
    ///     获取当前使用的nuget包
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [AllowAnonymous]
    public async Task<dynamic> GetNuGetPackages()
    {
        return await _dataService.GetNuGetPackages();
    }
}