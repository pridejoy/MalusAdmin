using MalusAdmin.Servers;
using Microsoft.AspNetCore.Authorization;

namespace MalusAdmin.WebApi.Controllers.BusinessManger
{
    /// <summary>
    /// 测试业务
    /// </summary>
    [AllowAnonymous]
    [ApiExplorerSettings(GroupName = "业务管理")]
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

        /// <summary>
        /// 统一返回
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public  async Task<dynamic> Index()
        {
            return await  _testService.GetFriendlyException();
        }
    }
}