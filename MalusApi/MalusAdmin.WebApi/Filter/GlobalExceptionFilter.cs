using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using MalusAdmin.Common;
using Microsoft.AspNetCore.Http.HttpResults;

namespace MalusAdmin.WebApi.Filter
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<GlobalExceptionFilter> _logger;
        public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            //异常返回结果包装
            var rspResult = ResultCode.Fail.JsonR(context.Exception.Message);
            ////日志记录
            _logger.LogError(context.Exception, context.Exception.Message);
            context.ExceptionHandled = true;
            context.Result =new ResObjectResult(rspResult);
        }

 
    }
}
