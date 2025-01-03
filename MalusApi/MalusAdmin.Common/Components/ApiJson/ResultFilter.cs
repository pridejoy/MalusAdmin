using System.Net;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MalusAdmin.Common;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public class ResultFilter : Attribute, IResultFilter
{
    public void OnResultExecuting(ResultExecutingContext context)
    {
        var json = context.Result as ObjectResult;

        if (json != null)
        {
            var result = ApiCode.成功.RJson(json.Value);
            context.Result = new OkObjectResult(result); // 使用OkObjectResult来包装result对象
        }
        //else
        //{
        //    // 处理json为null的情况
        //}

    }

    public void OnResultExecuted(ResultExecutedContext context)
    {
        //返回结果之后
    }

}