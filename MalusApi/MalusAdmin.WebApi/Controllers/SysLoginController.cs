using MalusAdmin.Servers;
using MalusAdmin.Servers.SysUser.Dto;
using Microsoft.AspNetCore.Authorization;

namespace MalusAdmin.WebApi.Controllers
{
    /// <summary>
    /// 登录服务
    /// </summary>
    public class SysLoginController : ApiControllerBase
    {
        private readonly SysUserService _sysUserService;

        public SysLoginController(SysUserService userService)
        {
            _sysUserService = userService;
        } 
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<JsonR> Login(SysUserLoginIn input)
        { 
            return ResultCode.Success.JsonR(await _sysUserService.Login(input));
        }


        /// <summary>
        /// 获取登录用户的信息
        /// </summary>
        /// <returns></returns>
        [HttpGet] 
        public async Task<JsonR> GetUserInfo()
        {
            return ResultCode.Success.JsonR(await _sysUserService.GetUserInfo());
        }


        /// <summary>
        /// 获取登录用户的路由
        /// </summary>
        /// <returns></returns>
        [HttpGet] 
        //[ResponseCache(Duration = 50)] // 缓存5秒
        public async Task<JsonR> GetUserMenu()
        {
            return ResultCode.Success.JsonR(await _sysUserService.GetUserMenu());
        }
    }
}
