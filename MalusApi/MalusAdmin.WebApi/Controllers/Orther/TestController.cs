using MalusAdmin.Servers;
using Microsoft.AspNetCore.Authorization;

namespace MalusAdmin.WebApi.Controllers.Orther;

/// <summary>
/// 测试业务
/// </summary>
[AllowAnonymous]
public class TestController : ApiControllerBase
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly TestService _testService;
    private readonly IWeatherForecastService _weatherForecastService;

    public TestController(IWeatherForecastService weatherForecastService, TestService testService,
        IHttpContextAccessor httpContextAccessor)
    {
        _weatherForecastService = weatherForecastService;
        _testService = testService;
        _httpContextAccessor = httpContextAccessor;
    }

    [HttpGet]
    public async Task<dynamic> GetException207BadBad()
    {
        return await _testService.GetException207BadBad();
    }

    [HttpGet]
    public async Task<dynamic> GetException()
    {
        return await _testService.GetException();
    }


    [HttpGet]
    public async Task<string> GetAppConfig()
    {
        return  App.Configuration["IsDemo"]?.ToString();
    }

    /// <summary>
    /// 动态api
    /// </summary>
    /// <returns></returns>
    //public async Task<dynamic> PostException2()
    //{
    //    return await _testService.GetException();
    //}


    /// <summary>
    /// 动态api
    /// </summary>
    /// <returns></returns>
    //public async Task<dynamic> GetException3()
    //{
    //    return await _testService.GetException();
    //}
}