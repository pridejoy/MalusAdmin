using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace MalusAdmin.Servers.SysUser.Dto
{
    public class UserPageOut
    {

        /// <summary>
		///登录账号
		/// </summary> 
        public String Account { get; set; }

        /// <summary>
        ///用户名
        /// </summary> 
        public String Name { get; set; }
 
 

        /// <summary>
        ///状态(10正常，00冻结)
        ///默认值:10
        /// </summary> 
        public String Status { get; set; }

        /// <summary>
        ///头像
        /// </summary> 
        public String Avatar { get; set; }

        /// <summary>
        ///电话
        /// </summary> 
        public String Tel { get; set; }

        /// <summary>
        ///邮箱
        /// </summary> 
        public String Email { get; set; }

        /// <summary>
        ///备注
        /// </summary> 
        public String Remark { get; set; }
    }
}
