using MalusAdmin.Common;
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
        [Permission("用户信息分页查询")]
        public async Task<JsonR> PageList([FromQuery] UserPageIn input)
        {
            return ResultCode.Success.JsonR(await _sysUserService.PageList(input));
        }


        /// <summary>
        /// 添加用户
        /// </summary>
        /// <returns></returns> 
        [HttpPost]
        [Permission("用户信息添加")]
        public async Task<JsonR> Add(UserAddAndUpIn input)
        {
            return ResultCode.Success.JsonR(await _sysUserService.Add(input));
        }


        /// <summary>
        /// 删除用户
        /// </summary>
        /// <returns></returns> 
        [HttpPost("{id}")]
        [Permission("用户信息删除")]
        public async Task<JsonR> Delete(int id)
        {
            return ResultCode.Success.JsonR(await _sysUserService.Delete(id));
        }



        /// <summary>
        /// 更新用户
        /// </summary>
        /// <returns></returns> 
        [HttpPost]
        [Permission("用户信息更新")]
        public async Task<JsonR> Update(UserAddAndUpIn input)
        {
            return ResultCode.Success.JsonR(await _sysUserService.Update(input));
        }


         

    }
}
