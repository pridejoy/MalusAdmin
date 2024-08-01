using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MalusAdmin.Common;
 

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public class ApiResultActionFilter : Attribute, IAsyncActionFilter, IOrderedFilter
{ 
    private readonly IApiResultProvider _resultProvider;
    //筛选器以 属性的 Order 升序数值执行
    internal const int FilterOrder = -2000;
    public int Order { get; set; } = FilterOrder;

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
            actionContext.ExceptionHandled = true;

        }
        else
        {
            var ApiResult = new ApiResult(StatusCodes.Status500InternalServerError, actionContext.Exception.Message, "");
            // 如果是结果异常
            actionContext.Result = _resultProvider.ProcessApiResultException(new ApiResultException(ApiResult));
        }

    }
}
