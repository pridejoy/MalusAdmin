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

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <returns></returns> 
        [HttpGet]
        public async Task<JsonR> PageList([FromQuery]UserPageIn input)
        {
            return ResultCode.Success.JsonR(await _sysUserService.PageList(input));
        }


        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns> 
        [HttpPost]
        public async Task<JsonR> Add(UserPageIn input)
        {
            return ResultCode.Success.JsonR(await _sysUserService.Add(input));
        }

    }
}
