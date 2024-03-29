using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MalusAdmin.Common;
using Microsoft.AspNetCore.Http;

namespace MalusAdmin.Servers
{
    public class BaseServer
    {
        //public readonly ILogService _LogService;
        public readonly ITokenService _TokenService;
        public readonly ICacheService _CacheService;
        public readonly HttpContext _HttpContext;
        public BaseServer( ITokenService tokenService, ICacheService cacheService, HttpContext httpContext)
        {
            //_LogService = logService;
            _TokenService = tokenService;
            _CacheService = cacheService;
            _HttpContext = httpContext;
        }
    }
}
