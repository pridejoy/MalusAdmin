using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

public static class BaseServiceRegister
{
    //注册项目所需的服务
    public static IServiceCollection AddBaseServices(this IServiceCollection services)
    { 
        //HttpContext
        services.AddHttpContextAccessor();
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        return services;
    }
}
