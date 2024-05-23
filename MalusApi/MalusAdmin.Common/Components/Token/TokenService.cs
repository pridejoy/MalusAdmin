using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MalusAdmin.Common.Components.Token;
using Microsoft.AspNetCore.Http;
using SqlSugar;

namespace MalusAdmin.Common
{
    public class TokenService : ITokenService
    {
        readonly ICacheService _cacheService; 

        readonly IHttpContextAccessor _HttpContext;
    
        public TokenService(ICacheService cacheService,IHttpContextAccessor httpContext)
        {
            _cacheService = cacheService;
            _HttpContext = httpContext;
        }


        static string tokenTag = "Token";

        /// <summary>
        /// 30分钟内无操作
        /// </summary>
        static int expiresTime = 30; 

        //public TokenData TokenDataInfo => ;

        
        /// <summary>
        /// 获取heard的token
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        /// <exception cref="SystemException"></exception>
        private string GetToken(HttpContext httpContext)
        {
            if (httpContext == null) throw new SystemException("参数错误");
            if (httpContext.Request.Headers.ContainsKey(tokenTag))
            {
                return httpContext.Request.Headers[tokenTag].ToString().Replace("Bearer ", "");
            }
            return "";
        }

        /// <summary>
        /// 检查登录的Token
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public bool CheckToken(HttpContext httpContext)
        {
            string token = GetToken(httpContext);
            if (string.IsNullOrWhiteSpace(token))
            {
                return false;
            }

            TokenData tokenData = ParseTokenByCaChe(token);
            if (tokenData == null)
            {
                return false;
            } 
            //此处可增加逻辑，限制单个账号只允许登录一个
       
            return true;
        }

        /// <summary>
        /// 生成一个toekn，并缓存
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="tokenData"></param>
        /// <returns></returns>
        public string GenerateToken(HttpContext httpContext, TokenData tokenData)
        {
            string token = Guid.NewGuid().ToString("N");
            AddCheckToken(token,tokenData); 
            return token;
        }

        public void RemoveToken(HttpContext httpContext)
        {
            string token = GetToken(httpContext);
            _cacheService.Remove(token);
        }

        public TokenData ParseToken(HttpContext httpContext)
        {
            string token = GetToken(httpContext);
            if (string.IsNullOrEmpty(token)) return new TokenData(); 
            return ParseTokenByCaChe(token);
        }

        /// <summary>
        /// 刷新Token 
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public string RefreshToken(HttpContext httpContext)
        {
            string token = GetToken(httpContext);
            TokenData tokenData = ParseToken(httpContext);
            if (tokenData != null)
            {
                tokenData.ExpireTime = DateTime.Now.AddMinutes(expiresTime);
                _cacheService.Add(Constant.Cache.UserToken + token, tokenData, new TimeSpan(1, 0, 0));
            }
            return token;
        }

        /// <summary>
        /// 添加登录的缓存
        /// </summary>
        /// <param name="userId"></param>
        public void AddCheckToken(string token,TokenData tokeninfo)
        {
            tokeninfo.LoginTime = DateTime.Now;
            tokeninfo.ExpireTime= DateTime.Now.AddMinutes(expiresTime);
            _cacheService.Add(Constant.Cache.UserToken  + token,  tokeninfo, new TimeSpan(1, 0, 0));
        }

        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <param name="userId"></param>
        public void RemoveCheckToken(int userId)
        {
            _cacheService.Remove(Constant.Cache.UserToken  + userId);
        }

        /// <summary>
        /// 通过缓存解析Token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public TokenData ParseTokenByCaChe(string token)
        {
            return _cacheService.Get<TokenData>(Constant.Cache.UserToken + token) ?? new TokenData(); ;
        }

    }
}
