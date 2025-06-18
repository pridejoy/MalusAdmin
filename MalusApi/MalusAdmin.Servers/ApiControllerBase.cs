using Microsoft.AspNetCore.Authorization;
using Simple.DynamicWebApi;
namespace MalusAdmin.Common;


[Route("api/[controller]/[action]")] 
//[Authorize] //接口全部需要登录,特殊的除外
[Authorize(AuthenticationSchemes = "CustomScheme")]
public class ApiControllerBase : IDynamicWebApi //继承动态接口
{

}