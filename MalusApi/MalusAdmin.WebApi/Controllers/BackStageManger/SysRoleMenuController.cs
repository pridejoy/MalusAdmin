using MalusAdmin.Servers.SysRoleMenu;
using MalusAdmin.Servers.SysRoleMenu.Dto;

namespace MalusAdmin.WebApi.Controllers.BackStageManger;

/// <summary>
/// 角色菜单服务
/// </summary>
[ApiExplorerSettings(GroupName = "后台管理")]
public class SysRoleMenuController : ApiControllerBase
{
    private readonly SysRoleMenuService _service;

    public SysRoleMenuController(SysRoleMenuService service)
    {
        _service = service;
    }

    /// <summary>
    /// 角色菜单查询
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Permission("角色菜单查询")]
    public async Task<dynamic> Get([FromQuery] int RoleId)
    {
        return await _service.RoleUserMenu(new List<int> { RoleId });
    }

    /// <summary>
    /// 添加用户
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [Permission("角色菜单更新")]
    [ReadOnly]
    public async Task<bool> Set(UpdateRoleUserMenuIn input)
    {
        return await _service.SetRoleUserMenu(input);
    }
}