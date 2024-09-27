using System.ComponentModel;
using System.Reflection;
using MalusAdmin.Common;
using MalusAdmin.Common.Helper;
using MalusAdmin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using SqlSugar;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MalusAdmin.WebApi.Filter;

public class GlobalExceptionFilter : IExceptionFilter,IOrderedFilter
{
    private readonly ILogger<GlobalExceptionFilter> _logger;
    private readonly ISqlSugarClient _db;
    public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger, ISqlSugarClient sqldb)
    {
        _logger = logger;
        _db = sqldb;
    }

    /// <summary>
    /// 最先执行
    /// </summary>
    public int Order => int.MinValue;

    public async void OnException(ExceptionContext context)
    {   
        try
        {
            var actionMethod = (context.ActionDescriptor as ControllerActionDescriptor)?.MethodInfo;

            var sysLogEx = new TSysLogErr
            {
                ExceptionType = "后台异常",
                ActionName = actionMethod.Name,
                Message = context.Exception.ToJson(),
                LogDateTime = DateTime.Now,
            }; 

            Console.WriteLine($"处理 {DateTime.Now} : {sysLogEx.ToJson()}");

             _db.Insertable(sysLogEx).SplitTable().ExecuteReturnSnowflakeId();
        }
        catch (Exception e)
        {
            //异常进行记录 
            await IOFileHelper.Write("error/", e.ToJson());
             
        }

        //弹出500异常
        var ApiResult = new ApiResult(StatusCodes.Status500InternalServerError, context.Exception.Message, "");
        // 如果是结果异常
        IActionResult result = new ObjectResult(ApiResult) { StatusCode = StatusCodes.Status200OK };
        context.Result = result;
    }
}