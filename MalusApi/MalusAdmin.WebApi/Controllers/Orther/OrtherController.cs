using Microsoft.AspNetCore.Authorization;

namespace MalusAdmin.WebApi.Controllers.BusinessManger;

/// <summary>
/// 测试业务
/// </summary>
[AllowAnonymous]
public class OrtherController : ApiControllerBase
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly TestService _testService;
    private readonly IWeatherForecastService _weatherForecastService;

    public OrtherController(IWeatherForecastService weatherForecastService, TestService testService,
        IHttpContextAccessor httpContextAccessor)
    {
        _weatherForecastService = weatherForecastService;
        _testService = testService;
        _httpContextAccessor = httpContextAccessor;
    }

    [HttpGet]
    public async Task<dynamic> GetException207Bad22()
    {
        return await _testService.GetException207Bad();
    }

    [HttpGet]
    public async Task<dynamic> GetException()
    {
        return await _testService.GetException();
    }
}