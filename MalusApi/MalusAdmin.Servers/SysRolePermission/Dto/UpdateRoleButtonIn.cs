using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalusAdmin.Servers.SysRolePermission.Dto
{
    public class UpdateRoleButtonIn
    {
        /// <summary>
        /// 角色的id
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// 用户的角色按钮权限
        /// </summary>
        public List<string> PermissionId {  get; set; }
    }
}
