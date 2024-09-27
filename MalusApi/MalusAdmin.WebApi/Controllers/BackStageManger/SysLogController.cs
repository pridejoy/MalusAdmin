using MalusAdmin.Servers;
using MalusAdmin.Servers.SysLog;
using MalusAdmin.WebApi.Filter;

namespace MalusAdmin.WebApi.Controllers.BackStageManger;

/// <summary>
/// 日志服务
/// </summary>
[DisabledRequestRecord]
[ApiExplorerSettings(GroupName = "后台管理")]
public class SysLogController : ApiControllerBase
{
    private readonly SysLogService _server;

    public SysLogController(SysLogService server)
    {
        _server = server;
    }


    /// <summary>
    /// 访问日志分页
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<dynamic> VisPageList([FromQuery] SysLogPageIn input)
    {
        return await _server.VisPageList(input);
    }

    /// <summary>
    /// 日志分页
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<dynamic> ErrPageList([FromQuery] SysLogPageIn input)
    {
        await _server.AddLog("后台日志", "用户123登录了系统");
        return await _server.ErrPageList(input);
    }

    /// <summary>
    ///操作 日志分页
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<dynamic> OpPageList([FromQuery] SysLogPageIn input)
    {
     
        return await _server.OpPageList(input);
    }
}