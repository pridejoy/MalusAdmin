using System.Configuration;
using MalusAdmin.Common.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MalusAdmin.Common;

public static class Configure
{
    public static IServiceCollection AddConfigureSetup(this IServiceCollection services, IConfiguration config)
    {
        //强类型的注册
        //https://www.dotnetshare.com/guid/conf-options/options.html
        //services.Configure<PositionOptions>(config.GetSection(PositionOptions.Position));

        //services.Configure<RabbitMQConfig>(config.GetSection("RabbitMQConfig"));
        services.Configure<JwtOptions>(config.GetSection("Jwt"));


        //等其他选项
        return services;
    }

    //配置读取的方式

    //方式1
    //var connection = App.Configuration["Redis:ConnectionString"]?.ToString();
    //if (connection == null) throw new NullReferenceException("配置读取失败");

    //读取数组
    //App.Configuration.GetSection("AllowCors").Get<string[]>()


    //强类型读取
    //var jwtSection = App.Configuration.GetSection("Jwt");
    //var jwtConfiguration = jwtSection.Get<JwtOptions>();

}