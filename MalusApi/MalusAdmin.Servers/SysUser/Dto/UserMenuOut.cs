using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalusAdmin.Servers.SysUser.Dto
{
    public class UserMenuOut
    {
        /// <summary>
        /// 名字
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 路由路径
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// 组件
        /// </summary>
        public string Component { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Meta Meta { get; set; }

        public List<UserMenuOut> Children { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Meta
    {
        public string Title { get; set; }

        public string Icon { get; set; }

        public int Sort { get; set; }

    }
}
