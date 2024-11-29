using MalusAdmin.Common.Helper;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using SqlSugar;

namespace MalusAdmin.WebApi.Filter;
 
public class GlobalExceptionFilter : IAsyncExceptionFilter, IOrderedFilter
{
    private readonly ISqlSugarClient _db;
    private readonly ILogger<GlobalExceptionFilter> _logger;

    public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger, ISqlSugarClient sqldb)
    {
        _logger = logger;
        _db = sqldb;
    }
     
    public async Task OnExceptionAsync(ExceptionContext context)
    {
        try
        {
            var actionMethod = (context.ActionDescriptor as ControllerActionDescriptor)?.MethodInfo;

            var sysLogEx = new TSysLogErr
            {
                ExceptionType = "后台异常",
                ActionName = actionMethod.Name,
                Message = context.Exception.ToJson(),
                LogDateTime = DateTime.Now
            };

            Console.WriteLine($"处理 {DateTime.Now} : {sysLogEx.ToJson()}");

            _db.Insertable(sysLogEx).SplitTable().ExecuteReturnSnowflakeId();
        }
        catch (Exception e)
        {
            //异常进行记录 
            await IOFileHelper.Write("error/", e.ToJson());
        }
        // 设置为true，表示异常已经被处理了
        context.ExceptionHandled = true;
      
        //弹出500异常
        var ApiResult = new ApiResult(StatusCodes.Status500InternalServerError, context.Exception.Message, "");
        // 如果是结果异常
        //IActionResult result = new ObjectResult(ApiResult) { StatusCode = StatusCodes.Status200OK };
        context.Result = new JsonResult(ApiResult);
    }

    /// <summary>
    /// 最先执行
    /// </summary>
    public int Order => int.MinValue;
}