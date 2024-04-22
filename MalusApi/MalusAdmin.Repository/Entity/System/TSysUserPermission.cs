using System;
using MalusAdmin.Common;
using MalusAdmin.Common.Model;
using SqlSugar;

namespace MalusAdmin.Entity
{
    /// <summary>
    /// t_sys_user_button_permiss:数据库映射类
    /// 
    /// </summary>
    [Serializable]
	[SugarTable("t_sys_role_permiss")]
	public class TSysRolePermission:ModelBase
    {

        /// <summary>
        /// Desc:角色id
        /// Default:
        /// Nullable:False
        /// </summary>           
        public int RoleId { get; set; }

        /// <summary>
        /// Desc:用户访问接口的权限
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string UserPermiss { get; set; }

    }
}