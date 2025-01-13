using MalusAdmin.Common.Components;
using MalusAdmin.Common.Components.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace MalusAdmin.Common;

public static class AuthorizationSetup
{
    public static IServiceCollection AddAuthorizationSetup(this IServiceCollection services)
    {
        // 启动Jwt授权
        services.AddJwtSetup();

        #region 自定义策略授权
        services.AddAuthorization(options =>
        {
            options.AddPolicy("PermissionPolicy", policyBuilder =>
            {
                policyBuilder.Requirements.Add(new PermissionRequirement());
            });
        });

        services.AddSingleton<IAuthorizationHandler, RoleHandler>();
        //// 注入默认的权限检查器
        services.AddSingleton<IAuthorizationMiddlewareResultHandler, CustomAuthorizationMiddlewareResultHandler>();

        #endregion
         

        return services;
    }
}