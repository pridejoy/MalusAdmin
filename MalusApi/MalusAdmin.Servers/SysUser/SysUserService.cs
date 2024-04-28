using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MalusAdmin.Common;
using MalusAdmin.Encryption;
using MalusAdmin.Entity;
using MalusAdmin.Request;
using MalusAdmin.Servers.SysRoleMenu;
using MalusAdmin.Servers.SysUser.Dto;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetTaste;
using SqlSugar;
using StackExchange.Redis;
using static Dm.net.buffer.ByteArrayBuffer;

namespace MalusAdmin.Servers
{
    public class SysUserService
    {
        private readonly ISqlSugarClient _db;
        private readonly SqlSugarRepository<TSysUser> _sysUserRep;  // 仓储
        private readonly ITokenService _TokenService;
        private readonly HttpContext _HttpContext;
        private readonly SysRoleMenuService _sysRoleMenuService;
        private readonly SysMenuService _sysMenuService;

        public SysUserService(SqlSugarRepository<TSysUser> sysUserRep,
            ITokenService tokenService, SysRoleMenuService sysRoleMenuService,
            SysMenuService sysMenuService,
            IHttpContextAccessor httpContext)
        {
            _sysUserRep = sysUserRep;
            _TokenService = tokenService;
            _HttpContext = httpContext.HttpContext;
            _sysRoleMenuService = sysRoleMenuService;
            _sysMenuService = sysMenuService;
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<SysUserLoginOut> Login(SysUserLoginIn input)
        {  
            var user =await _sysUserRep
                .Where(t => t.Account.ToLower() == input.Account.ToLower()).FirstAsync();

            if (user.PassWord != Md5Util.Encrypt(input.PassWord) )
            {  
              throw new Exception("密码输入错误");
            }
            if (user.Status != 1)
            {
                throw new Exception("该账户已被冻结"); 
            }


            TokenData tokenData = new TokenData
            {
                UserId = user.Id,
                UserAccount = user.Account,
                UserRolesId = user.UserRolesId,
            };

            _TokenService.RemoveCheckToken(tokenData.UserId);
            string UserToken = _TokenService.GenerateToken(_HttpContext, tokenData);

            #region 添加登录日志
            //TSysLoginLog sysLoginLog = new TSysLoginLog();
            //sysLoginLog.UserId = user.Id;
            //sysLoginLog.DeptId = user.DeptId;
            //sysLoginLog.IP = RequestInfoUtil.GetIp(_HttpContext);
            //sysLoginLog.IPInfo = RequestInfoUtil.GetIpInfo(sysLoginLog.IP).ToString();
            //sysLoginLog.UAStr = RequestInfoUtil.GetUserAgent(_HttpContext);
            //var UAInfo = RequestInfoUtil.GetUserAgentInfo(sysLoginLog.UAStr);
            //sysLoginLog.Browser = UAInfo.Browser;
            //sysLoginLog.OS = UAInfo.OS;
            //sysLoginLog.Device = UAInfo.Device;

            //await _db.Insertable(sysLoginLog).ExecuteCommandAsync();
            #endregion

            return new SysUserLoginOut() { Id=user.Id,Name=user.Name,Token=UserToken };
        }
         
        /// <summary>
        /// 获取用户的信息
        /// </summary>
        /// <returns></returns>
       
        public async Task<GetUserInfoOut> GetUserInfo()
        {

            return new GetUserInfoOut() { 
                userId=0,
                userName= "Soybean",
                roles =new List<string> { "R_SUPER" },
                buttons=new List<string> { "B_CODE1", "B_CODE2", "B_CODE3" }
            };
        }


        /// <summary>
        /// 用户列表分页
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PageList<TSysUser>> PageList(UserPageIn input)
        {
            var dictTypes = await _sysUserRep.AsQueryable() 
                 .WhereIF(!string.IsNullOrWhiteSpace(input.KeyWord), u => u.Name.Contains(input.KeyWord.Trim()))
                 //.Select<UserPageOut>()
                 .ToPagedListAsync(input.PageNo, input.PageSize);
            return dictTypes.PagedResult();
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <returns></returns> 
        public async Task<bool> Add(UserAddAndUpIn input)
        {
            var isExist = await _sysUserRep.Where(x => x.Account == input.Account).AnyAsync();
            if(isExist) ResultCode.Fail.JsonR("已存在当前账号");
            var entity = input.Adapt<TSysUser>();
            entity.PassWord= Md5Util.Encrypt(input.PassWord);
            return await _sysUserRep.InsertReturnIdentityAsync(entity)>0;  
        }



        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<bool> Delete(int userId)
        {
            var entity = await _sysUserRep.FirstOrDefaultAsync(u => u.Id == userId);
            if (entity==null) ResultCode.Fail.JsonR("为找到当前账号");
            entity.SysIsDelete=true;
            return  await _sysUserRep.UpdateAsync(entity)>0;
        }

        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<bool> Update(UserAddAndUpIn input)
        {
            var entity = await _sysUserRep.FirstOrDefaultAsync(u => u.Id == input.Id);
            if (entity == null) ResultCode.Fail.JsonR("为找到当前账号"); 

            var sysUser = input.Adapt<TSysUser>();
            return await _sysUserRep.AsUpdateable(sysUser).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync()>0;
        }


        /// <summary>
        /// 获取登录用户的菜单权限
        /// </summary>
        /// <returns></returns>
        public async Task<UserMenuOut> GetUserMenu( )
        {
            var Out=new UserMenuOut();
            //获取所有的菜单权限
            var tree = await _sysMenuService.MenuTreeList();
            ////获取当前用户的菜单权限
            var menuid = await _sysRoleMenuService.RoleUserMenu(1);

            var res =new List<UserMenu>();
            foreach (var item in tree.Records)
            {
                res.Add(ConvertMenu(item));
            }
            //res.Add(new UserMenu()
            //{
            //    Component = "layout.base$view.home",
            //    Name = "home",
            //    Path = "/home",
            //    Meta = new Meta()
            //    {
            //        Icon = "mdi:monitor-dashboard",
            //        Title = "首页",
            //        Order = 1,
            //    }

            //});
            //res.Add(new UserMenu()
            //{
            //    Component = "layout.base$view.about",
            //    Name = "about",
            //    Path = "/about",
            //    Meta = new Meta()
            //    {
            //        Icon = "fluent:book-information-24-regular",
            //        Title = "about",
            //        Order = 1,
            //    }

            //});
            Out.Home = res.FirstOrDefault().Name;
            Out.Routes = res;
            return Out;
        }

        /// <summary>
        /// 私有方法，转化前端路由
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        private UserMenu ConvertMenu(TSysMenu menu)
        {
            return new UserMenu
            {
                Name = menu.RouteName,
                Path = menu.RoutePath,
                Component = menu.Component,
                Meta = new Meta
                { 
                    Title = menu.MenuName,
                    Icon = menu.Icon,
                    Order = menu.Sort, 
                },
                Children = menu.children?.Select(ConvertMenu).ToList()
            };
        }
    }
}
