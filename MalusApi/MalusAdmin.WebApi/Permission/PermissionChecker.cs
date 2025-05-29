using System.Security.Claims;
using MalusAdmin.Common.Components;
using MalusAdmin.Servers;

namespace MalusAdmin.WebApi
{
    //public class PermissionChecker : IPermissionChecker
    //{
    //    private readonly IAppUser _appUser;
    //    private readonly ISysRolePermissionService _sysRolePermission;

    //    public PermissionChecker(IAppUser appUser, ISysRolePermissionService sysRolePermission)
    //    {
    //        _appUser = appUser;
    //        _sysRolePermission = sysRolePermission;
    //    }
    //    public virtual async Task<bool> IsGrantedAsync(ClaimsPrincipal claimsPrincipal, string name)
    //    {
    //        // 如果当前用户是超级管理员，跳过验证
    //        //if (_appUser.Info.IsSuperAdmin()) return true;
             
    //        string permission = name; 
    //        if (string.IsNullOrEmpty(permission))
    //        {
    //            // todo 
    //            // 获取录入系统中的所有权限
    //            var all = await _sysRolePermission.GetAllButen();
    //            List<string> allPermissions = all.Select(x=>x.PermissionId).ToList();

    //            // 如果没有配置该权限，则不限制该权限，通过验证
    //            if (!allPermissions.Contains(permission)) return true;

    //            // 获取当前用户的所有权限
    //            List<string> permissions = await _sysRolePermission.GetUserPermiss(App.User.Info.UserId);

    //            // 如果当前用户拥有对应权限，则通过验证
    //            if (permissions.Contains(permission)) return true;
    //        }
    //        if (string.IsNullOrEmpty(permission)) return false;
    //        return false;
    //    }
    //}
}
