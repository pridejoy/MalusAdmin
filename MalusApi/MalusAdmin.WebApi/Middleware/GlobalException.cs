using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MalusAdmin.Repository.Model;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Logging;
using SqlSugar;

namespace MalusAdmin.Common
{
    public class GlobalException
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalException> _logger;
        private readonly ISqlSugarClient _db;

        public GlobalException(RequestDelegate next,
            ILogger<GlobalException> logger, ISqlSugarClient db  )
        {
            _db = db;
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context); // 调用下一个中间件
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception: {ex.Message}, Path: {context.Request.Path}, Trace: {ex.StackTrace}");
 
                await HandleExceptionAsync(context, ex); // 处理异常
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            if (exception is UnauthorizedAccessException)
            {
                var ApiJson = new ApiJson(ApiCode.没有登录状态, "Unauthorized access", exception.Message);
                // 设置响应的Content-Type为application/json
                context.Response.StatusCode = 401;
                context.Response.ContentType = "application/json";
                return  context.Response.WriteAsync(ApiJson.ToJson(true)); 
            }
            else if (exception is ApiJsonException)
            {
                ApiJson apiJson = ((ApiJsonException)exception).apiJson;
                // 设置响应的Content-Type为application/json
                context.Response.StatusCode = 200;
                context.Response.ContentType = "application/json";
                return context.Response.WriteAsync(apiJson.ToJson(true));
            }
            else
            { 
                var ApiJson = new ApiJson(ApiCode.服务器错误, "", exception.Message);
                // 设置响应的Content-Type为application/json
                context.Response.StatusCode = 200;
                context.Response.ContentType = "application/json";
                return context.Response.WriteAsync(ApiJson.ToJson(true)); 
            }
        }

    }
}
