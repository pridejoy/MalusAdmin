using System;
using SqlSugar;

namespace MalusAdmin.Entity 
{
	/// <summary>
	/// t_sys_files:数据库映射类
	/// 
	/// </summary>
	[Serializable]
	[SugarTable("t_sys_files")]
	public class TSysFiles {

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
		///文件名称
		/// </summary>
		[SugarColumn(ColumnName = "Name")]
		public String Name { get; set; }

		/// <summary>
		///保存路径
		/// </summary>
		[SugarColumn(ColumnName = "Path")]
		public String Path { get; set; }

		/// <summary>
		///是否分享
		/// </summary>
		[SugarColumn(ColumnName = "IsShare")]
		public Boolean IsShare { get; set; }

		/// <summary>
		///分享密码
		/// </summary>
		[SugarColumn(ColumnName = "SharePwd")]
		public String SharePwd { get; set; }

    }
}