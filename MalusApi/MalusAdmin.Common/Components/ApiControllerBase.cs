using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MalusAdmin.Common.Components;
using MalusAdmin.Common.Components.Token;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MalusAdmin.Common
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Produces("application/json")] //返回数据的格式 直接约定为Json
    [Authorize] //接口全部需要登录,特殊的除外
    public class ApiControllerBase :  ControllerBase
    { 
    }
}
