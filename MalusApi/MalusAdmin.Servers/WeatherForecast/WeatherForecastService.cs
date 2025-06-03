using MalusAdmin.Common.Components;
using MalusAdmin.Common.Components.Swagger;
using Simple.DynamicWebApi.Abstractions;

namespace MalusAdmin.Servers;

/// <summary>
/// 测试服务
/// </summary>
[ApiExplorerSettings(GroupName =nameof(ApiVersionGropInfo.Default))]
public class WeatherForecastService : ApiControllerBase
{
    private static readonly string[] Summaries =
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ISqlSugarClient _db;
    private readonly IHttpContextAccessor _httpContext;

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
            .Where(x => x.StartsWith(values))
            .CreateClassFile("D:\\PrideJoy\\MalusAdmin\\MalusApi\\MalusAdmin.Repository\\Entity");
    }

    /// <summary>
    /// 生成数据库表
    /// </summary>
    /// <returns></returns>
    public async Task CreatTable()
    {
        _db.CodeFirst.SetStringDefaultLength(200).InitTables(typeof(TSysOnlineUser));
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