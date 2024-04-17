using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MalusAdmin.Entity;

namespace MalusAdmin.Servers.SysMenu
{
    public class SysMenuPageOut: TSysMenu
    {
        /// <summary>
        /// 子菜单
        /// </summary>
        public List<TSysMenu> children {  get; set; }
    }
}
