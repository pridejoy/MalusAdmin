using Microsoft.AspNetCore.Authorization;

namespace MalusAdmin.Common;

[ApiController]
[Route("api/[controller]/[action]")]
[Produces("application/json")] //返回数据的格式 直接约定为Json
//[Authorize] //接口全部需要登录,特殊的除外
[Authorize(AuthenticationSchemes = "CustomScheme")]
public class ApiControllerBase : ControllerBase
{
     
}