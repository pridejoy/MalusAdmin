using System;
using SqlSugar;

namespace MalusAdmin.Entity {
	/// <summary>
	/// t_sys_user:数据库映射类
	/// 
	/// </summary>
	[Serializable]
	[SugarTable("t_sys_user")]
	public class TSysUser {

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
		///登录账号
		/// </summary>
		[SugarColumn(ColumnName = "Account")]
		public String Account { get; set; }

		/// <summary>
		///用户名
		/// </summary>
		[SugarColumn(ColumnName = "Name")]
		public String Name { get; set; }

		/// <summary>
		///密码
		/// </summary>
		[SugarColumn(ColumnName = "PassWord")]
		public String PassWord { get; set; }

		/// <summary>
		///角色ID
		/// </summary>
		[SugarColumn(ColumnName = "RoleId")]
		public Int32 RoleId { get; set; }

		/// <summary>
		///状态(10正常，00冻结)
		///默认值:10
		/// </summary>
		[SugarColumn(ColumnName = "Status", DefaultValue = "10")]
		public int Status { get; set; }

		/// <summary>
		///头像
		/// </summary>
		[SugarColumn(ColumnName = "Avatar")]
		public String Avatar { get; set; }

		/// <summary>
		///电话
		/// </summary>
		[SugarColumn(ColumnName = "Tel")]
		public String Tel { get; set; }

		/// <summary>
		///邮箱
		/// </summary>
		[SugarColumn(ColumnName = "Email")]
		public String Email { get; set; }

		/// <summary>
		///备注
		/// </summary>
		[SugarColumn(ColumnName = "Remark")]
		public String Remark { get; set; }

    }
}