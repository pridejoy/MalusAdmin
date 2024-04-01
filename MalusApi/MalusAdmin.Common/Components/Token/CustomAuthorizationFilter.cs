using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace MalusAdmin.Common.Components.Token
{
    // 自定义认证方案
    public class CustomAuthorizationFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // 从请求Header中获取Token
            string token = context.HttpContext.Request.Headers["Token"];

            // 验证Token是否有效
            if (token != "Bearer 9b8c68537655428698e4f54eba3b4f8d")
            {
                // 如果Token无效，返回401 Unauthorized
                context.Result = new UnauthorizedResult();
            }
        }
    }
}
