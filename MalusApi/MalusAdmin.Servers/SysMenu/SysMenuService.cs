using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MalusAdmin.Common;
using MalusAdmin.Encryption;
using MalusAdmin.Entity;
using MalusAdmin.Servers.SysMenu;
using MalusAdmin.Servers.SysRole;
using MalusAdmin.Servers.SysUser.Dto;
using Mapster;
using Microsoft.AspNetCore.Http;
using SqlSugar;

namespace MalusAdmin.Servers
{
    /// <summary>
    /// 菜单服务
    /// </summary>
    public class SysMenuService
    {
        private readonly ISqlSugarClient _db;
        private readonly SqlSugarRepository<TSysMenu> _sysMenuRep;  // 仓储
        private readonly ITokenService _TokenService; 

        public SysMenuService(SqlSugarRepository<TSysMenu> sysUserRep, ITokenService tokenService)
        {
            _sysMenuRep = sysUserRep;
            _TokenService = tokenService;
        }


        /// <summary>
        /// 列表分页
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PageList<SysMenuPageOut>> PageList(UserPageIn input)
        {
            var dictTypes = await _sysMenuRep.AsQueryable()
                 //.WhereIF(!string.IsNullOrWhiteSpace(input.SearchValue), u => u.Name.Contains(input.SearchValue.Trim()))
                 .Select<SysMenuPageOut>()
                 .ToPagedListAsync(input.PageNo, input.PageSize);
            return dictTypes.PagedResult();
        }


        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns> 
        public async Task<bool> Add(MenuAddandUpIn input)
        {
            var isExist = await _sysMenuRep.Where(x => x.MenuType == input.MenuType).AnyAsync();
            if (isExist) ResultCode.Fail.JsonR("已存在当前角色");
            var entity = input.Adapt<TSysMenu>(); 
            return await _sysMenuRep.InsertReturnIdentityAsync(entity) > 0;
        }



        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<bool> Delete(int id)
        {
            var entity = await _sysMenuRep.FirstOrDefaultAsync(u => u.Id == id);
            if (entity == null) ResultCode.Fail.JsonR("未找到当前菜单");
            entity.SysIsDelete = true;
            return await _sysMenuRep.UpdateAsync(entity) > 0;
        }

        /// <summary>
        /// 更新菜单
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<bool> Update(RoleAddandUpIn input)
        {
            var entity = await _sysMenuRep.FirstOrDefaultAsync(u => u.Id == input.Id);
            if (entity == null) ResultCode.Fail.JsonR("为找到当前账号");

            var sysRole= input.Adapt<TSysMenu>();
            return await _sysMenuRep.AsUpdateable(sysRole).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync() > 0;
        }

        /// <summary>
        /// 用户菜单
        /// </summary>
        /// <returns></returns>
        public async Task<List<RoleListOut>> GetUserMenu()
        {
            var list = await _sysMenuRep.Context.Queryable<TSysRole>()
                .Select<RoleListOut>().ToListAsync(); 
            return list; 
        }


        /// <summary>
        /// 全部菜单
        /// </summary>
        /// <returns></returns>
        public async Task<List<RoleListOut>> GetAllMenu()
        {
            var list = await _sysMenuRep.Context.Queryable<TSysRole>()
                .Select<RoleListOut>().ToListAsync();
            return list;
        }
    }
}
