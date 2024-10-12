using MalusAdmin.Servers;
using MalusAdmin.Servers.Gallery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MalusAdmin.WebApi.Controllers.BusinessManger;

/// <summary>
/// 图库服务
/// </summary> 
[ApiExplorerSettings(GroupName = "业务管理")]
public class GalleryController  : ApiControllerBase
{
    
    private readonly GalleryService _services;

    public GalleryController(GalleryService service)
    {
        _services = service;
    }
    
    
    /// <summary>
    /// 壁纸分页
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Permission("壁纸分页")]
    public async Task<dynamic> PageList([FromQuery]cuetomerPageIn input)
    {
        return await _services.PageList(input);
    }
  
    /// <summary>
    /// 壁纸分页
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Permission("壁纸删除")]
    public async Task<dynamic> Delete([FromQuery]int id)
    {
        return await _services.Delete(id);
    }
}