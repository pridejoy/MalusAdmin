using SqlSugar;

namespace MalusAdmin.Entity;

/// <summary>
///     t_sys_task_log:数据库映射类
/// </summary>
[Serializable]
[SugarTable("t_sys_task_log")]
public class TSysTaskLog
{
	/// <summary>
	///     主键
	/// </summary>
	[SugarColumn(ColumnName = "Id", IsPrimaryKey = true, IsIdentity = true)]
    public int Id { get; set; }

	/// <summary>
	///     系统字段-创建人
	/// </summary>
	[SugarColumn(ColumnName = "SysCreateUser")]
    public int SysCreateUser { get; set; }

	/// <summary>
	///     系统字段-创建时间
	///     默认值:CURRENT_TIMESTAMP
	/// </summary>
	[SugarColumn(ColumnName = "SysCreateTime", IsOnlyIgnoreInsert = true)]
    public DateTime SysCreateTime { get; set; }

	/// <summary>
	///     系统字段-修改人
	/// </summary>
	[SugarColumn(ColumnName = "SysUpdateUser")]
    public int SysUpdateUser { get; set; }

	/// <summary>
	///     系统字段-修改时间
	///     默认值:CURRENT_TIMESTAMP
	/// </summary>
	[SugarColumn(ColumnName = "SysUpdateTime", IsOnlyIgnoreInsert = true)]
    public DateTime SysUpdateTime { get; set; }

	/// <summary>
	///     系统字段-删除人
	/// </summary>
	[SugarColumn(ColumnName = "SysDeleteUser")]
    public int SysDeleteUser { get; set; }

	/// <summary>
	///     系统字段-删除时间
	/// </summary>
	[SugarColumn(ColumnName = "SysDeleteTime", IsOnlyIgnoreInsert = true)]
    public DateTime SysDeleteTime { get; set; }

	/// <summary>
	///     系统字段-删除标记
	///     默认值:0
	/// </summary>
	[SugarColumn(ColumnName = "SysIsDelete", DefaultValue = "0")]
    public bool SysIsDelete { get; set; }

	/// <summary>
	/// </summary>
	[SugarColumn(ColumnName = "TaskId")]
    public int TaskId { get; set; }

	/// <summary>
	///     执行状态(10成功，00失败)
	///     默认值:10
	/// </summary>
	[SugarColumn(ColumnName = "Status", DefaultValue = "10")]
    public string Status { get; set; }
}