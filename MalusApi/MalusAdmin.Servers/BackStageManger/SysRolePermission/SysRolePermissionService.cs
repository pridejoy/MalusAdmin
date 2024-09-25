 
using MalusAdmin.Servers.SysRolePermission;
using MalusAdmin.Servers.SysRolePermission.Dto;
using MalusAdmin.Servers.SysUserButtonPermiss.Dto;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using ICacheService = MalusAdmin.Common.ICacheService;

namespace MalusAdmin.Servers;

/// <summary>
/// 用户按钮权限
/// </summary>
public class SysRolePermissionService : ISysRolePermission
{
    private readonly IActionDescriptorCollectionProvider _actionDescriptorCollectionProvider;
    private readonly ICacheService _cacheService;
    private readonly SqlSugarRepository<TSysRolePermission> _sysuserpermissionRep; // 仓储 
    private readonly ITokenService _tokenService;

    public SysRolePermissionService(SqlSugarRepository<TSysRolePermission> sysuserpermissionRep,
        ICacheService cacheService, IActionDescriptorCollectionProvider actionDescriptorCollectionProvider,
        ITokenService tokenService)
    {
        _cacheService = cacheService;
        _sysuserpermissionRep = sysuserpermissionRep;
        _actionDescriptorCollectionProvider = actionDescriptorCollectionProvider;
        _tokenService = tokenService;
    }


    /// <summary>
    /// 是否有访问当前接口的权限
    /// </summary>
    /// <returns></returns>
    public async Task<bool> HavePermission(string RouthPath)
    {
        // 获取当前用户-角色 的接口权限   
        var UserRolePer = new List<TSysRolePermission>();
        var user= await _tokenService.GetCurrentUserInfo();
        user.UserRolesId.ForEach(
            async x => { UserRolePer.AddRange(await GetRoleButtonPermiss(x)); });
        return UserRolePer.Any(x => x.UserPermiss == RouthPath);
    }


    /// <summary>
    /// 获取接口所有的路由信息
    /// </summary>
    /// <param name="values"></param>
    /// <returns></returns>
    public async Task<List<AllButtonPermissOut>> GetAllButen()
    {
        //缓存
        var cacheButtonPermiss = _cacheService.Get<List<AllButtonPermissOut>>(Constant.Cache.AllButtonPermiss);
        if (cacheButtonPermiss == null)
        {
            // 获取所有路由信息
            var actionDescriptors = _actionDescriptorCollectionProvider.ActionDescriptors.Items;

            // 创建一个列表来存储路由信息
            cacheButtonPermiss = new List<AllButtonPermissOut>();

            // 遍历所有路由信息
            foreach (var actionDescriptor in actionDescriptors)
            {
                // 获取动作描述符上的所有特性
                var permissionAttributes = actionDescriptor.EndpointMetadata
                    .OfType<PermissionAttribute>()
                    .ToList();

                // 遍历所有找到的Permission特性
                foreach (var permissionAttribute in permissionAttributes)
                {
                    // 创建一个包含路由和权限信息的对象
                    var permissionRouteInfo = new AllButtonPermissOut
                    {
                        PermissionId = "api:" + actionDescriptor.RouteValues["controller"] + ":" +
                                       actionDescriptor.RouteValues["action"],
                        PermissionName = permissionAttribute.PermissionName // 现在可以访问了
                    };
                    // 将对象添加到列表中
                    cacheButtonPermiss.Add(permissionRouteInfo);
                }
            }

            //进行缓存
            _cacheService.Set(Constant.Cache.AllButtonPermiss, cacheButtonPermiss);
        }

        // 将列表转换为动态类型返回
        return cacheButtonPermiss;
    }


    /// <summary>
    /// 删除角色的所有的权限信息
    /// </summary>
    /// <returns></returns>
    public async Task<bool> DeleteRoleButtonPermiss(int RoleId)
    {
        await _sysuserpermissionRep.DeleteAsync(x => x.RoleId == RoleId);
        await _cacheService.RemoveAsync(Constant.Cache.RoleButtonPermiss + RoleId);
        return true;
    }

    /// <summary>
    /// 为角色添加按钮权限
    /// </summary>
    /// <returns></returns>
    public async Task<bool> AddRoleButtonPermiss(UpdateRoleButtonIn Input)
    {
        await DeleteRoleButtonPermiss(Input.RoleId);
        var list = new List<TSysRolePermission>();
        Input.PermissionId.ForEach(x =>
        {
            list.Add(new TSysRolePermission { RoleId = Input.RoleId, UserPermiss = x });
        });
        return await _sysuserpermissionRep.InsertAsync(list) > 0;
    }

    /// <summary>
    /// 获取当前角色按钮权限
    /// </summary>
    /// <param name="RoleId"></param>
    /// <returns></returns>
    public async Task<List<TSysRolePermission>> GetRoleButtonPermiss(int RoleId)
    {
        var cacheButtonPermiss = _cacheService.Get<List<TSysRolePermission>>(Constant.Cache.RoleButtonPermiss + RoleId);
        if (cacheButtonPermiss == null)
        {
            var roleButtonPermiss = await _sysuserpermissionRep.Where(x => x.RoleId == RoleId).ToListAsync();
            //进行缓存
            _cacheService.Set(Constant.Cache.RoleButtonPermiss + RoleId, roleButtonPermiss);
            return roleButtonPermiss;
        }

        return cacheButtonPermiss;
    }
}