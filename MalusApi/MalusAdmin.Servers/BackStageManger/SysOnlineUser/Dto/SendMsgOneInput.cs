namespace MalusAdmin.Servers.SysOnlineUser;

public class SendMsgOneInput
{
    /// <summary>
    ///     连接的id
    /// </summary>
    public string ConnectionId { get; set; }

    /// <summary>
    ///     具体的消息
    /// </summary>
    public string Msg { get; set; }
}