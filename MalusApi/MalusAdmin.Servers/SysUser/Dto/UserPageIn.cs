using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace MalusAdmin.Servers.SysUser.Dto
{
    public class UserPageIn : PageParamBase
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
        ///密码
        /// </summary> 
        public String PassWord { get; set; }

        /// <summary>
        ///角色ID
        /// </summary> 
        public Int32 RoleId { get; set; }

        /// <summary>
        ///状态(1正常，0冻结)
        ///默认值:10
        /// </summary> 
        public int? Status { get; set; }

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
