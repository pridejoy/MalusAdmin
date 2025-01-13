using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Authorization;

namespace MalusAdmin.Common.Components.Authorization
{
    public class CustomAuthorizationMiddlewareResultHandler : IAuthorizationMiddlewareResultHandler
    {
        private readonly AuthorizationMiddlewareResultHandler _defaultHandler = new AuthorizationMiddlewareResultHandler();

        public async Task HandleAsync(RequestDelegate next, HttpContext context, AuthorizationPolicy policy, PolicyAuthorizationResult authorizeResult)
        {
            //if (authorizeResult.Forbidden)
            //{
            //    context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            //    context.Response.ContentType = "application/json";
            //    await context.Response.WriteAsync("{\"data\":{\"succeeded\":false,\"code\":403,\"message\":\"您没有权限操作\"}}");
            //    return;
            //}

            //if (authorizeResult.Challenged)
            //{
            //    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            //    context.Response.ContentType = "application/json";
            //    await context.Response.WriteAsync("{\"data\":{\"succeeded\":false,\"code\":401,\"message\":\"登录已过期，请重新登录\"}}");
            //    return;
            //}

            await _defaultHandler.HandleAsync(next, context, policy, authorizeResult);
        }
    }
}
