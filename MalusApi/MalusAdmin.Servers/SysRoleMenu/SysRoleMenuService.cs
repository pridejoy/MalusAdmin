using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MalusAdmin.Common;
using MalusAdmin.Entity;
using MalusAdmin.Servers.SysRoleMenu.Dto;
using Models;
using SqlSugar;

namespace MalusAdmin.Servers.SysRoleMenu
{
    /// <summary>
    /// 角色菜单服务
    /// </summary>
    public class SysRoleMenuService
    {
        private readonly ISqlSugarClient _db;
        private readonly SqlSugarRepository<TSysRoleMenu> _sysRoleMenuRep;  // 仓储
        private readonly ITokenService _TokenService;

        public SysRoleMenuService(SqlSugarRepository<TSysRoleMenu> sysRoleMenuRep, ITokenService tokenService)
        {
            _sysRoleMenuRep = sysRoleMenuRep;
            _TokenService = tokenService;
        }

         
        /// <summary>
        /// 角色菜单获取
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<List<int>> RoleUserMenu(List<int> RoleId)
        {
            var Res = await _sysRoleMenuRep.Where(x => RoleId.Contains(x.RoleId))
                .Select(x=>x.MenuId)
                .ToListAsync();  
            return Res;
        }

        /// <summary>
        /// 角色菜单设置
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<bool> SetRoleUserMenu(UpdateRoleUserMenuIn input)
        {
            await _sysRoleMenuRep.DeleteAsync(x => x.RoleId == input.RoleId);
            var list=new List<TSysRoleMenu>();
            input.MenuId.ForEach(x =>
            {
                list.Add(new TSysRoleMenu { RoleId = input.RoleId, MenuId = x });
            });
           var ResCount=  await _sysRoleMenuRep.InsertAsync(list);

            return ResCount>0;
        }
    }
}
