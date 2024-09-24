 
using MalusAdmin.Servers.Hub;
using Microsoft.AspNetCore.SignalR; 

namespace MalusAdmin.Servers.SysOnlineUser;

/// <summary>
/// </summary>
public class SysOnlineUserService
{ 
    private readonly SqlSugarRepository<TSysOnlineUser> _rep; // 仓储
    private readonly IHubContext<OnlineUserHub, IOnlineUserHub> _onlineUserHubContext;
    public SysOnlineUserService( SqlSugarRepository<TSysOnlineUser> rep,
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
    public async Task<PageList<TSysOnlineUser>> PageList(OnlineUserPageInput input)
    { 
        var data = await _rep.AsQueryable()
            .Where(x=>x.Time>=DateTime.Now.AddHours(-3))
            .ToPagedListAsync(input.PageNo, input.PageSize);
        return data.PagedResult();
    }
    
    /// <summary>
    /// 强制用户下线
    /// </summary>
    /// <param name="connectionId">链接的id</param>
    /// <returns></returns>
    public async Task<Boolean> ForceOffline(string connectionId)
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
    public async Task<Boolean> SendMsgToOne(SendMsgOneInput input)
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