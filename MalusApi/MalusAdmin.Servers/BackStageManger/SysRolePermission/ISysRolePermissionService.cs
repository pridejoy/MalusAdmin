using MalusAdmin.Servers ;

namespace MalusAdmin.Servers; 

/// <summary>
/// 用户按钮权限服务接口
/// </summary>
public interface ISysRolePermissionService
{
    /// <summary>
    /// 是否有访问当前接口的权限
    /// </summary>
    /// <param name="RouthPath">路由路径</param>
    /// <returns></returns>
    Task<bool> HasPermissionAsync(string RouthPath);

    /// <summary>
    /// 获取接口所有的路由信息
    /// </summary>
    /// <returns></returns>
    Task<List<AllButtonPermissOut>> GetAllButen();

    /// <summary>
    /// 删除角色的所有权限信息
    /// </summary>
    /// <param name="RoleId">角色ID</param>
    /// <returns></returns>
    Task<bool> DeleteRoleButtonPermiss(int RoleId);

    /// <summary>
    /// 为角色添加按钮权限
    /// </summary>
    /// <param name="Input">角色按钮权限更新输入</param>
    /// <returns></returns>
    Task<bool> AddRoleButtonPermiss(UpdateRoleButtonIn Input);

    /// <summary>
    /// 获取当前角色按钮权限
    /// </summary>
    /// <param name="RoleId">角色ID</param>
    /// <returns></returns>
    Task<List<TSysRolePermission>> GetRoleButtonPermiss(int RoleId);

    /// <summary>
    /// 获取当前用户的权限
    /// </summary>
    /// <param name="userid">用户ID</param>
    /// <returns></returns>
    Task<List<string>> GetUserPermiss(int userid);
}

