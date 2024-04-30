using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using NetTaste;
using StackExchange.Redis;
using static Dm.net.buffer.ByteArrayBuffer;

namespace MalusAdmin.Common
{
    public class ReadOnlyAttribute : ActionFilterAttribute
    {

        public ReadOnlyAttribute()
        {
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (AppSettings.IsDemo)
            {

                context.HttpContext.Response.StatusCode = 200;
                var rspResult = ResultCode.Fail.JsonR("演示环境,禁止操作");
                context.Result = new ResObjectResult(rspResult);

                base.OnActionExecuting(context);

            }

        }
    }
}
