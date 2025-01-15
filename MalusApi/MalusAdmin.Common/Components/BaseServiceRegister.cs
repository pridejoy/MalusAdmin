using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MalusAdmin.Common;
using MalusAdmin.Common.Components;
using Microsoft.Extensions.DependencyInjection;

public static class BaseServiceRegister
{
    //注册项目所需的服务
    public static IServiceCollection AddBaseServices(this IServiceCollection services)
    {
        //打印控制台显示
        services.AddLogo();

        //配置url小写
        //services.AddRouting(o => { o.LowercaseUrls = true; });

        //HttpContext
        services.AddHttpContextAccessor();
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
         
        services.AddTransient<IAppUser,AppUser>();

        switch (AppSettings.AuthenMethod)
        {
            case AuthenMethodStatus.Jwt:
                services.AddSingleton<ITokenService, JwtToken>();
                break;
            default:
                services.AddSingleton<ITokenService, GuidToken>();
                break;
        }
       


        return services;
    }
}
