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
    private readonly ISysRolePermission sysRolePermission;

    public SysRolePermissionService(SqlSugarRepository<TSysRolePermission> sysuserpermissionRep,
        ICacheService cacheService, IActionDescriptorCollectionProvider actionDescriptorCollectionProvider,
        ITokenService tokenService)
    {
        _cacheService = cacheService;
        _sysuserpermissionRep = sysuserpermissionRep;
        _actionDescriptorCollectionProvider = actionDescriptorCollectionProvider;
    
    }


    /// <summary>
    /// 是否有访问当前接口的权限
    /// </summary>
    /// <returns></returns>
    public async Task<bool> HasPermissionAsync(string RouthPath)
    {
        //不校验权限的接口
        var nocheckpermiss = new string[]
        {
            "api:SysLogin:GetUserInfo" ,//todo 登陆的人都应该有这个接口的权限
            "api:SysLogin:GetUserMenu"
        };
        if (nocheckpermiss.Contains(RouthPath)) return true;

        var userButton =await GetUserPermiss(App.User.Info.UserId);

        return userButton.Any(x => x == RouthPath);
    }


    /// <summary>
    /// 获取接口所有的路由信息
    /// </summary>
    /// <param name="values"></param>
    /// <returns></returns>
    public async Task<List<AllButtonPermissOut>> GetAllButen()
    {
        //缓存
        var cacheButtonPermiss = _cacheService.Get<List<AllButtonPermissOut>>(CacheConstant.AllButtonPermiss);
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
            _cacheService.Set(CacheConstant.AllButtonPermiss, cacheButtonPermiss);
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
        var roleButtonPermiss = await _sysuserpermissionRep.Where(x => x.RoleId == RoleId).ToListAsync();
        //tode 进行缓存

        return roleButtonPermiss;
    }

    /// <summary>
    /// 获取当前用户的权限
    /// </summary>
    /// <param name="userid"></param>
    /// <returns></returns>
    public async Task<List<string>> GetUserPermiss(int userid)
    {
     
        var userbutton = _cacheService.Get<List<string>>(CacheConstant.UserButton+userid)??new List<string>();
        if (userbutton == null)
        { 
            //正常来说缓存是有数据的
            //进行缓存
            //_cacheService.Set(CacheConstant.AllButtonPermiss, cacheButtonPermiss);
        }
        return userbutton;
    }
}