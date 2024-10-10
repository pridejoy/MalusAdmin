using MalusAdmin.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wechat.Servers;

namespace Wechat.WebApi.Controllers;

/// <summary>
///     测试服务
/// </summary>
[AllowAnonymous]
public class HomeController : WxApiControllerBase
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public HomeController(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    /// <summary>
    ///     统一返回
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public string Index()
    {
        return "string";
    }


    /// <summary>
    ///     获取远程请求的ip
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Authorize]
    public string RemoveIp()
    {
        return _httpContextAccessor.HttpContext?.GetRequestIPv4() ?? "暂无";
    }

    /// <summary>
    ///     统一返回
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Authorize]
    public string Insss()
    {
        return HttpContext?.User.FindFirst("asd").Value;
    }


    [HttpPost("gettoken")]
    public string Inx()
    {
        var DIC = new Dictionary<string, string>();
        DIC.Add("asd", "123");
        return JwtHelper.Create(DIC);
    }
}