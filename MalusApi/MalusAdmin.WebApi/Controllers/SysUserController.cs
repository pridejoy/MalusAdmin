using MalusAdmin.Servers;
using MalusAdmin.Servers.SysUser.Dto;
using Microsoft.AspNetCore.Authorization;

namespace MalusAdmin.WebApi.Controllers
{
    /// <summary>
    /// 用户服务
    /// </summary>
    public class SysUserController : ApiControllerBase
    {
        private readonly SysUserService _sysUserService;

        public SysUserController(SysUserService userService)
        {
            _sysUserService = userService;
        }  

    }
}
