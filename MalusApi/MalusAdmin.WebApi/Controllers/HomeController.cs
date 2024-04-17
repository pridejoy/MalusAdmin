using System.Reflection;
using MalusAdmin.Common;
using MalusAdmin.Servers.WeatherForecast;
using MalusAdmin.WebApi;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MalusAdmin.WebApi.Controllers
{
    /// <summary>
    /// 测试服务
    /// </summary>
    [AllowAnonymous]
    public class HomeController : ApiControllerBase
    {
        public IWeatherForecastService _IweatherForecastService;
        public TestService testService;
        public HomeController(IWeatherForecastService IweatherForecastService, TestService testService)
        {
            _IweatherForecastService = IweatherForecastService;
            this.testService = testService;
        }
        /// <summary>
        /// 统一返回
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonR Index()
        {
            return ResultCode.Success.JsonR("string");
        }

        /// <summary>
        /// 查询天气情况
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonR> WeatherForecastGet()
        {
            return ResultCode.Success.JsonR(await _IweatherForecastService.Get());
        }


        /// <summary>
        ///生成实体测试
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonR CreatClass(string str)
        {
            return ResultCode.Success.JsonR(_IweatherForecastService.CreatClass(str));
        }

        /// <summary>
        /// 获取所有路由信息
        /// </summary>
        /// <returns></returns>
        [HttpGet] 
        public JsonR GetAllButen() 
        {
            return ResultCode.Success.JsonR(testService.GetAllButen()); 
        }
    }
}
