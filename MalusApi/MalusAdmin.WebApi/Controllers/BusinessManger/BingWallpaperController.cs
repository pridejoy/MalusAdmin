using MalusAdmin.Servers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MalusAdmin.WebApi.Controllers.BusinessManger;

/// <summary>
/// 必应壁纸
/// </summary> 
[ApiExplorerSettings(GroupName = "业务管理")]
public class BingWallpaperController  : ApiControllerBase
{
    private readonly BingWallpaperService _services;

    public BingWallpaperController(BingWallpaperService service)
    {
        _services = service;
    }
    
    
    /// <summary>
    /// 必应壁纸分页
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Permission("壁纸分页")]
    public async Task<dynamic> PageList([FromQuery]cuetomerPageIn input)
    {
        return await _services.PageList(input);
    }
}