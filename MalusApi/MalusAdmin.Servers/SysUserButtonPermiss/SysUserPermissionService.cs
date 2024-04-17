using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MalusAdmin.Common;
using MalusAdmin.Entity;
using MalusAdmin.Servers.SysUserButtonPermiss.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Routing; 

namespace MalusAdmin.Servers.SysUserButtonPermiss
{
    /// <summary>
    /// 用户按钮权限
    /// </summary>
    public class SysUserPermissionService
    { 
        private readonly SqlSugarRepository<TSysUserPermission> _sysuserpermissionRep;  // 仓储
        private readonly ITokenService _TokenService;
        private readonly IActionDescriptorCollectionProvider _actionDescriptorCollectionProvider;
        private readonly ICacheService _cacheService;

        public SysUserPermissionService(SqlSugarRepository<TSysUserPermission> sysuserpermissionRep,
            ICacheService cacheService,
            ITokenService tokenService, IActionDescriptorCollectionProvider actionDescriptorCollectionProvider)
        {
            _cacheService= cacheService;
            _sysuserpermissionRep = sysuserpermissionRep;
            _TokenService = tokenService;
            _actionDescriptorCollectionProvider = actionDescriptorCollectionProvider;
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
            if (cacheButtonPermiss==null)
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
                            PermissionId = "api:" + actionDescriptor.RouteValues["controller"] + ":" + actionDescriptor.RouteValues["action"],
                            PermissionName = permissionAttribute.PermissionName // 现在可以访问了
                        };
                        // 将对象添加到列表中
                        cacheButtonPermiss.Add(permissionRouteInfo);
                    }
                }

                //进行缓存
                _cacheService.Add(Constant.Cache.AllButtonPermiss, cacheButtonPermiss, TimeSpan.FromMinutes(5)); 
            }

            // 将列表转换为动态类型返回
            return cacheButtonPermiss;
        }


        /// <summary>
        /// 删除用户所有的权限信息
        /// </summary>
        /// <returns></returns>
        public async Task<bool> DeleteUserButtonPermiss(int UserId)
        { 
            return await _sysuserpermissionRep.DeleteAsync(x => x.UserId == UserId)>0;
        }

        /// <summary>
        /// 为用户添加按钮权限
        /// </summary>
        /// <returns></returns>
        public async Task<bool> AddUserButtonPermiss(List<string> PermissionId)
        {
            await DeleteUserButtonPermiss(0);
            var list=new List<TSysUserPermission>();
            PermissionId.ForEach(x =>
            {
                list.Add(new TSysUserPermission { UserId = 1, UserPermiss = x });
            }); 
            return await _sysuserpermissionRep.InsertAsync(list)>0; 
        }

        /// 获取用户按钮权限
        /// </summary>
        /// <returns></returns>
        public async Task<List<TSysUserPermission>> GetUserButtonPermiss(int UserId)
        {
            return await _sysuserpermissionRep.Where(x=>x.UserId== UserId).ToListAsync() ;
        }


        /// <summary>
        /// 是否有访问当前接口的权限
        /// </summary>
        /// <returns></returns>
        public async Task<bool> HavePermission()
        {
            return true;
        }
    }
}
