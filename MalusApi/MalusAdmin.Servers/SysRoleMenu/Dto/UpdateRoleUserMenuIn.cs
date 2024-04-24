using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalusAdmin.Servers.SysRoleMenu.Dto
{
    /// <summary>
    /// 用户菜单更新
    /// </summary>
    public class UpdateRoleUserMenuIn
    {

        public int RoleId { get; set; }


        public List<int> MenuId { get; set; }
    }
}
