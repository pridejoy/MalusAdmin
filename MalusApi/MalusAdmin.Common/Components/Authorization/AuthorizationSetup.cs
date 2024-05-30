using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace MalusAdmin.Common;

public static class AuthorizationSetup
{
    public static IServiceCollection AddAuthorizationSetup(this IServiceCollection services)
    {
        //添加授权
        services.AddAuthorization();

        // 注入自定义的授权策略提供程序
        services.AddTransient<IAuthorizationPolicyProvider, SimpleAuthorizationPolicyProvider>();

        // 注入自定义的授权处理程序
        services.AddTransient<IAuthorizationHandler, SimpleAuthorizationHandler>();

        // 注入默认的权限检查器
        services.AddTransient<IPermissionChecker, DefaultPermissionChecker>();


        return services;
    }
}