using MalusAdmin.Servers;
using Microsoft.AspNetCore.Authorization;

namespace MalusAdmin.WebApi.Controllers.BackStageManger;

/// <summary>
/// 登录服务
/// </summary>
[ApiExplorerSettings(GroupName = "后台管理")]
public class SysLoginController : ApiControllerBase
{
    private readonly SysUserService _sysUserService;

    public SysLoginController(SysUserService userService)
    {
        _sysUserService = userService;
    }

    /// <summary>
    /// 用户登录
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [AllowAnonymous]
    public async Task<dynamic> Login(SysUserLoginIn input)
    {
        return await _sysUserService.Login(input);
    }


    /// <summary>
    /// 获取登录用户的信息
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<dynamic> GetUserInfo()
    {
        return await _sysUserService.GetUserInfo();
    }


    /// <summary>
    /// 获取登录用户的路由
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    //[ResponseCache(Duration = 50)] // 缓存5秒
    public async Task<dynamic> GetUserMenu()
    {
        return await _sysUserService.GetUserMenu();
    }
}