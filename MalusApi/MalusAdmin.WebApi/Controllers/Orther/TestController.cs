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
}