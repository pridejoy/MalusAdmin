using MalusAdmin.Common;
using Microsoft.AspNetCore.Mvc;

namespace Wechat.WebApi.Filter;

public class CustomApiResultProvider : ApiResultProvider
{
    public override IActionResult ProcessActionResult(IActionResult actionResult)
    {
        // 都返回 200 状态码
        // 只处理 ObjectResult
        var oldResult = base.ProcessActionResult(actionResult);
        if (oldResult is ObjectResult objectResult)
        {
            // 如果状态码已经是 200，直接返回
            if (objectResult.StatusCode == StatusCodes.Status200OK) return oldResult;

            // 修改状态码
            return new ObjectResult(objectResult.Value) { StatusCode = StatusCodes.Status200OK };
        }

        return actionResult;
    }

    public override IActionResult ProcessApiResultException(ApiResultException resultException)
    {
        // 都返回 200 状态码
        // API 结果 统一处理为 ObjectResult 与 API 控制器保持一致
        var apiResult = resultException.ApiResult;
        IActionResult result = new ObjectResult(apiResult) { StatusCode = StatusCodes.Status200OK };

        return result;
    }
}