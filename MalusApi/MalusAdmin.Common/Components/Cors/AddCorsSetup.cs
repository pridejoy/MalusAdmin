using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using MalusAdmin.Common;

public static class CorsServiceCollectionExtensions
{
    /// <summary>
    /// 添加默认跨域配置
    /// </summary>
    /// <param name="services"></param>
    /// <param name="setupAction"></param>
    /// <returns></returns>
    public static IServiceCollection AddCorsSetup(this IServiceCollection services, Action<CorsOptions>? setupAction = null)
    {
        //教程
        //https://www.dotnetshare.com/guid/cors.html
        services.AddCors(options =>
        {
            options.AddDefaultPolicy(policy =>
            {
                if (AppSettings.AllowCors.Any(c => c == "*"))
                {
                    // 允许任意跨域
                    policy.AllowAnyOrigin();
                }
                else
                {
                    // 允许指定域名
                    policy.WithOrigins(AppSettings.AllowCors);
                }
            });
        });

        // 自定义配置
        if (setupAction != null)
        {
            services.Configure<CorsOptions>(setupAction);
        }

        return services;
    }
}
