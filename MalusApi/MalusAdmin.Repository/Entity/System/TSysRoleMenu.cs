using System;
using System.Linq;
using System.Text;
using MalusAdmin.Common;
using MalusAdmin.Common.Model;
using MalusAdmin.Entity;
using SqlSugar;

namespace Models
{
    ///<summary>
    ///角色菜单表
    ///</summary>
    [SugarTable("t_sys_role_menu")]
    public  class TSysRoleMenu : ModelBase
    {

        /// <summary>
        ///角色ID
        /// </summary>
        [SugarColumn(ColumnName = "RoleId")]
        public Int32 RoleId { get; set; }

        /// <summary>
        ///菜单ID
        /// </summary>
        [SugarColumn(ColumnName = "MenuId")]
        public int MenuId { get; set; }
    }
}
