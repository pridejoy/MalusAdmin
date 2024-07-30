using MalusAdmin.Common.Components.Token;
using MalusAdmin.Servers;
using MalusAdmin.Servers.SysRolePermission;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace MalusAdmin.WebApi;

public class CheckToken
{
    private readonly IActionDescriptorCollectionProvider _actionDescriptorCollectionProvider;
    private readonly RequestDelegate _next;
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public CheckToken(RequestDelegate next,
        IServiceScopeFactory serviceScopeFactory,
        IActionDescriptorCollectionProvider actionDescriptorCollectionProvider)
    {
        _next = next;
        _actionDescriptorCollectionProvider = actionDescriptorCollectionProvider;
        _serviceScopeFactory = serviceScopeFactory;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // 获取当前请求的Endpoint
        var endpoint = context.GetEndpoint();

        if (endpoint is null)
        {
            await _next(context);
            return;
        }

        ;
        // 检查Endpoint的元数据中是否包含AllowAnonymous特性
        var hasAllowAnonymous = endpoint.Metadata
            .OfType<IAllowAnonymous>()
            .Any();

        var tokenService = App.GetService<ITokenService>();
        if (hasAllowAnonymous)
        {
            // 动作允许匿名访问 
            await _next(context);
            return;
        }

        var hasHub = endpoint.DisplayName.Contains("hub");

        if (hasHub)
        {
            var token = context.Request.Query["token"];
            var User = tokenService.ParseTokenByCaChe(token);
            if (User is null||User.UserId<=0) await Res401Async(context);
        }
        else
        {
            using(var scope = _serviceScopeFactory.CreateScope())
            {
                // 进行身份校验
                if (!tokenService.CheckToken(context)) await Res401Async(context); 
                //刷新用户的token过期时间
                tokenService.RefreshToken(context);

                var User = tokenService.ParseToken(context);
                if (User is null) await Res401Async(context);
                // 权限校验  把 User.UserId!=拿掉就所有人进行权限校验
                if (endpoint is RouteEndpoint routeEndpoint && !User.IsSuperAdmin)
                {
                    // 获取路由模式
                    //.Split("{")[0] 处理路由 api:SysUser:Delete:{id}
                    var routePattern = routeEndpoint.RoutePattern.RawText?.Replace('/', ':').Split("{")[0];

                    var rolePermissService = scope.ServiceProvider.GetRequiredService<ISysRolePermission>();

                    var hapermissableAllowAnonymous = endpoint?.Metadata
                        .OfType<PermissionAttribute>()
                        .Any() ?? true;
                    if (hapermissableAllowAnonymous)
                    {
                        // 权限检查  
                        if (!await rolePermissService.HavePermission(routePattern))
                        {
                            await Res403Async(context);
                        } 
                    }

                }
            }
        }

        await _next(context);
    }

    /// <summary>
    /// 登录后返回401
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public async Task Res401Async(HttpContext context)
    {
        throw ResultHelper.Exception401Unauthorized("提供的令牌无效或已过期,请重新登录"); 
    }

    /// <summary>
    /// 登录后返回暂无权限
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public async Task Res403Async(HttpContext context)
    {
        throw ResultHelper.Exception403Forbidden();
    }
}