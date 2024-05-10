using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalusAdmin.Common.Components.Token
{
    /// <summary>
    /// 当前用户登录的信息
    /// </summary>
    public static class TokenInfo
    {
        public static TokenData?  User { get; set; } = new TokenData();
    }
}
