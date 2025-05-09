using MalusAdmin.Common;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class CorsServiceCollectionExtensions
{
    /// <summary>
    /// 添加默认跨域配置
    /// </summary>
    /// <param name="services"></param>
    /// <param name="setupAction"></param>
    /// <returns></returns>
    public static IServiceCollection AddCorsSetup(this IServiceCollection services,  Action<CorsOptions>? setupAction = null)
    {
        //教程
        //https://www.dotnetshare.com/guid/cors.html
        services.AddCors(options =>
        {
            options.AddDefaultPolicy(policy =>
            {
                var allowCors = App.Configuration.GetSection("AllowCors").Get<string[]>();

                if (allowCors.Any(c => c == "*"))
                    // 允许任意跨域
                    policy.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                else
                    // 允许指定域名
                    policy.WithOrigins(allowCors);
            });
        });

        // 自定义配置
        if (setupAction != null) services.Configure(setupAction);

        return services;
    }
}