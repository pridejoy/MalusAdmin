using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalusAdmin.Servers.SysMenu
{
    public class MenuAddandUpIn
    {
        /// <summary>
        /// Desc:父级菜单ID
        /// Default:
        /// Nullable:False
        /// </summary>           
        public int ParentId { get; set; }

        /// <summary>
        /// Desc:菜单类型1 .目录 2.菜单
        /// Default:
        /// Nullable:False
        /// </summary>           
        public int MenuType { get; set; }

        /// <summary>
        /// Desc:菜单名称
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string? MenuName { get; set; }

        /// <summary>
        /// Desc:路由名称
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string RouteName { get; set; }

        /// <summary>
        /// Desc:路由路径
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string RoutePath { get; set; }

        /// <summary>
        /// Desc:菜单状态
        /// Default:
        /// Nullable:True
        /// </summary>           
        public int? Status { get; set; }

        /// <summary>
        /// Desc:隐藏菜单
        /// Default:0
        /// Nullable:False
        /// </summary>           
        public bool HideInMenu { get; set; }

        /// <summary>
        /// Desc:排序
        /// Default:0
        /// Nullable:True
        /// </summary>           
        public int? Sort { get; set; }

        /// <summary>
        /// Desc:页面组件
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string Component { get; set; }

        /// <summary>
        /// Desc:图标
        /// Default:0
        /// Nullable:False
        /// </summary>           
        public string Icon { get; set; }

        /// <summary>
        /// Desc:图标类型
        /// Default:0
        /// Nullable:False
        /// </summary>           
        public bool IconType { get; set; }

        /// <summary>
        /// Desc:
        /// Default:1
        /// Nullable:True
        /// </summary>           
        public bool? KeepAlive { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string? Redirect { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string? Href { get; set; }
    }
}
