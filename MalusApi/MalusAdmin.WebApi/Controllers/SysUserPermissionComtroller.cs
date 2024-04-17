using MalusAdmin.Servers;
using MalusAdmin.Servers.SysUserButtonPermiss;
using Microsoft.AspNetCore.Authorization;

namespace MalusAdmin.WebApi.Controllers
{
    
    /// <summary>
    /// 按钮权限服务
    /// </summary>
    public class SysUserPermissionComtroller: ApiControllerBase
    {
        private readonly SysUserPermissionService _service;

        public SysUserPermissionComtroller(SysUserPermissionService service)
        {
           _service = service;
        }


        /// <summary>
        /// 获取所有按钮列表
        /// </summary>
        /// <returns></returns>
        [HttpGet] 
        public async Task<JsonR> GetAllButen( )
        {
            return ResultCode.Success.JsonR(await _service.GetAllButen());
        }
         
        
    }
}
