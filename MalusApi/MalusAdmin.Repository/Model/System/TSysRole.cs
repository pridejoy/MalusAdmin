using SqlSugar;

namespace MalusAdmin.Repository.Model;

/// <summary>
/// t_sys_role:数据库映射类
/// </summary>
[Serializable]
[SugarTable("t_sys_role")]
public class TSysRole : ModelBase
{
	/// <summary>
	/// 主键
	/// </summary>
	[SugarColumn(ColumnName = "Id", IsPrimaryKey = true, IsIdentity = true)]
    public int Id { get; set; }


	/// <summary>
	/// 角色名称
	/// </summary>
	[SugarColumn(ColumnName = "Name")]
    public string Name { get; set; }

	/// <summary>
	/// 描述
	/// </summary>
	[SugarColumn(ColumnName = "Desc")]
    public string Desc { get; set; }

	/// <summary>
	/// 是否启用
	/// 默认值:1
	/// </summary>
	public int Status { get; set; }

}