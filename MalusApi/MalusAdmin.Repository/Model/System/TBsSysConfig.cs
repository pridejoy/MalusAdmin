using SqlSugar;

namespace MalusAdmin.Repository.Model;

/// <summary>
///参数配置表
/// </summary>
[SugarTable("t_sys_config")]
public class TBsSysConfig
{
    /// <summary>
    ///Desc:
    ///Default:
    ///Nullable:False
    /// </summary>
    [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
    public int ConfigID { get; set; }

    /// <summary>
    ///Desc:参数key
    ///Default:
    ///Nullable:True
    /// </summary>
    public string? ConfigKey { get; set; }


    /// <summary>
    ///参数类型
    /// </summary>
    public string? ConfigType { get; set; }

    /// <summary>
    ///Desc:参数值
    ///Default:
    ///Nullable:True
    /// </summary>
    public string? ConfigValue { get; set; }

    /// <summary>
    ///Desc:
    ///Default:
    ///Nullable:True
    /// </summary>
    public string? configDescribe { get; set; }

    /// <summary>
    ///Desc:
    ///Default:0
    ///Nullable:True
    /// </summary>
    public bool? IsDeleted { get; set; }
}