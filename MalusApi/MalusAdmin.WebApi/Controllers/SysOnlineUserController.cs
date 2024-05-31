using MalusAdmin.Servers.SysOnlineUser;

namespace MalusAdmin.WebApi.Controllers;

/// <summary>
/// 在线用户
/// </summary>
public class SysOnlineUserController: ApiControllerBase
{
    private readonly SysOnlineUserService _service;

    public SysOnlineUserController(SysOnlineUserService service)
    {
        _service = service;
    }
    
    /// <summary>
    /// 分页查询
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Permission("在线用户分页")]
    public async Task<JsonR> PageList([FromQuery] OnlineUserPageInput input)
    {
        return ResultCode.Success.JsonR(await _service.PageList(input));
    }
    
    
    /// <summary>
    /// 强制下线
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Permission("强制用户下线")]
    public async Task<JsonR> ForceOffline([FromQuery] string connectionId)
    {
        return ResultCode.Success.JsonR(await _service.ForceOffline(connectionId));
    }
    
    /// <summary>
    /// 给指定用户发送消息
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [Permission("给指定用户发送消息")]
    public async Task<JsonR> SendMsgToOne([FromBody] SendMsgOneInput input )
    {
        return ResultCode.Success.JsonR(await _service.SendMsgToOne(input));
    }
}