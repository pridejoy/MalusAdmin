using SqlSugar;

namespace MalusAdmin.Repository.Model;

[SugarTable("bs_wx_config")]
public class BsWxConfig
{
    /// <summary>
    ///     小程序的appid
    /// </summary>
    [SugarColumn(IsPrimaryKey = true)]
    public string WechatAppID { get; set; }

    /// <summary>
    ///     小程序的servere
    /// </summary>
    public string WechatAppSecret { get; set; }

    /// <summary>
    ///     小程序的名称
    /// </summary>
    public string WechatAppName { get; set; }

    /// <summary>
    ///     Token
    /// </summary>
    public string AccessToken { get; set; }

    /// <summary>
    ///     过期时间(秒)，提前一个小时过期。每小时去拿一次
    /// </summary>
    public int ExpireTime { get; set; }

    /// <summary>
    ///     更新时间
    /// </summary>
    public DateTime UpTime { get; set; }

    /// <summary>
    ///     下次过期时间
    /// </summary>
    public DateTime NextUpTime { get; set; }

    /// <summary>
    ///     返回的信息
    /// </summary>
    public string Res { get; set; }
}