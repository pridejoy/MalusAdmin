using System;
using SqlSugar;

namespace MalusAdmin.Entity {
	/// <summary>
	/// t_sys_login_log:数据库映射类
	/// 
	/// </summary>
	[Serializable]
	[SugarTable("t_sys_login_log")]
	public class TSysLoginLog {

		/// <summary>
		///主键
		/// </summary>
		[SugarColumn(ColumnName = "Id", IsPrimaryKey = true, IsIdentity = true)]
		public Int32 Id { get; set; }

		/// <summary>
		///系统字段-创建人
		/// </summary>
		[SugarColumn(ColumnName = "SysCreateUser")]
		public Int32 SysCreateUser { get; set; }

		/// <summary>
		///系统字段-创建时间
		///默认值:CURRENT_TIMESTAMP
		/// </summary>
		[SugarColumn(ColumnName = "SysCreateTime", IsOnlyIgnoreInsert = true)]
		public DateTime SysCreateTime { get; set; }

		/// <summary>
		///系统字段-修改人
		/// </summary>
		[SugarColumn(ColumnName = "SysUpdateUser")]
		public Int32 SysUpdateUser { get; set; }

		/// <summary>
		///系统字段-修改时间
		///默认值:CURRENT_TIMESTAMP
		/// </summary>
		[SugarColumn(ColumnName = "SysUpdateTime", IsOnlyIgnoreInsert = true)]
		public DateTime SysUpdateTime { get; set; }

		/// <summary>
		///系统字段-删除人
		/// </summary>
		[SugarColumn(ColumnName = "SysDeleteUser")]
		public Int32 SysDeleteUser { get; set; }

		/// <summary>
		///系统字段-删除时间
		/// </summary>
		[SugarColumn(ColumnName = "SysDeleteTime", IsOnlyIgnoreInsert = true)]
		public DateTime SysDeleteTime { get; set; }

		/// <summary>
		///系统字段-删除标记
		///默认值:0
		/// </summary>
		[SugarColumn(ColumnName = "SysIsDelete", DefaultValue = "0")]
		public Boolean SysIsDelete { get; set; }

		/// <summary>
		///部门ID
		/// </summary>
		[SugarColumn(ColumnName = "DeptId")]
		public Int32 DeptId { get; set; }

		/// <summary>
		///用户ID
		/// </summary>
		[SugarColumn(ColumnName = "UserId")]
		public Int32 UserId { get; set; }

		/// <summary>
		///IP
		/// </summary>
		[SugarColumn(ColumnName = "IP")]
		public String IP { get; set; }

		/// <summary>
		///IP的具体信息(归属地等)
		/// </summary>
		[SugarColumn(ColumnName = "IPInfo")]
		public String IPInfo { get; set; }

		/// <summary>
		///UA
		/// </summary>
		[SugarColumn(ColumnName = "UAStr")]
		public String UAStr { get; set; }

		/// <summary>
		///浏览器
		/// </summary>
		[SugarColumn(ColumnName = "Browser")]
		public String Browser { get; set; }

		/// <summary>
		///系统
		/// </summary>
		[SugarColumn(ColumnName = "OS")]
		public String OS { get; set; }

		/// <summary>
		///设备
		/// </summary>
		[SugarColumn(ColumnName = "Device")]
		public String Device { get; set; }

    }
}