using MalusAdmin.Servers;
using MalusAdmin.Servers.SysOpLog.Dto;
using MalusAdmin.WebApi.Filter;

namespace MalusAdmin.WebApi.Controllers.BackStageManger;

/// <summary>
/// 禁用日志记录
/// </summary>
[DisabledRequestRecord]
[ApiExplorerSettings(GroupName = "后台管理")]
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
    public async Task<dynamic> PageList([FromQuery] SysLogPageIn input)
    {
        return await _server.PageList(input);
    }
}