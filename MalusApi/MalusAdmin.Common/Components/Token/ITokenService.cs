using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MalusAdmin.Common
{
    public interface ITokenService
    {
        /// <summary>
        /// 获取当前登录的用户信息
        /// </summary>
     

        /// <summary>
        /// 生成并保存token
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        string GenerateToken(HttpContext httpContext, TokenData tokenData);

        /// <summary>
        /// 校验token
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        bool CheckToken(HttpContext httpContext);

        /// <summary>
        /// 删除保存的token
        /// </summary>
        /// <param name="httpContext"></param>
        void RemoveToken(HttpContext httpContext);

        /// <summary>
        /// 解析token
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        TokenData ParseToken(HttpContext httpContext);

        /// <summary>
        /// 刷新token
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="tokenData"></param>
        /// <returns></returns>
        string RefreshToken(HttpContext httpContext);

        void  AddCheckToken(string token, TokenData tokeninfo);

        /// <summary>
        /// 删除需要验证的Token
        /// </summary>
        /// <param name="userId"></param>
        void RemoveCheckToken(int userId);


        TokenData ParseTokenByCaChe(string token);


    }
}
