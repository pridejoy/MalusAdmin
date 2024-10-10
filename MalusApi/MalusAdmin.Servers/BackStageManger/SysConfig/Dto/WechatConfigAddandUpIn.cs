namespace MalusAdmin.Servers;

public class WechatConfigAddandUpIn
{
    public int ConfigID { get; set; }

    /// <summary>
    ///     Desc:
    ///     Default:
    ///     Nullable:True
    /// </summary>
    public string? ConfigKey { get; set; }

    /// <summary>
    ///     Desc:
    ///     Default:
    ///     Nullable:True
    /// </summary>
    public string? ConfigValue { get; set; }

    /// <summary>
    ///     参数配置类型
    /// </summary>
    public string? ConfigType { get; set; }

    /// <summary>
    ///     Desc:
    ///     Default:
    ///     Nullable:True
    /// </summary>
    public string? ConfigdDescribe { get; set; }

    /// <summary>
    ///     Desc:
    ///     Default:0
    ///     Nullable:True
    /// </summary>
    public bool? IsDeleted { get; set; }
}