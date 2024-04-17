using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalusAdmin.Servers.SysUserButtonPermiss.Dto
{
    public class AllButtonPermissOut
    {
         
        /// <summary>
        /// 权限id，也就是路由的名称
        /// </summary>
        public string PermissionId { get; set; }

        /// <summary>
        /// 权限名称
        /// </summary>
        public string PermissionName {  get; set; }
    }
}
