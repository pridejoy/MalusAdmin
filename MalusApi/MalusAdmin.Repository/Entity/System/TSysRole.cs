using System;
using SqlSugar;

namespace MalusAdmin.Entity {
	/// <summary>
	/// t_sys_role:数据库映射类
	/// 
	/// </summary>
	[Serializable]
	[SugarTable("t_sys_role")]
	public class TSysRole {

		/// <summary>
		///主键
		/// </summary>
		[SugarColumn(ColumnName = "Id", IsPrimaryKey = true, IsIdentity = true)]
		public Int32 Id { get; set; }
		 

		/// <summary>
		///角色名称
		/// </summary>
		[SugarColumn(ColumnName = "Name")]
		public String Name { get; set; }
        /// <summary>
        ///描述
        /// </summary>
        [SugarColumn(ColumnName = "Desc")]
		public String Desc { get; set; }

		/// <summary>
		///是否启用
		///默认值:1
		/// </summary> 
		public int Status { get; set; }

		/// <summary>
		///数据范围(字典数据DataRang)
		/// </summary>
		[SugarColumn(ColumnName = "DataRang")]
		public String DataRang { get; set; }

		/// <summary>
		///数据权限(当范围为自定义时选择的部门)
		/// </summary>
		[SugarColumn(ColumnName = "Permission")]
		public String Permission { get; set; }


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

    }
}