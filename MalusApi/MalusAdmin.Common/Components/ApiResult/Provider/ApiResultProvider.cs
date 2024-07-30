using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalusAdmin.Common;

    public class ApiResultProvider : IApiResultProvider
{
    public virtual IActionResult ProcessActionResult(IActionResult actionResult)
    {
        // 只处理 ObjectResult
        if (actionResult is ObjectResult objectResult)
        {
            // 已经是统一返回结果，直接返回
            if (objectResult.Value is ApiResult)
            {
                return actionResult;
            }

            // 其他情况，包装成 API 统一返回结果
            int statusCode = objectResult.StatusCode ?? StatusCodes.Status200OK;
            string message = ApiResultHelper.GetMessage(statusCode);
            bool isSuccess = ApiResultHelper.GetSuccess(statusCode);
            var apiResult = ApiResultHelper.Result(statusCode, message, objectResult.Value);
            var newResult = new ObjectResult(apiResult);
            return newResult;
        }

        return actionResult;
    }

    public virtual IActionResult ProcessApiResultException(ApiResultException resultException)
    {
        // API 结果 统一处理为 ObjectResult 与 API 控制器保持一致
        var apiResult = resultException.ApiResult;
        IActionResult result = new ObjectResult(apiResult) { StatusCode = apiResult.Code };

        return result;
    }
}