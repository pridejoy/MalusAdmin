using MalusAdmin.Servers.SysUser;
using MalusAdmin.Servers.SysUser.Dto;
using Microsoft.AspNetCore.Authorization;

namespace MalusAdmin.Servers.BackStageManger
{

    /// <summary>
    /// 登录服务
    /// </summary>
    [ApiExplorerSettings(GroupName = nameof(ApiVersionGropInfo.BackStageManger))]
    public class SysLoginService : ApiControllerBase
    {
        private readonly ISqlSugarClient _db;
        private readonly SqlSugarRepository<TSysMenu> _sysMenuRep; // 仓储
        private readonly ITokenService _TokenService;
        private readonly ISysUserService _sysUserService;


        public SysLoginService(SqlSugarRepository<TSysMenu> sysUserRep, ITokenService tokenService, ISysUserService userService)
        {
            _sysMenuRep = sysUserRep;
            _TokenService = tokenService;
            _sysUserService = userService;
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<SysUserLoginOut> Login(SysUserLoginIn input)
        {
            return await _sysUserService.Login(input);
        }


        /// <summary>
        /// 获取登录用户的信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        //[ResponseCache(Duration = 60 * 60)]
        public async Task<GetUserInfoOut> GetUserInfo()
        {
            return await _sysUserService.GetUserInfo();
        }


        /// <summary>
        /// 获取登录用户的路由
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ResponseCache(Duration = 60 * 60)]
        //[DisabledRequestRecord]
        public async Task<UserMenuOut> GetUserMenu()
        {
            return await _sysUserService.GetUserMenu();
        }

        /// <summary>
        /// 更改基础资料
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ReadOnly]
        public async Task<bool> UpdateUserInfo([FromBody] SysUserInfo input)
        {
            return await _sysUserService.UpdateUserInfo(input);
        }


        /// <summary>
        /// 更改密码
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ReadOnly]
        public async Task<bool> ResetPassWord([FromBody] ResetPassWord input)
        {
            return await _sysUserService.ResetPassWord(input);
        }
    }
}
