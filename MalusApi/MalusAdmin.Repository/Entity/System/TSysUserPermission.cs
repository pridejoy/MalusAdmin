using System;
using SqlSugar;

namespace MalusAdmin.Entity
{
    /// <summary>
    /// t_sys_user_button_permiss:数据库映射类
    /// 
    /// </summary>
    [Serializable]
	[SugarTable("t_sys_user_button_permiss")]
	public class TSysUserPermission:ModelBase
    {

        /// <summary>
        /// Desc:用户id
        /// Default:
        /// Nullable:False
        /// </summary>           
        public int UserId { get; set; }

        /// <summary>
        /// Desc:用户访问接口的权限
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string UserPermiss { get; set; }

    }
}