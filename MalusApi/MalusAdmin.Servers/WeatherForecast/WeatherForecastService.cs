using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MalusAdmin.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace MalusAdmin.Servers.WeatherForecast
{
    public class WeatherForecastService: IWeatherForecastService
    {

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
         
        readonly IHttpContextAccessor _httpContext; 


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
