using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Routing.Patterns;


namespace MalusAdmin.WebApi
{
    public class CheckToken
    {
        readonly RequestDelegate _next;
        readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly IActionDescriptorCollectionProvider _actionDescriptorCollectionProvider;

        public CheckToken(RequestDelegate next, IServiceScopeFactory serviceScopeFactory, IActionDescriptorCollectionProvider actionDescriptorCollectionProvider)
        {
            _next = next;
            _serviceScopeFactory = serviceScopeFactory;
            _actionDescriptorCollectionProvider = actionDescriptorCollectionProvider;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            //Tode 自动获取allow的特性的接口
            var endpoint = context.GetEndpoint();
            if (endpoint != null)
            {
                var routePattern = (endpoint as RouteEndpoint)?.RoutePattern?.RawText;
                if (routePattern != null)
                {
                    var actionDescriptor = GetActionDescriptor(routePattern);
                    if (actionDescriptor != null)
                    {
                        var allowAnonymousAttribute = actionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().FirstOrDefault();
                        if (allowAnonymousAttribute != null)
                        {
                            // 输出带有 [AllowAnonymous] 特性的接口路由信息
                            Console.WriteLine($"[AllowAnonymous] found in route: {routePattern}");
                        }
                        else
                        {
                            using (IServiceScope serviceScope = _serviceScopeFactory.CreateScope())
                            {
                                ITokenService tokenService = App.GetService<ITokenService>();
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
                            }
                        }
                    }
                }
            }

      
            await _next(context);



        }




        private ControllerActionDescriptor GetActionDescriptor(string routePattern)
        {
            var actionDescriptors = _actionDescriptorCollectionProvider.ActionDescriptors.Items;
            foreach (var actionDescriptor in actionDescriptors)
            {
                var actionRoutePattern = (actionDescriptor.EndpointMetadata.FirstOrDefault(meta => meta is RoutePattern) as RoutePattern)?.RawText;
                if (actionRoutePattern != null && actionRoutePattern.Equals(routePattern))
                {
                    return actionDescriptor as ControllerActionDescriptor;
                }
            }
            return null;
        }
    }
}