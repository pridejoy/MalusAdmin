using System.Diagnostics;
using MalusAdmin.Common.Components.Token;
using MalusAdmin.Models;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Models;
using SqlSugar;
using UAParser;

namespace MalusAdmin.WebApi.Filter;

/// <summary>
/// 禁用请求记录过滤器
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class DisabledRequestRecordAttribute : Attribute
{
}

/// <summary>
/// 请求日志拦截
/// </summary>
public class RequestActionFilter : IAsyncActionFilter, IOrderedFilter
{
    private readonly ISqlSugarClient _db;

    private readonly ITokenService _tokenService;
    private readonly IUserContextService _userContext;
    //private readonly IEventPublisher _publisher;
    //private readonly ICurrentUserService _currentUser; 

    public RequestActionFilter(ISqlSugarClient sqldb, ITokenService tokenService, IUserContextService userContextService)
    {
        _db = sqldb;
        _tokenService = tokenService;
        _userContext = userContextService;
    }

    //筛选器按属性的升序排序 Order 执行 ,具有较低数值 Order 的同步筛选器将在具有较高值的
    //Order筛选器的 after 方法之后执行
    internal const int FilterOrder = -1000;
    public int Order => FilterOrder;

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var isSkipRecord = false;
        var httpContext = context.HttpContext;
        var httpRequest = httpContext.Request;
        var actionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;

        if (actionDescriptor == null || actionDescriptor.EndpointMetadata.OfType<DisabledRequestRecordAttribute>().Any())
        {
            await next();
            return;
        }

        var sw = new Stopwatch();
        sw.Start();
        var actionContext = await next();
        sw.Stop();

        // 获取请求头信息
        var headers = httpRequest.Headers;
        var clientInfo = headers.ContainsKey("User-Agent")
            ? Parser.GetDefault().Parse(headers["User-Agent"])
            : null;

        var userId = _userContext.TokenData?.UserId.ToString() ?? "";
        var userAccount = _userContext.TokenData?.UserAccount ?? "";
        var requestIp = httpContext.GetRequestIPv4();
        var requestUrl = httpRequest.Path;
        var requestMethod = httpRequest.Method;
        var actionName = actionDescriptor.ActionName;
        var controllerName = context.Controller.ToString();
        var userAgent = clientInfo?.UA.Family + clientInfo?.UA.Major;
        var userOs = clientInfo?.OS.Family + clientInfo?.OS.Major;
        var requestParams = context.ActionArguments.Count < 1 ? "" : context.ActionArguments.ToJson();
        var elapsedMilliseconds = sw.ElapsedMilliseconds;
        var operationTime = DateTime.Now;

        var entity = new TSysLogVis
        {
            Name = userId,
            Account = userAccount,
            Success = actionContext.Exception == null,
            Ip = requestIp,
            Location = httpRequest.GetRequestUrlAddress(),
            Browser = userAgent,
            Os = userOs,
            Url = requestUrl,
            ClassName = controllerName,
            MethodName = actionName,
            ReqMethod = requestMethod,
            Param = requestParams,
            ElapsedTime = elapsedMilliseconds,
            OpTime = operationTime,
            Result = actionContext.Exception?.Message ?? (actionContext.Result is FileStreamResult ? null : actionContext.Result.ToJson())
        };

        Console.WriteLine($"处理 {DateTime.Now} : {entity.ToJson()}");

        _db.Insertable(entity).SplitTable().ExecuteReturnSnowflakeId(); 
    }
}