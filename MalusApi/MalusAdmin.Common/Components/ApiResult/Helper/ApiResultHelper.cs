using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalusAdmin.Common;
public static class ApiResultHelper
{
    public static ApiResult Result(int code = StatusCodes.Status200OK, string? message = ApiResultMessage.Status200OK, object? body = null)
    {
        return new ApiResult(code, message, body);
    }

    public static ApiResult Result200OK(string? message = ApiResultMessage.Status200OK, object? body = null)
    {
        return new ApiResult(StatusCodes.Status200OK, message, body);
    }

    public static ApiResult Result207Bad(string? message = ApiResultMessage.Status400BadRequest, object? body = null)
    {
        return new ApiResult(StatusCodes.Status200OK, message, body);
    }
    public static ApiResult Result400BadRequest(string? message = ApiResultMessage.Status400BadRequest, object? body = null)
    {
        return new ApiResult(StatusCodes.Status400BadRequest, message, body);
    }

    public static ApiResult Result401Unauthorized(string? message = ApiResultMessage.Status401Unauthorized, object? body = null)
    {
        return new ApiResult(StatusCodes.Status401Unauthorized, message, body);
    }

    public static ApiResult Result403Forbidden(string? message = ApiResultMessage.Status403Forbidden, object? body = null)
    {
        return new ApiResult(StatusCodes.Status403Forbidden, message, body);
    }

    public static ApiResult Result404NotFound(string? message = ApiResultMessage.Status404NotFound, object? body = null)
    {
        return new ApiResult(StatusCodes.Status404NotFound, message, body);
    }

    public static ApiResult Result409Conflict(string? message = ApiResultMessage.Status409Conflict, object? body = null)
    {
        return new ApiResult(StatusCodes.Status409Conflict, message, body);
    }

    public static ApiResult Result500InternalServerError(string? message = ApiResultMessage.Status500InternalServerError, object? body = null)
    {
        return new ApiResult(StatusCodes.Status500InternalServerError, message, body);
    }

    public static string GetMessage(int statusCode)
    {
        return statusCode switch
        {
            StatusCodes.Status200OK => ApiResultMessage.Status200OK,
            StatusCodes.Status400BadRequest => ApiResultMessage.Status400BadRequest,
            StatusCodes.Status401Unauthorized => ApiResultMessage.Status401Unauthorized,
            StatusCodes.Status403Forbidden => ApiResultMessage.Status403Forbidden,
            StatusCodes.Status404NotFound => ApiResultMessage.Status404NotFound,
            StatusCodes.Status409Conflict => ApiResultMessage.Status409Conflict,
            StatusCodes.Status500InternalServerError => ApiResultMessage.Status500InternalServerError,
            _ => ""
        };
    }

    public static bool GetSuccess(int statusCode)
    {
        if (statusCode >= 200 && statusCode <= 299)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

