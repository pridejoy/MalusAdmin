using MalusAdmin.Common.Model;
using SqlSugar;

namespace MalusAdmin.Entity;

/// <summary>
///     t_sys_user:数据库映射类
/// </summary>
[Serializable]
[SugarTable("t_sys_user")]
public class TSysUser : ModelBase
{
	/// <summary>
	///     主键
	/// </summary>
	[SugarColumn(ColumnName = "Id", IsPrimaryKey = true, IsIdentity = true)]
    public int Id { get; set; }

	/// <summary>
	///     登录账号
	/// </summary>
	[SugarColumn(ColumnName = "Account")]
    public string Account { get; set; }

	/// <summary>
	///     用户名
	/// </summary>
	[SugarColumn(ColumnName = "Name")]
    public string Name { get; set; }

	/// <summary>
	///     密码
	/// </summary>
	[SugarColumn(ColumnName = "PassWord")]
    public string PassWord { get; set; }

	/// <summary>
	///     角色ID
	/// </summary>
	[SugarColumn(ColumnDescription = "角色IDs", IsJson = true)]
    public List<int> UserRolesId { get; set; }

	/// <summary>
	///     状态(10正常，00冻结)
	///     默认值:10
	/// </summary>
	[SugarColumn(ColumnName = "Status", DefaultValue = "10")]
    public int Status { get; set; }

	/// <summary>
	///     头像
	/// </summary>
	[SugarColumn(ColumnName = "Avatar")]
    public string Avatar { get; set; }

	/// <summary>
	///     电话
	/// </summary>
	[SugarColumn(ColumnName = "Tel")]
    public string Tel { get; set; }

	/// <summary>
	///     邮箱
	/// </summary>
	[SugarColumn(ColumnName = "Email")]
    public string Email { get; set; }

	/// <summary>
	///     备注
	/// </summary>
	[SugarColumn(ColumnName = "Remark")]
    public string Remark { get; set; }

	/// <summary>
	///     是否是超级管理员
	/// </summary>
	public bool IsSuperAdmin { get; set; }
}