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

        services.Configure<RabbitMQConfig>(config.GetSection("RabbitMQConfig"));

        //等其他选项
        return services;
    }
}