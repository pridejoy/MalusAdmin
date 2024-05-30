using MalusAdmin.Common.Model;
using SqlSugar;

namespace MalusAdmin.Entity;

/// <summary>
///     t_sys_login_log:数据库映射类
/// </summary>
[Serializable]
[SugarTable("t_sys_login_log")]
public class TSysLoginLog : ModelBase
{
	/// <summary>
	///     用户ID
	/// </summary>
	[SugarColumn(ColumnName = "UserId")]
    public int UserId { get; set; }

	/// <summary>
	///     IP
	/// </summary>
	[SugarColumn(ColumnName = "IP")]
    public string IP { get; set; }

	/// <summary>
	///     IP的具体信息(归属地等)
	/// </summary>
	[SugarColumn(ColumnName = "IPInfo")]
    public string IPInfo { get; set; }

	/// <summary>
	///     UA
	/// </summary>
	[SugarColumn(ColumnName = "UAStr")]
    public string UAStr { get; set; }

	/// <summary>
	///     浏览器
	/// </summary>
	[SugarColumn(ColumnName = "Browser")]
    public string Browser { get; set; }

	/// <summary>
	///     系统
	/// </summary>
	[SugarColumn(ColumnName = "OS")]
    public string OS { get; set; }

	/// <summary>
	///     设备
	/// </summary>
	[SugarColumn(ColumnName = "Device")]
    public string Device { get; set; }
}