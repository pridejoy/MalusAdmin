using System.Reflection;
using MalusAdmin.Common;
using MalusAdmin.Servers.WeatherForecast;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MalusAdmin.WebApi.Controllers
{
    /// <summary>
    /// 测试控制器
    /// </summary>
    public class HomeController : ApiControllerBase
    {
        public IWeatherForecastService _IweatherForecastService;
        public HomeController(IWeatherForecastService IweatherForecastService) 
        { 
            _IweatherForecastService = IweatherForecastService;
        } 
        /// <summary>
        /// 统一返回
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public ApiResult<string> Index()
        {
            return SuccessResult("string");
        }

        /// <summary>
        /// 查询天气情况
        /// </summary>
        /// <returns></returns>
        [HttpPost] 
        public  async Task<ApiResult<IEnumerable<WeatherForecast>>> WeatherForecastGet()
        { 
            var A= await _IweatherForecastService.Get();
            return SuccessResult(A);
        }
        
    }
}
