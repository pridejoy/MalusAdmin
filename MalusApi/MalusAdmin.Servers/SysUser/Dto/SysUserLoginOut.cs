using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalusAdmin.Servers.SysUser.Dto
{
    public class SysUserLoginOut
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Token { get; set; }

    }
}
