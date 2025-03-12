using SqlSugar.Extensions;

namespace Wechat.Servers;

[ApiController]
[Route("api/[controller]/[action]")]
[Produces("application/json")] //返回数据的格式 直接约定为Json
[Authorize] //接口全部需要登录,特殊的除外
[ApiExplorerSettings(GroupName = "小程序")]

public class WxApiControllerBase : ControllerBase
{
    public int UserId => HttpContext?.User.FindFirst("UserId")?.Value.ObjToInt() ?? 0;
    public string OpenID => HttpContext?.User.FindFirst("OpenID")?.Value ?? "";
}