using MalusAdmin.Servers.Hub;
using Microsoft.AspNetCore.SignalR;

namespace MalusAdmin.Servers.SysOnlineUser;



/// <summary>
/// 在线用户
/// </summary>
[ApiExplorerSettings(GroupName = nameof(ApiVersionGropInfo.BackStageManger))]
public class SysOnlineUserService : ApiControllerBase, ISysOnlineUserService
{
    private readonly IHubContext<OnlineUserHub, IOnlineUserHub> _onlineUserHubContext;
    private readonly SqlSugarRepository<TSysOnlineUser> _rep; // 仓储

    public SysOnlineUserService(SqlSugarRepository<TSysOnlineUser> rep,
        IHubContext<OnlineUserHub, IOnlineUserHub> onlineUserHubContext)
    {
        _rep = rep;
        _onlineUserHubContext = onlineUserHubContext;
    }

    /// <summary>
    /// 在线用户分页
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [Permission("在线用户分页")]
    public async Task<PageList<TSysOnlineUser>> PageList([FromQuery]OnlineUserPageInput input)
    {
        var data = await _rep.AsQueryable()
            .Where(x => x.Time >= DateTime.Now.AddHours(-3))
            .ToPagedListAsync(input.PageNo, input.PageSize);
        return data.PagedResult();
    }

    /// <summary>
    /// 强制用户下线
    /// </summary>
    /// <param name="connectionId">链接的id</param>
    /// <returns></returns>
    [HttpGet]
    [Permission("强制用户下线")]
    public async Task<bool> ForceOffline(string connectionId)
    {
        try
        {
            await _rep.DeleteAsync(x => x.ConnectionId == connectionId);
            await _onlineUserHubContext.Clients.Client(connectionId).ForceOffline("强制下线");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return true;
    }

    /// <summary>
    /// 给某人发送消息
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    [Permission("给指定用户发送消息")]
    public async Task<bool> SendMsgToOne(SendMsgOneInput input)
    {
        try
        {
            await _onlineUserHubContext.Clients.Client(input.ConnectionId).PublicNotice(input.Msg);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return true;
    }
}