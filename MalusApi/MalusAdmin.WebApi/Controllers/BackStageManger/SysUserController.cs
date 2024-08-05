using MalusAdmin.Servers;
using MalusAdmin.Servers.SysUser.Dto;

namespace MalusAdmin.WebApi.Controllers.BackStageManger;

/// <summary>
/// 用户服务
/// </summary>
[ApiExplorerSettings(GroupName = "后台管理")]
public class SysUserController : ApiControllerBase
{
    private readonly SysUserService _sysUserService;

    public SysUserController(SysUserService userService)
    {
        _sysUserService = userService;
    }

    /// <summary>
    /// 分页查询
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Permission("用户信息分页查询")]
    public async Task<dynamic> PageList([FromQuery] UserPageIn input)
    {
        return await _sysUserService.PageList(input);
    }


    /// <summary>
    /// 添加用户
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [Permission("用户信息添加")]
    public async Task<bool> Add(UserAddAndUpIn input)
    {
        return await _sysUserService.Add(input);
    }


    /// <summary>
    /// 删除用户
    /// </summary>
    /// <returns></returns>
    [HttpPost("{id}")]
    [Permission("用户信息删除")]
    public async Task<bool> Delete(int id)
    {
        return await _sysUserService.Delete(id);
    }


    /// <summary>
    /// 更新用户
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [Permission("用户信息更新")]
    [ReadOnly]
    public async Task<bool> Update(UserAddAndUpIn input)
    {
        return await _sysUserService.Update(input);
    }
}