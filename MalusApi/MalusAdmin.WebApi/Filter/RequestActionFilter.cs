using System.Diagnostics;
using MalusAdmin.Common.Components.Token;
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

    internal const int FilterOrder = -8000;
    public int Order => FilterOrder;

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var isSkipRecord = false;
        var httpContext = context.HttpContext;
        var httpRequest = httpContext.Request;

        var sw = new Stopwatch();
        sw.Start();
        var actionContext = await next();
        sw.Stop();

        var actionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;


        // 判断是否需要跳过
        //if (!AppSettings.RecordRequest.IsEnabled) isSkipRecord = true;
        if (actionDescriptor == null) isSkipRecord = true;
        //if (AppSettings.RecordRequest.IsSkipGetMethod && request.Method.ToUpper() == "GET") isSkipRecord = true;

        foreach (var metadata in actionDescriptor!.EndpointMetadata)
            if (metadata is DisabledRequestRecordAttribute)
                isSkipRecord = true;

        // 进入管道的下一个过滤器，并跳过剩下动作
        if (isSkipRecord)
        {
            await next();
            return;
        }

        //判断是否请求成功（没有异常就是请求成功） 
        var headers = httpRequest.Headers;
        var clientInfo = headers.ContainsKey("User-Agent")
            ? Parser.GetDefault().Parse(headers["User-Agent"])
            : null;


        var entity = new TSysLogVis
        {
            Name = _userContext.TokenData?.UserId.ToString() ?? "",
            Account = _userContext.TokenData?.UserAccount ?? "",
            Success = true,
            Ip = httpContext.GetRequestIPv4(),
            Location = httpRequest.GetRequestUrlAddress(),
            Browser = clientInfo?.UA.Family + clientInfo?.UA.Major,
            Os = clientInfo?.OS.Family + clientInfo?.OS.Major,
            Url = httpRequest.Path,
            ClassName = context.Controller.ToString(),
            MethodName = actionDescriptor?.ActionName,
            ReqMethod = httpRequest.Method,
            Param = context.ActionArguments.Count < 1 ? "" : context.ActionArguments.ToJson(),
            // Result = JSON.Serialize(actionContext.Result), // 序列化异常，比如验证码
            ElapsedTime = sw.ElapsedMilliseconds,
            OpTime = DateTime.Now
        };

        // 检查是否有异常发生
        if (actionContext.Exception != null)
        {
            // 设置错误信息
            entity.Result = actionContext.Exception.Message;
        }
        else
        {
            // 检查 ActionResult 类型
            var result = actionContext.Result;

            if (result.GetType() != typeof(FileStreamResult))
                entity.Result = actionContext.Result.ToJson(); // 序列化异常，比如验证码
        }

        Console.WriteLine($"处理 {DateTime.Now} : {JsonConvert.SerializeObject(entity)}");

        _db.Insertable(entity).SplitTable().ExecuteReturnSnowflakeId();

        //发送到队列或者直接添加到数据库
        //await _eventPublisher.PublishAsync(new ChannelEventSource("Create:OpLog", ));
    }
}