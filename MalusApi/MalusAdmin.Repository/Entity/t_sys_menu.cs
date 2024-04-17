using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Models
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("t_sys_menu")]
    public partial class t_sys_menu
    {
           public t_sys_menu(){


           }
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public int Id {get;set;}

           /// <summary>
           /// Desc:父级菜单ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int ParentId {get;set;}

           /// <summary>
           /// Desc:菜单类型1 .目录 2.菜单
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int MenuType {get;set;}

           /// <summary>
           /// Desc:菜单名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? MenuName {get;set;}

           /// <summary>
           /// Desc:路由名称
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string RouteName {get;set;}

           /// <summary>
           /// Desc:路由路径
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string RoutePath {get;set;}

           /// <summary>
           /// Desc:菜单状态
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? Status {get;set;}

           /// <summary>
           /// Desc:隐藏菜单
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public bool HideInMenu {get;set;}

           /// <summary>
           /// Desc:排序
           /// Default:0
           /// Nullable:True
           /// </summary>           
           public int? Sort {get;set;}

           /// <summary>
           /// Desc:页面组件
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string Component {get;set;}

           /// <summary>
           /// Desc:图标
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public string Icon {get;set;}

           /// <summary>
           /// Desc:图标类型
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public bool IconType {get;set;}

           /// <summary>
           /// Desc:
           /// Default:1
           /// Nullable:True
           /// </summary>           
           public bool? KeepAlive {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? Redirect {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? Href {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? SysCreateUser {get;set;}

           /// <summary>
           /// Desc:
           /// Default:DateTime.Now
           /// Nullable:False
           /// </summary>           
           public DateTime SysCreateTime {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? SysUpdateUser {get;set;}

           /// <summary>
           /// Desc:
           /// Default:DateTime.Now
           /// Nullable:False
           /// </summary>           
           public DateTime SysUpdateTime {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? SysDeleteUser {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? SysDeleteTime {get;set;}

           /// <summary>
           /// Desc:
           /// Default:0
           /// Nullable:True
           /// </summary>           
           public bool? SysIsDelete {get;set;}

    }
}
