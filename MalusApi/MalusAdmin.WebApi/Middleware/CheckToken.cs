using MalusAdmin.Common.Components.Token;
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
            if (User.UserId <= 0) await Res401Async(context);
        }
        else
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                // 进行身份校验
                if (!tokenService.CheckToken(context))
                    await Res401Async(context);
                else
                    tokenService.RefreshToken(context);

                var User = tokenService.ParseToken(context);
                if (User == null) await Res401Async(context);
                if (User.ExpireTime < DateTime.Now) await Res401Async(context);
                //更新静态的用户信息
                TokenInfo.User = User;

                // 权限校验  把 User.UserId!=拿掉就所有人进行权限校验
                if (endpoint is RouteEndpoint routeEndpoint && !User.IsSuperAdmin)
                {
                    // 获取路由模式
                    var routePattern = routeEndpoint.RoutePattern.RawText?.Replace('/', ':');

                    var rolePermissService = scope.ServiceProvider.GetRequiredService<ISysRolePermission>();

                    var hapermissableAllowAnonymous = endpoint?.Metadata
                        .OfType<PermissionAttribute>()
                        .Any() ?? true;
                    if (hapermissableAllowAnonymous)
                        // 权限检查  
                        if (!await rolePermissService.HavePermission(routePattern))
                        {
                            context.Response.StatusCode = 200;
                            context.Response.Headers.Add("Content-Type", "application/json; charset=utf-8");
                            var rspResult = ResultCode.Fail.JsonR("暂无权限");
                            await context.Response.WriteAsync(rspResult.ToJson());
                            return;
                        }
                }
            }
        }

        await _next(context);
    }

    /// <summary>
    ///     登录后返回401
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public async Task Res401Async(HttpContext context)
    {
        context.Response.StatusCode = 401;
        context.Response.Headers.Add("Content-Type", "application/json; charset=utf-8");
        var rspResult = ResultCode.Fail.JsonR("登录已过期，请重新登录");
        await context.Response.WriteAsync(rspResult.ToJson());
    }
}