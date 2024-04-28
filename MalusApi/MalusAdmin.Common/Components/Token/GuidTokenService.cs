using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SqlSugar;

namespace MalusAdmin.Common
{
    public class GuidTokenService : ITokenService
    {
        readonly ICacheService _cacheService;
        public GuidTokenService(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }
        static string tokenTag = "Token";
        static int expiresTime = 60;
        static string checkKey = "CheckToken_";

        private string GetToken(HttpContext httpContext)
        {
            if (httpContext == null) throw new SystemException("参数错误");
            return httpContext.Request.Headers[tokenTag].ToString().Replace("Bearer ","");
        }

        public bool CheckToken(HttpContext httpContext)
        {
            string token = GetToken(httpContext);
            if (string.IsNullOrWhiteSpace(token))
            {
                return false;
            }
            TokenData tokenData = _cacheService.Get<TokenData>(token);
            if (tokenData == null)
            {
                return false;
            }
            if (_cacheService.Exists(checkKey + tokenData.UserId))
            {
                return false;
            }
            return true;
        }
        public string GenerateToken(HttpContext httpContext, TokenData tokenData)
        {
            string token = Guid.NewGuid().ToString("N");
            _cacheService.Add(token, tokenData, new TimeSpan(0, expiresTime, 0));
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
            return _cacheService.Get<TokenData>(token);
        }
        public string RefreshToken(HttpContext httpContext)
        {
            string token = GetToken(httpContext);
            TokenData tokenData = ParseToken(httpContext);
            if (tokenData != null)
            {
                _cacheService.Add(token, tokenData, new TimeSpan(0, expiresTime, 0));
            }
            return token;
        }
        public void AddCheckToken(int userId)
        {
            _cacheService.Add(checkKey + userId, 0, new TimeSpan(0, expiresTime * 2, 0));
        }
        public void RemoveCheckToken(int userId)
        {
            _cacheService.Remove(checkKey + userId);
        }
    }
}
