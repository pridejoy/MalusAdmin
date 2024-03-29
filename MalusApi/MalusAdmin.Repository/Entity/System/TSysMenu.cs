using System;
using SqlSugar;

namespace MalusAdmin.Entity {
	/// <summary>
	/// t_sys_menu:数据库映射类
	/// 
	/// </summary>
	[Serializable]
	[SugarTable("t_sys_menu")]
	public class TSysMenu {

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
		///父级ID
		/// </summary>
		[SugarColumn(ColumnName = "ParentId")]
		public Int32 ParentId { get; set; }

		/// <summary>
		///菜单标题
		/// </summary>
		[SugarColumn(ColumnName = "Title")]
		public String Title { get; set; }

		/// <summary>
		///菜单图标
		/// </summary>
		[SugarColumn(ColumnName = "Icon")]
		public String Icon { get; set; }

		/// <summary>
		///路由名称
		/// </summary>
		[SugarColumn(ColumnName = "Name")]
		public String Name { get; set; }

		/// <summary>
		///路由地址
		/// </summary>
		[SugarColumn(ColumnName = "Path")]
		public String Path { get; set; }

		/// <summary>
		///组件路径
		/// </summary>
		[SugarColumn(ColumnName = "Component")]
		public String Component { get; set; }

		/// <summary>
		///是否隐藏
		///默认值:0
		/// </summary>
		[SugarColumn(ColumnName = "IsHide", DefaultValue = "0")]
		public Boolean IsHide { get; set; }

		/// <summary>
		///是否缓存
		///默认值:1
		/// </summary>
		[SugarColumn(ColumnName = "IsKeepAlive", DefaultValue = "1")]
		public Boolean IsKeepAlive { get; set; }

		/// <summary>
		///是否内嵌网址
		///默认值:0
		/// </summary>
		[SugarColumn(ColumnName = "IsIframe", DefaultValue = "0")]
		public Boolean IsIframe { get; set; }

		/// <summary>
		///是否固定(不允许关闭)
		///默认值:0
		/// </summary>
		[SugarColumn(ColumnName = "IsAffix", DefaultValue = "0")]
		public Boolean IsAffix { get; set; }

		/// <summary>
		///是否外部连接(新标签打开)
		///默认值:0
		/// </summary>
		[SugarColumn(ColumnName = "IsLink", DefaultValue = "0")]
		public Boolean IsLink { get; set; }

		/// <summary>
		///重定向地址
		/// </summary>
		[SugarColumn(ColumnName = "Redirect")]
		public String Redirect { get; set; }

		/// <summary>
		///外部或者Iframe网址
		/// </summary>
		[SugarColumn(ColumnName = "Url")]
		public String Url { get; set; }

		/// <summary>
		///菜单类型
		///默认值:Menu
		/// </summary>
		[SugarColumn(ColumnName = "Type", DefaultValue = "Menu")]
		public String Type { get; set; }

		/// <summary>
		///排序
		///默认值:0
		/// </summary>
		[SugarColumn(ColumnName = "Sort", DefaultValue = "0")]
		public Int32 Sort { get; set; }

		/// <summary>
		///访问的api控制器名称
		/// </summary>
		[SugarColumn(ColumnName = "ApiTag")]
		public String ApiTag { get; set; }

		/// <summary>
		///操作权限
		/// </summary>
		[SugarColumn(ColumnName = "Permission")]
		public String Permission { get; set; }

    }
}