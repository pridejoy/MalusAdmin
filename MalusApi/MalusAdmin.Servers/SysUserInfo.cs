using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MalusAdmin.Common;
using Microsoft.AspNetCore.Http;

namespace MalusAdmin.Servers
{
    public  class SysUserInfo
    {
        public readonly ITokenService _TokenService;
        public readonly ICacheService _CacheService;
        public readonly HttpContext _HttpContext;
        public SysUserInfo( ITokenService tokenService, ICacheService cacheService, HttpContext httpContext)
        { 
            _TokenService = tokenService;
            _CacheService = cacheService;
            _HttpContext = httpContext;
        }
        /// <summary>
        /// 获取登录用户的Token数据
        /// </summary>
        public TokenData Token
        {
            get
            {
                return _TokenService.ParseToken(_HttpContext) ?? new TokenData();
            }
        }  
    }
}
