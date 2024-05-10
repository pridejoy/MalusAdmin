using System.Text;
using MalusAdmin.Common.Components.Token;
using MalusAdmin.Entity;
using MalusAdmin.Servers.SysRolePermission;
using MalusAdmin.Servers.SysUserButtonPermiss;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Infrastructure; 
using Microsoft.AspNetCore.Routing.Patterns;
using Microsoft.Extensions.DependencyInjection;


namespace MalusAdmin.WebApi
{
    public class CheckToken
    {
        readonly IServiceScopeFactory _serviceScopeFactory;
        readonly RequestDelegate _next;
        private readonly IActionDescriptorCollectionProvider _actionDescriptorCollectionProvider;

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

            if (endpoint is null) await _next(context);
            // 检查Endpoint的元数据中是否包含AllowAnonymous特性
            var hasAllowAnonymous = endpoint.Metadata
                .OfType<IAllowAnonymous>()
                .Any();

            if (hasAllowAnonymous)
            {
                // 动作允许匿名访问 
             
            }
            else
            {
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    // 动作不允许匿名访问,，权限校验
                    var tokenService = App.GetService<ITokenService>();
                    
                    // 进行身份校验
                    if (!tokenService.CheckToken(context))
                    {
                        context.Response.StatusCode = 401;
                        context.Response.Headers.Add("Content-Type", "application/json; charset=utf-8");
                        var rspResult = ResultCode.Fail.JsonR("登录已过期，请重新登录");
                        await context.Response.WriteAsync(rspResult.ToJson());
                        return;
                    }
                    else
                    {
                        tokenService.RefreshToken(context);
                    }
                     
                    var User = tokenService.ParseToken(context);
                    //更新静态的用户信息
                    TokenInfo.User = User; 
                    
                    // 权限校验  把 User.UserId!=拿掉就所有人进行权限校验
                    if ((endpoint is RouteEndpoint routeEndpoint) && User.UserId != 1)
                    {
                        // 获取路由模式
                        var routePattern = routeEndpoint.RoutePattern.RawText.Replace('/', ':');

                        var rolePermissService = scope.ServiceProvider.GetRequiredService<ISysRolePermission>();

                        // 权限检查  
                        if (await rolePermissService.HavePermission(routePattern))
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
    }
}