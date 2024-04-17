using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MalusAdmin.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using SqlSugar;

namespace MalusAdmin.Servers.WeatherForecast
{
    public class WeatherForecastService: IWeatherForecastService
    {

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private readonly ISqlSugarClient _db;
        readonly IHttpContextAccessor _httpContext;

        public WeatherForecastService(ISqlSugarClient db)
        { 
        
          _db = db;
        }

        /// <summary>
        /// 生成实体
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task CreatClass(string values)
        {
            _db.DbFirst.IsCreateAttribute().StringNullable()
                .Where(x=>x.StartsWith(values))
                .CreateClassFile("D:\\PrideJoy\\MalusAdmin\\MalusApi\\MalusAdmin.Repository\\Entity", "Models");
        }

        /// <summary>
        /// 测试
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            var MyList = Enumerable.Range(1, 2).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToArray();

            return MyList;
        }
    }
}
