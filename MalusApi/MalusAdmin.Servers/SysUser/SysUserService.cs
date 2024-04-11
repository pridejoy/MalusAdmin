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
using MalusAdmin.Servers.SysUser.Dto;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetTaste;
using SqlSugar;
using StackExchange.Redis;

namespace MalusAdmin.Servers
{
    public class SysUserService
    {
        private readonly ISqlSugarClient _db;
        private readonly SqlSugarRepository<TSysUser> _sysUserRep;  // 仓储
        private readonly ITokenService _TokenService;
        private readonly HttpContext _HttpContext;

        public SysUserService(SqlSugarRepository<TSysUser> sysUserRep, ITokenService tokenService, IHttpContextAccessor httpContext)
        { 
            _sysUserRep = sysUserRep;
            _TokenService = tokenService;
            _HttpContext = httpContext.HttpContext;
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
            if (user.Status != 10)
            {
                throw new Exception("该账户已被冻结"); 
            }


            TokenData tokenData = new TokenData
            {
                UserId = user.Id,
                UserAccount = user.Account,
                UserDept = user.DeptId,
                UserRole = user.RoleId,
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
        /// 获取登录用户的路由信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> GetUserRoute()
        {
            return true;
        }


        /// <summary>
        /// 获取登录用户的按钮信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> GetUserBtns()
        {

            return true;
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
                 .WhereIF(!string.IsNullOrWhiteSpace(input.SearchValue), u => u.Name.Contains(input.SearchValue.Trim())) 
                 .ToPagedListAsync(input.PageNo, input.PageSize);
            return dictTypes.PagedResult();
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <returns></returns> 
        public async Task<bool> Add(UserAddIn input)
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
        public async Task<bool> Update(UserEditIn input)
        {
            var entity = await _sysUserRep.FirstOrDefaultAsync(u => u.Id == input.Id);
            if (entity == null) ResultCode.Fail.JsonR("为找到当前账号"); 

            var sysUser = input.Adapt<TSysUser>();
            return await _sysUserRep.AsUpdateable(sysUser).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandAsync()>0;
        }
    }
}
