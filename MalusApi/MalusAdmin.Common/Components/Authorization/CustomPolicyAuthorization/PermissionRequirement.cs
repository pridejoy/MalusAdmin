using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace MalusAdmin.Common.Components.Authorization
{
    //创建授权要求和处理程序
    public class PermissionRequirement : IAuthorizationRequirement
    {
    }

    public class PermissionHandler : AuthorizationHandler<PermissionRequirement>
    {
        private readonly IHttpContextAccessor _accessor;
        public PermissionHandler(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            //if (context.User == null || context.User?.Identity?.IsAuthenticated == false)
            //{
            //    context.Fail();
            //}
            //else
            //{
            //    var role = context.User.Claims.Where(i => i.Type == ClaimTypes.Role).FirstOrDefault();
            //    if (role != null && role.Value == "admin")
            //    {
            //        context.Succeed(requirement);
            //    }
            //    else
            //    {
            //        context.Fail();
            //    }
            //}
            await Task.CompletedTask;
        }
    }
}
