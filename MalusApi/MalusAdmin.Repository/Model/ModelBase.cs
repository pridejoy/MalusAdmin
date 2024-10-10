using SqlSugar;

namespace MalusAdmin.Repository.Model;
/// <summary>
///     实体的基类
/// </summary>
public class ModelBase
{
    /// <summary>
    ///     系统字段-创建人
    /// </summary>
    [SugarColumn(ColumnName = "SysCreateUser")]
    public int SysCreateUser { get; set; }

    /// <summary>
    ///     系统字段-创建时间
    ///     默认值:CURRENT_TIMESTAMP
    /// </summary>
    [SugarColumn(ColumnName = "SysCreateTime", InsertServerTime = true, IsOnlyIgnoreInsert = true,IsIgnore = true)] 
    public DateTime SysCreateTime { get; set; }

    /// <summary>
    ///     系统字段-修改人
    /// </summary>
    [SugarColumn(ColumnName = "SysUpdateUser")]
    public int SysUpdateUser { get; set; }

    /// <summary>
    ///系统字段-修改时间
    ///     默认值:CURRENT_TIMESTAMP
    /// </summary>
    [SugarColumn(ColumnName = "SysUpdateTime", UpdateServerTime  = true, IsOnlyIgnoreInsert = true,IsIgnore = true)]
    public DateTime SysUpdateTime { get; set; }

    /// <summary>
    ///系统字段-删除人
    /// </summary>
    [SugarColumn(ColumnName = "SysDeleteUser")]
    public int SysDeleteUser { get; set; }

    /// <summary>
    /// 系统字段-删除时间
    /// </summary>
    [SugarColumn(ColumnName = "SysDeleteTime",UpdateServerTime  = true, IsOnlyIgnoreInsert = true,IsIgnore = true)]
    public DateTime SysDeleteTime { get; set; }

    /// <summary>
    ///     系统字段-删除标记
    ///     默认值:0
    /// </summary>
    [SugarColumn(ColumnName = "SysIsDelete", DefaultValue = "0")]
    public bool SysIsDelete { get; set; }
}