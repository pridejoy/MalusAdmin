using MalusAdmin.Servers.SysRoleMenu.Dto;

namespace MalusAdmin.Servers.SysRoleMenu;

/// <summary>
/// 角色菜单服务接口
/// </summary>
public interface ISysRoleMenuService
{
    /// <summary>
    /// 角色菜单获取
    /// </summary>
    /// <param name="RoleId">角色ID列表</param>
    /// <returns></returns>
    Task<List<int>> RoleUserMenu(List<int> RoleId);

    /// <summary>
    /// 角色菜单设置
    /// </summary>
    /// <param name="input">角色菜单更新输入</param>
    /// <returns></returns>
    Task<bool> SetRoleUserMenu(UpdateRoleUserMenuIn input);
}
