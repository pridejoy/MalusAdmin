using MalusAdmin.Servers;
using Microsoft.AspNetCore.Authorization;

namespace MalusAdmin.WebApi.Controllers.BackStageManger;

/// <summary>
/// 基础服务
/// </summary>
[ApiExplorerSettings(GroupName = "后台管理")]
public class SysDataController : ApiControllerBase
{
    private readonly SysDataService _dataService;

    public SysDataController(SysDataService dataService)
    {
        _dataService = dataService;
    }


    /// <summary>
    /// 获取服务器信息
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [AllowAnonymous]
    [ResponseCache(Duration = 50)] // 缓存5秒
    public async Task<JsonR> GetSystemInfo()
    {
        return ResultCode.Success.JsonR(await _dataService.GetServerInfo());
    }
}