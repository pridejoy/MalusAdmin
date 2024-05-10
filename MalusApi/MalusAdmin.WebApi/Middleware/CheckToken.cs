using System.Text;
using MalusAdmin.Common.Components.Token;
using MalusAdmin.Entity;
using MalusAdmin.Servers.SysUserButtonPermiss;
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
        private readonly IActionDescriptorCollectionProvider _actionDescriptorCollectionProvider;

        public CheckToken(RequestDelegate next, IActionDescriptorCollectionProvider actionDescriptorCollectionProvider)
        {
            _next = next; 
            _actionDescriptorCollectionProvider = actionDescriptorCollectionProvider;
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
                await _next(context);
            }
            else
            {
                // 动作不允许匿名访问,，权限校验
                ITokenService tokenService = App.GetService<ITokenService>();
             
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
                if (User.UserId>0)
                {
                    //更新静态的用户信息
                    TokenInfo.User= User;    
                    //超管直接跳过校验
                    if (User.UserId==1)
                    {
                        await _next(context);
                        return;
                    }
                }

                // 权限校验
                //if (endpoint is RouteEndpoint routeEndpoint)
                //{
                //    // 获取路由模式
                //    var routePattern = routeEndpoint.RoutePattern.RawText.Replace('/',':');

                //    //权限检查
                //    var rolePermiss = App.GetService<MalusAdmin.Servers.SysRolePermission.ISysRolePermission>();
                //    if (await rolePermiss.HavePermission(routePattern))
                //    {
                //        context.Response.StatusCode = 200;
                //        context.Response.Headers.Add("Content-Type", "application/json; charset=utf-8");
                //        var rspResult = ResultCode.Fail.JsonR("暂无权限");
                //        await context.Response.WriteAsync(rspResult.ToJson());
                //        return;
                //    }
                //}

               
               
            } 
           
        } 
    }
}