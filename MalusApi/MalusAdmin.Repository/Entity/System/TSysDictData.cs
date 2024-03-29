using System;
using SqlSugar;

namespace MalusAdmin.Entity {
	/// <summary>
	/// t_sys_dic_data:数据库映射类
	/// 
	/// </summary>
	[Serializable]
	[SugarTable("t_sys_dict_data")]
	public class TSysDictData {

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
		///类型ID
		/// </summary>
		[SugarColumn(ColumnName = "TypeId")]
		public Int32 TypeId { get; set; }

		/// <summary>
		///字典名称
		/// </summary>
		[SugarColumn(ColumnName = "Name")]
		public String Name { get; set; }

		/// <summary>
		///字典值1
		/// </summary>
		[SugarColumn(ColumnName = "Value1")]
		public String Value1 { get; set; }

		/// <summary>
		///字典值2
		/// </summary>
		[SugarColumn(ColumnName = "Value2")]
		public String Value2 { get; set; }

		/// <summary>
		///字典值3
		/// </summary>
		[SugarColumn(ColumnName = "Value3")]
		public String Value3 { get; set; }

		/// <summary>
		///是否启用
		///默认值:1
		/// </summary>
		[SugarColumn(ColumnName = "Status", DefaultValue = "1")]
		public Boolean Status { get; set; }

		/// <summary>
		///顺序
		///默认值:0
		/// </summary>
		[SugarColumn(ColumnName = "Sort", DefaultValue = "0")]
		public Int32 Sort { get; set; }

    }
}