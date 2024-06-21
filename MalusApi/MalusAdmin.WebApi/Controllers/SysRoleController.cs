using MalusAdmin.Servers;
using MalusAdmin.Servers.SysRole;
using MalusAdmin.Servers.SysUser.Dto;

namespace MalusAdmin.WebApi.Controllers;

/// <summary>
/// 角色服务
/// </summary>
public class SysRoleController : ApiControllerBase
{
    private readonly SysRoleService _sysRoleService;

    public SysRoleController(SysRoleService sysRoleService)
    {
        _sysRoleService = sysRoleService;
    }

    /// <summary>
    /// 分页查询
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Permission("角色查询分页")]
    public async Task<JsonR> PageList([FromQuery] UserPageIn input)
    {
        return ResultCode.Success.JsonR(await _sysRoleService.PageList(input));
    }

    /// <summary>
    /// 添加用户
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [Permission("角色添加")]
    public async Task<JsonR> Add(RoleAddandUpIn input)
    {
        return ResultCode.Success.JsonR(await _sysRoleService.Add(input));
    }


    /// <summary>
    /// 删除用户
    /// </summary>
    /// <returns></returns>
    [HttpPost("{id}")]
    [Permission("角色删除")]
    public async Task<JsonR> Delete(int id)
    {
        return ResultCode.Success.JsonR(await _sysRoleService.Delete(id));
    }


    /// <summary>
    /// 更新用户
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [Permission("角色更新")]
    public async Task<JsonR> Update(RoleAddandUpIn input)
    {
        return ResultCode.Success.JsonR(await _sysRoleService.Update(input));
    }


    /// <summary>
    /// 角色列表
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<JsonR> List()
    {
        return ResultCode.Success.JsonR(await _sysRoleService.List());
    }
}