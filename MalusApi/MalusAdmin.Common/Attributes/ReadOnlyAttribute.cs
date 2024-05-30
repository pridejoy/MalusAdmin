using Microsoft.AspNetCore.Mvc.Filters;

namespace MalusAdmin.Common;

public class ReadOnlyAttribute : ActionFilterAttribute
{
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