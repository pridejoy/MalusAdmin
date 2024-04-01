using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MalusAdmin.Common;
using MalusAdmin.Encryption;
using MalusAdmin.Entity;
using MalusAdmin.Request;
using MalusAdmin.Servers.SysUser.Dto;
using Microsoft.AspNetCore.Http;
using NetTaste;
using SqlSugar;

namespace MalusAdmin.Servers
{
    public class SysUserService
    {
        private readonly ISqlSugarClient _db;
        private readonly ITokenService _TokenService;
        private readonly HttpContext _HttpContext;

        public SysUserService(ISqlSugarClient db, ITokenService tokenService, IHttpContextAccessor httpContext)
        {
            _db = db;
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
            var user =await _db.Queryable<TSysUser>()
                .Where(t => t.Account.ToLower() == input.Account.ToLower()).FirstAsync();

            if (user.PassWord != Md5Util.Encrypt(input.PassWord) )
            {  
              throw new Exception("密码输入错误");
            }
            if (user.Status != "10")
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

         
    }
}
