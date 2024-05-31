using SqlSugar;

namespace MalusAdmin.Entity;

/// <summary>
///     t_sys_task:数据库映射类
/// </summary>
[Serializable]
[SugarTable("t_sys_task")]
public class TSysTask
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
	///     部门ID
	/// </summary>
	[SugarColumn(ColumnName = "DeptId")]
    public int DeptId { get; set; }

	/// <summary>
	///     任务名称
	/// </summary>
	[SugarColumn(ColumnName = "Name")]
    public string Name { get; set; }

	/// <summary>
	///     任务描述
	/// </summary>
	[SugarColumn(ColumnName = "Desc")]
    public string Desc { get; set; }

	/// <summary>
	///     执行的类名
	/// </summary>
	[SugarColumn(ColumnName = "ClassName")]
    public string ClassName { get; set; }

	/// <summary>
	///     执行的参数
	/// </summary>
	[SugarColumn(ColumnName = "Param")]
    public string Param { get; set; }

	/// <summary>
	///     Cron表达式
	/// </summary>
	[SugarColumn(ColumnName = "Cron")]
    public string Cron { get; set; }

	/// <summary>
	///     开始执行时间
	/// </summary>
	[SugarColumn(ColumnName = "StartTime")]
    public DateTime? StartTime { get; set; }

	/// <summary>
	///     结束执行时间
	/// </summary>
	[SugarColumn(ColumnName = "EndTime")]
    public DateTime? EndTime { get; set; }

	/// <summary>
	///     是否启用
	///     默认值:1
	/// </summary>
	[SugarColumn(ColumnName = "Status", DefaultValue = "1")]
    public bool Status { get; set; }
}