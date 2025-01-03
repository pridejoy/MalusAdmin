using MalusAdmin.Servers;
using MalusAdmin.Servers.SysUser.Dto;
using MalusAdmin.WebApi.Filter;
using Microsoft.AspNetCore.Authorization;

namespace MalusAdmin.WebApi.Controllers.BackStageManger;

/// <summary>
/// 登录服务
/// </summary>
[ApiExplorerSettings(GroupName = "后台管理")]
[AllowAnonymous]
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
    public async Task<SysUserLoginOut> Login(SysUserLoginIn input)
    {
        return await _sysUserService.Login(input);
    }


    /// <summary>
    /// 获取登录用户的信息
    /// </summary>
    /// <returns></returns>
    [HttpGet] 
    //[ResponseCache(Duration = 60 * 60)]
    public async Task<GetUserInfoOut> GetUserInfo()
    {
        return await _sysUserService.GetUserInfo();
    }


    /// <summary>
    /// 获取登录用户的路由
    /// </summary>
    /// <returns></returns>
    [HttpGet] 
    //[ResponseCache(Duration = 60 * 60)]
    [DisabledRequestRecord]
    public async Task<UserMenuOut> GetUserMenu()
    {
        return await _sysUserService.GetUserMenu();
    }
     
    /// <summary>
    /// 更改基础资料
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [ReadOnly]
    public async Task<bool> UpdateUserInfo([FromBody]SysUserInfo input)
    {
        return await _sysUserService.UpdateUserInfo(input);
    }


    /// <summary>
    /// 更改密码
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [ReadOnly]
    public async Task<bool> ResetPassWord([FromBody] ResetPassWord input)
    {
        return await _sysUserService.ResetPassWord(input);
    }
}