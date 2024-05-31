using Microsoft.AspNetCore.Authorization;

namespace MalusAdmin.WebApi.Controllers;

/// <summary>
///     测试服务
/// </summary>
[AllowAnonymous]
public class HomeController : ApiControllerBase
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly TestService _testService;
    private readonly IWeatherForecastService _weatherForecastService;

    public HomeController(IWeatherForecastService weatherForecastService, TestService testService,
        IHttpContextAccessor httpContextAccessor)
    {
        _weatherForecastService = weatherForecastService;
        _testService = testService;
        _httpContextAccessor = httpContextAccessor;
    }

    /// <summary>
    ///     统一返回
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public JsonR Index()
    {
        return ResultCode.Success.JsonR("string");
    }

    /// <summary>
    ///     查询天气情况
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public async Task<JsonR> WeatherForecastGet()
    {
        return ResultCode.Success.JsonR(await _weatherForecastService.Get());
    }


    /// <summary>
    ///     生成实体测试
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public JsonR CreatClass(string str)
    {
        return ResultCode.Success.JsonR(_weatherForecastService.CreatClass(str));
    }

    /// <summary>
    ///     快速生成表
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public JsonR CreatTable()
    {
        return ResultCode.Success.JsonR(_weatherForecastService.CreatTable());
    }

    /// <summary>
    ///     获取所有路由信息
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public JsonR GetAllButton()
    {
        return ResultCode.Success.JsonR(_testService.GetAllButton());
    }


    /// <summary>
    ///     获取远程请求的ip
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public JsonR RemoveIp()
    {
        return ResultCode.Success.JsonR(_httpContextAccessor.HttpContext?.GetRequestIPv4() ?? "暂无");
    }

    /// <summary>
    ///     获取远程请求的ip
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public JsonR qwe()
    {
        return ResultCode.Success.JsonR(_testService.GetOnlineUser());
    }
    
    [HttpGet]
    public  JsonR InsterTable()
    {
        return ResultCode.Success.JsonR( _testService.InsterTable().Result);
    }
}