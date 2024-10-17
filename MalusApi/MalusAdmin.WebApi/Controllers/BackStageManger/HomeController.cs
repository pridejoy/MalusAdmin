using Microsoft.AspNetCore.Authorization;

namespace MalusAdmin.WebApi.Controllers.BackStageManger;

/// <summary>
/// 测试服务
/// </summary>
[AllowAnonymous]
[ApiExplorerSettings(GroupName = "后台管理")]
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
    /// 统一返回
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public string Index()
    {
        return "string";
    }

    /// <summary>
    /// 查询天气情况
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public async Task<dynamic> WeatherForecastGet()
    {
        return await _weatherForecastService.Get();
    }


    /// <summary>
    /// 生成实体测试
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public Task CreatClass(string str)
    {
        return _weatherForecastService.CreatClass(str);
    }

    /// <summary>
    /// 快速生成表
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public Task CreatTable()
    {
        return _weatherForecastService.CreatTable();
    }

    /// <summary>
    /// 获取所有路由信息
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<dynamic> GetAllButton()
    {
        return await _testService.GetAllButton();
    }


    /// <summary>
    /// 获取远程请求的ip
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public string RemoveIp()
    {
        return _httpContextAccessor.HttpContext?.GetRequestIPv4();
    }

    /// <summary>
    /// 获取远程请求的ip
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<dynamic> qwe()
    {
        return await _testService.GetOnlineUser();
    }
}