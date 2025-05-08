using MalusAdmin.Servers.SysRole;
using MalusAdmin.Servers.SysUser.Dto;

namespace MalusAdmin.Servers;

/// <summary>
/// 角色服务接口
/// </summary>
public interface ISysRoleService
{
    /// <summary>
    /// 角色列表分页
    /// </summary>
    /// <param name="input">分页输入参数</param>
    /// <returns></returns>
    Task<PageList<TSysRole>> PageList(UserPageIn input);

    /// <summary>
    /// 添加角色
    /// </summary>
    /// <param name="input">角色输入参数</param>
    /// <returns></returns>
    Task<bool> Add(RoleAddandUpIn input);

    /// <summary>
    /// 删除角色
    /// </summary>
    /// <param name="id">角色ID</param>
    /// <returns></returns>
    Task<bool> Delete(int id);

    /// <summary>
    /// 更新角色
    /// </summary>
    /// <param name="input">角色输入参数</param>
    /// <returns></returns>
    Task<bool> Update(RoleAddandUpIn input);

    /// <summary>
    /// 用户列表
    /// </summary>
    /// <returns></returns>
    Task<List<RoleListOut>> List();
}
