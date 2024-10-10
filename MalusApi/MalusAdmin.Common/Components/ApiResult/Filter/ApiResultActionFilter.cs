using Microsoft.AspNetCore.Mvc.Filters;

namespace MalusAdmin.Common;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public class ApiResultActionFilter : Attribute, IAsyncActionFilter, IOrderedFilter
{
    //筛选器以 属性的 Order 升序数值执行
    internal const int FilterOrder = -2000;
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
            actionContext.ExceptionHandled = true;
        }
        else
        {
            var ApiResult = new ApiResult(StatusCodes.Status500InternalServerError, actionContext.Exception.Message,
                "");
            // 如果是结果异常
            actionContext.Result = _resultProvider.ProcessApiResultException(new ApiResultException(ApiResult));
        }
    }

    public int Order { get; set; } = FilterOrder;
}