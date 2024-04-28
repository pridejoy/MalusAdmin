using System;
using MalusAdmin.Common.Model;
using SqlSugar;

namespace MalusAdmin.Entity {
	/// <summary>
	/// t_sys_login_log:数据库映射类
	/// 
	/// </summary>
	[Serializable]
	[SugarTable("t_sys_login_log")]
	public class TSysLoginLog: ModelBase
    {

		 

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