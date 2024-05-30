namespace MalusAdmin.Servers.SysOnlineUser;

public class OnlineUser
{
    /// <summary>
    ///     链接id
    /// </summary>
    public string ConnectionId { get; set; }

    /// <summary>
    ///     用户名字
    /// </summary>
    public string RealName { get; set; }

    /// <summary>
    ///     在线时间
    /// </summary>
    public DateTime Time { get; set; }

    /// <summary>
    ///     ip
    /// </summary>
    public string Ip { get; set; }

    /// <summary>
    ///     浏览器
    /// </summary>
    public string Browser { get; set; }

    /// <summary>
    ///     系统
    /// </summary>
    public string Os { get; set; }
}