namespace MalusAdmin.Servers.SysOnlineUser;

/// <summary>
/// 在线用户服务接口
/// </summary>
public interface ISysOnlineUserService
{
    /// <summary>
    /// 在线用户分页
    /// </summary>
    /// <param name="input">分页输入参数</param>
    /// <returns></returns>
    Task<PageList<TSysOnlineUser>> PageList(OnlineUserPageInput input);

    /// <summary>
    /// 强制用户下线
    /// </summary>
    /// <param name="connectionId">链接的ID</param>
    /// <returns></returns>
    Task<bool> ForceOffline(string connectionId);

    /// <summary>
    /// 给某人发送消息
    /// </summary>
    /// <param name="input">消息输入参数</param>
    /// <returns></returns>
    Task<bool> SendMsgToOne(SendMsgOneInput input);
}
