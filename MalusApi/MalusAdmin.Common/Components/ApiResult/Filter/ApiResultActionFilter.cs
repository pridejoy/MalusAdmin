using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MalusAdmin.Common;
 

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public class ApiResultActionFilter : ResultFilterAttribute
{ 
    private readonly IApiResultProvider _resultProvider;

    public ApiResultActionFilter(IApiResultProvider resultProvider)
    {
        _resultProvider = resultProvider;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var actionContext = await next();

        // 如果已经设置了结果，则直接返回
        if (context.Result != null) return;

        // 如果已有结果，包装成统一返回结果，并返回
        if (actionContext.Result != null)
        {
            actionContext.Result = _resultProvider.ProcessActionResult(actionContext.Result);
            return;
        }

        if (actionContext.Exception is ApiResultException resultException)
        {
            // 如果是结果异常
            actionContext.Result = _resultProvider.ProcessApiResultException(resultException);

            // 标记异常已处理
            actionContext.ExceptionHandled = true;
        }
    }
}
