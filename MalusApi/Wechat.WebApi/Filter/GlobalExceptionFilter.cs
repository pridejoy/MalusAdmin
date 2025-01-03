using MalusAdmin.Common;
using MalusAdmin.Common.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class GlobalExceptionFilter : IExceptionFilter, IOrderedFilter
{
    private readonly ILogger<GlobalExceptionFilter> _logger;

    public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger)
    {
        _logger = logger;
    }

    public async void OnException(ExceptionContext context)
    {
        //日志记录
        _logger.LogError(context.Exception, context.Exception.Message);
        //异常进行记录 
        await IOFileHelper.Write("error/", context.Exception.ToJson());

        var ApiJson = new ApiJson(ApiCode.服务器错误, context.Exception.Message, "");
        // 如果是结果异常
        IActionResult result = new ObjectResult(ApiJson) { StatusCode = StatusCodes.Status200OK };
        context.Result = result;
    }

    /// <summary>
    /// 最先执行
    /// </summary>
    public int Order => int.MinValue;
}