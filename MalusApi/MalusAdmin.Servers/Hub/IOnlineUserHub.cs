namespace MalusAdmin.Servers.Hub;

public interface IOnlineUserHub
{
    /// <summary>
    /// 在线用户列表
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    Task OnlineUserList(object context);

    /// <summary>
    /// 强制下线
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    Task ForceOffline(object context);


    /// <summary>
    /// 发布上线通知消息
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    Task PublicNotice(string context);

    /// <summary>
    ///接收消息
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    Task ReceiveMessage(object context);
}