using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalusAdmin.Servers
{
    public class ResetPassWord
    {
        /// <summary>
        /// 登录账号
        /// </summary> 
        [Required]
        public string? NewPassWord { get; set; }


        /// <summary>
        /// 旧密码密码
        /// </summary> 
        [Required]
        public string? OldPassWord { get; set; }
    }
}
