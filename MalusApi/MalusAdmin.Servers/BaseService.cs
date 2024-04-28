using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MalusAdmin.Common;
using Microsoft.AspNetCore.Http;

namespace MalusAdmin.Servers
{
    public class BaseService: IBaseService
    {
        public readonly ITokenService _TokenService; 
        public readonly IHttpContextAccessor  _HttpContext;
        public BaseService(
            ITokenService tokenService, IHttpContextAccessor httpContext)
        {
            _TokenService = tokenService; 
            _HttpContext = httpContext;
        }

        /// <summary>
        /// 获取登录用户的Token数据
        /// </summary>
        public TokenData TokenDataInfo
        {
            get
            {
                return _TokenService.ParseToken(_HttpContext.HttpContext) ?? new TokenData();
            }
        }
    }
}
