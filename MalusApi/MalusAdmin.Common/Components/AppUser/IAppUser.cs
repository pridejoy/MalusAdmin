using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MalusAdmin.Common;

/// <summary>
/// 当前用户
/// </summary>
public interface IAppUser
{
    /// <summary>
    /// 当前登录用户ID
    /// </summary>
    TokenData Info { get; }
      

    /// <summary>
    /// 请求携带的Token
    /// </summary>
    /// <returns></returns>
    string HeaderToken { get; }

    /// <summary>
    /// 是否已认证
    /// </summary>
    /// <returns></returns>
    bool IsAuthenticated { get; }
}
