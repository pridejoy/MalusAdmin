using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalusAdmin.Servers
{
    public class SysUserLoginIn
    {
        /// <summary>
        ///登录账号
        /// </summary>
        /// <example>admin</example>
        public String? Account { get; set; }


        /// <summary>
        ///密码
        /// </summary>
        /// <example>123456</example>
        public String? PassWord { get; set; }
    }
}
