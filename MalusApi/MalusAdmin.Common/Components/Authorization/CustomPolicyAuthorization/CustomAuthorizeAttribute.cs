using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MalusAdmin.Common.Components
{
    public class CustomAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string _role;

        public CustomAuthorizeAttribute(string role)
        {
            _role = role;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;

            //if (!user.Identity.IsAuthenticated)
            //{
            //    context.Result = new StatusCodeResult(401); // 未认证
            //    return;
            //}

            //if (!user.IsInRole(_role))
            //{
            //    context.Result = new StatusCodeResult(403); // 无权限
            //    return;
            //}
        }
    }
}
