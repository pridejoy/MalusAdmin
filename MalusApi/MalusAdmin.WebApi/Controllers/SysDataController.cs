using MalusAdmin.Servers;
using Microsoft.AspNetCore.Authorization;

namespace MalusAdmin.WebApi.Controllers
{
    /// <summary>
    /// 基础服务
    /// </summary>
    public class SysDataController : ApiControllerBase
    {
        private readonly SysDataService _Service;

        public SysDataController(SysDataService Service)
        {
            _Service = Service;
        }


        /// <summary>
        /// 获取服务器信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<JsonR> Login()
        {
            return ResultCode.Success.JsonR(await _Service.GetServerInfo());
        }

    }
}
