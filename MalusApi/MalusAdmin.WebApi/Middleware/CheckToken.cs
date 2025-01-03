using System.Text.RegularExpressions;
using MalusAdmin.Common;
using MalusAdmin.Repository.Model;
using MalusAdmin.Servers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Server.Kestrel.Core.Features;
using Microsoft.Extensions.DependencyInjection;

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
        //UseRouting中间件负责将请求路由到对应的端点。
        //任何在UseRouting之前执行的中间件，如果尝试调用context.GetEndpoint()，很可能返回null，
        //因为在那个时刻路由匹配还没有发生
        var endpoint = context.GetEndpoint();
        // 定义不需要认证的资源路径
        var allowedPaths = new[]
        {
            "/hub"
        };

        // 检查请求路径是否在允许列表中或者是否允许匿名访问
        if (allowedPaths.Contains(context.Request.Path.ToString()) || IsAllowAnonymous(endpoint))
        {
            await _next(context);
            return;
        }

        // 获取并验证令牌
        var tokenService = App.GetService<ITokenService>();
        var token = await tokenService.GetHeadersToken();
        var isValidToken = await tokenService.ValidateToken(token);

        if (!isValidToken)
        {
            throw new UnauthorizedAccessException("提供的令牌无效或已过期，请重新登录");
        }

        // 刷新用户的令牌过期时间
        await tokenService.RefreshTokenAsync(token);

        // 解析令牌获取用户信息
        var sysuser = await tokenService.ParseTokenAsync(token);
        if (sysuser == null)
        {
            throw new UnauthorizedAccessException("提供的令牌无效或已过期，请重新登录");
        }

        // 权限校验
        if (endpoint is RouteEndpoint routeEndpoint && !sysuser.IsSuperAdmin)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            { 
                //var hasPermissionAttribute = routeEndpoint.Metadata.OfType<PermissionAttribute>().Any();
                //if (hasPermissionAttribute)
                {
                    // 获取路由模式并处理，例如：api:SysUser:Delete:{id}
                    var routePattern = routeEndpoint.RoutePattern.RawText.Replace('/', ':');
                    // 处理最后一个冒号后面的数字，并将其替换为空字符串
                    routePattern = Regex.Replace(routePattern, @":\d+$", "");

                    var rolePermissionService = scope.ServiceProvider.GetRequiredService<ISysRolePermission>();
                    // 检查用户是否有权限
                    if (!await rolePermissionService.HasPermissionAsync(routePattern))
                    { 
                        throw  ApiException.Exception(ApiCode.缺少权限);
                        return;
                    }
                }
            }
        }


        await _next(context);
    }


    private bool IsAllowAnonymous(Endpoint endpoint)
    {
        return endpoint?.Metadata.OfType<IAllowAnonymous>().Any() ?? false;
    }

 
}