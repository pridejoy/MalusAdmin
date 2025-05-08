using MalusAdmin.Common.Components;
using MalusAdmin.Servers;
using Microsoft.AspNetCore.Authorization;

namespace MalusAdmin.WebApi.Controllers.BusinessManger;

/// <summary>
/// 其他
/// </summary>
[AllowAnonymous]
public class OrtherController : ApiControllerBase
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly TestService _testService;
    private readonly IWeatherForecastService _weatherForecastService;
    private readonly MQPublish _mQPublish;

    public OrtherController(IWeatherForecastService weatherForecastService, TestService testService,
        IHttpContextAccessor httpContextAccessor, MQPublish mQPublish)
    {
        _weatherForecastService = weatherForecastService;
        _testService = testService;
        _httpContextAccessor = httpContextAccessor;
        _mQPublish = mQPublish;
    }



    [HttpGet("GetEnvironmentn")]
    public async Task<string> GetEnvironmentn()
    { 
        //await _mQPublish.PublishMessageAsync("Test",name);
        return App.WebHostEnvironment.ToString();
    }

    [HttpGet]
    public async Task<dynamic> GetException207BadBad22()
    {
        return await _testService.GetException207BadBad();
    }

    [HttpGet]
    public async Task<dynamic> GetException()
    {
        return await _testService.GetException();
    }
}