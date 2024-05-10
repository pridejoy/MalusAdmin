using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SqlSugar;

namespace MalusAdmin.Common.Components.Token
{
    public class GuidTokenService
    {
        readonly IHttpContextAccessor _HttpContext;

        public GuidTokenService( IHttpContextAccessor httpContext)
        { 
            _HttpContext = httpContext;
        }
    }
}
