using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MalusAdmin.Repository.Model;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Logging;

namespace MalusAdmin.Common
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;
        private readonly ISqlSugarClient _db;

        public GlobalExceptionMiddleware(RequestDelegate next,
            ILogger<GlobalExceptionMiddleware> logger, ISqlSugarClient db  )
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
                var apiResult = new ApiResult(StatusCodes.Status401Unauthorized, "Unauthorized access", exception.Message);
                // 设置响应的Content-Type为application/json
                context.Response.StatusCode = 401;
                context.Response.ContentType = "application/json";
                return  context.Response.WriteAsync(apiResult.ToJson(true)); 
            }
            else if (exception is ArgumentException)
            {
                var apiResult = new ApiResult(StatusCodes.Status400BadRequest, "Bad request", exception.Message);
                // 设置响应的Content-Type为application/json
                context.Response.StatusCode = 400;
                context.Response.ContentType = "application/json";
                return context.Response.WriteAsync(apiResult.ToJson(true)); 
            }
            else
            { 
                var apiResult = new ApiResult(StatusCodes.Status500InternalServerError, "Internal Server Error", exception.Message);
                // 设置响应的Content-Type为application/json
                context.Response.StatusCode = 200;
                context.Response.ContentType = "application/json";
                return context.Response.WriteAsync(apiResult.ToJson(true)); 
            }
        }

    }
}
