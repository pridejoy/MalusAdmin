using MalusAdmin.Servers.SysMenu;
using MalusAdmin.Servers.SysRole;

namespace MalusAdmin.Servers;

/// <summary>
/// 菜单服务接口
/// </summary>
public interface ISysMenuService
{
    /// <summary>
    /// 菜单树状查询
    /// </summary>
    /// <returns></returns>
    Task<PageList<TSysMenu>> MenuTreeList();

    /// <summary>
    /// 添加菜单
    /// </summary>
    /// <param name="input">菜单输入参数</param>
    /// <returns></returns>
    Task<bool> Add(MenuAddandUpIn input);

    /// <summary>
    /// 删除菜单
    /// </summary>
    /// <param name="id">菜单ID</param>
    /// <returns></returns>
    Task<bool> Delete(int id);

    /// <summary>
    /// 更新菜单
    /// </summary>
    /// <param name="input">菜单输入参数</param>
    /// <returns></returns>
    Task<bool> Update(MenuAddandUpIn input);

    /// <summary>
    /// 获取用户菜单
    /// </summary>
    /// <returns></returns>
    Task<List<RoleListOut>> GetUserMenu();

    /// <summary>
    /// 获取全部菜单
    /// </summary>
    /// <returns></returns>
    Task<List<RoleListOut>> GetAllMenu();
}
