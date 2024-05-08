using MalusAdmin.Servers;
using MalusAdmin.Servers.SysOpLog.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MalusAdmin.WebApi.Controllers
{
    /// <summary>
    /// 禁用日志记录
    /// </summary>
    [DisabledRequestRecord]
    public class SysLogController : ApiControllerBase
    {
        private readonly SysOpLogService _server;

        public SysLogController(SysOpLogService server)
        {
            _server = server;
        }


        /// <summary>
        /// 日志分页
        /// </summary>
        /// <returns></returns>
        [HttpGet] 
        public async Task<JsonR> PageList([FromQuery] SysLogPageIn input)
        {
            return ResultCode.Success.JsonR(await _server.PageList(input));
        }

    }
}
