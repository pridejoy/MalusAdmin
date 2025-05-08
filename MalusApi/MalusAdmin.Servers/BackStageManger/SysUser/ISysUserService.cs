using MalusAdmin.Servers.SysUser.Dto;

namespace MalusAdmin.Servers.SysUser;

/// <summary>
/// 用户服务接口
/// </summary>
public interface ISysUserService
{
    /// <summary>
    /// 用户登录
    /// </summary>
    /// <param name="input">登录输入参数</param>
    /// <returns></returns>
    Task<SysUserLoginOut> Login(SysUserLoginIn input);

    /// <summary>
    /// 获取用户信息
    /// </summary>
    /// <returns></returns>
    Task<GetUserInfoOut> GetUserInfo();

    /// <summary>
    /// 更改用户信息
    /// </summary>
    /// <param name="input">用户信息输入</param>
    /// <returns></returns>
    Task<bool> UpdateUserInfo(SysUserInfo input);

    /// <summary>
    /// 更改密码
    /// </summary>
    /// <param name="input">密码重置输入</param>
    /// <returns></returns>
    Task<bool> ResetPassWord(ResetPassWord input);

    /// <summary>
    /// 用户列表分页
    /// </summary>
    /// <param name="input">分页输入参数</param>
    /// <returns></returns>
    Task<PageList<TSysUser>> PageList(UserPageIn input);

    /// <summary>
    /// 添加用户
    /// </summary>
    /// <param name="input">用户添加输入</param>
    /// <returns></returns>
    Task<bool> Add(UserAddAndUpIn input);

    /// <summary>
    /// 删除用户
    /// </summary>
    /// <param name="userId">用户ID</param>
    /// <returns></returns>
    Task<bool> Delete(int userId);

    /// <summary>
    /// 更新用户
    /// </summary>
    /// <param name="input">用户更新输入</param>
    /// <returns></returns>
    Task<bool> Update(UserAddAndUpIn input);

    /// <summary>
    /// 获取登录用户的菜单权限
    /// </summary>
    /// <returns></returns>
    Task<UserMenuOut> GetUserMenu();
}

