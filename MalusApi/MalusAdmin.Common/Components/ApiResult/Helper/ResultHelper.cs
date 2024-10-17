namespace MalusAdmin.Common;

public static class ResultHelper
{
    public static T Result<T>(int code = StatusCodes.Status200OK, string? message = ApiResultMessage.Status200OK,
        T? data = default)
    {
        var ApiResult = new ApiResult(code, message, data);
        throw new ApiResultException(ApiResult);
    }

    public static T Result200OK<T>(string? message = ApiResultMessage.Status200OK, T? data = default)
    {
        var ApiResult = new ApiResult(StatusCodes.Status200OK, message, data);
        throw new ApiResultException(ApiResult);
    }

    public static T Result400BadRequest<T>(string? message = ApiResultMessage.Status400BadRequest, T? data = default)
    {
        var ApiResult = new ApiResult(StatusCodes.Status400BadRequest, message, data);
        throw new ApiResultException(ApiResult);
    }

    public static T Result401Unauthorized<T>(string? message = ApiResultMessage.Status401Unauthorized,
        T? data = default)
    {
        var ApiResult = new ApiResult(StatusCodes.Status401Unauthorized, message, data);
        throw new ApiResultException(ApiResult);
    }

    public static T Result403Forbidden<T>(string? message = ApiResultMessage.Status403Forbidden, T? data = default)
    {
        var ApiResult = new ApiResult(StatusCodes.Status403Forbidden, message, data);
        throw new ApiResultException(ApiResult);
    }

    public static T Result404NotFound<T>(string? message = ApiResultMessage.Status404NotFound, T? data = default)
    {
        var ApiResult = new ApiResult(StatusCodes.Status404NotFound, message, data);
        throw new ApiResultException(ApiResult);
    }

    public static T Result409Conflict<T>(string? message = ApiResultMessage.Status409Conflict, T? data = default)
    {
        var ApiResult = new ApiResult(StatusCodes.Status409Conflict, message, data);
        throw new ApiResultException(ApiResult);
    }

    public static T Result500InternalServerError<T>(string? message = ApiResultMessage.Status500InternalServerError,
        T? data = default)
    {
        var ApiResult = new ApiResult(StatusCodes.Status500InternalServerError, message, data);
        throw new ApiResultException(ApiResult);
    }

    public static ApiResultException Exception(int code = StatusCodes.Status200OK,
        string? message = ApiResultMessage.Status200OK, object? data = null, bool success = true)
    {
        var ApiResult = new ApiResult(code, message, data);
        throw new ApiResultException(ApiResult);
    }

    public static ApiResultException Exception200OK(string? message = ApiResultMessage.Status200OK, object? data = null)
    {
        var ApiResult = new ApiResult(StatusCodes.Status200OK, message, data);
        return new ApiResultException(ApiResult);
    }

    /// <summary>
    /// 有错误提示
    /// </summary>
    /// <param name="message"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    public static ApiResultException Exception207Bad(string? message = ApiResultMessage.Status400BadRequest,
        object? data = null)
    {
        var ApiResult = new ApiResult(StatusCodes.Status207MultiStatus, message, data);
        return new ApiResultException(ApiResult);
    }

    public static ApiResultException Exception400BadRequest(string? message = ApiResultMessage.Status400BadRequest,
        object? data = null)
    {
        var ApiResult = new ApiResult(StatusCodes.Status400BadRequest, message, data);
        return new ApiResultException(ApiResult);
    }

    public static ApiResultException Exception401Unauthorized(string? message = ApiResultMessage.Status401Unauthorized,
        object? data = null)
    {
        var ApiResult = new ApiResult(StatusCodes.Status401Unauthorized, message, data);
        return new ApiResultException(ApiResult);
    }

    public static ApiResultException Exception403Forbidden(string? message = ApiResultMessage.Status403Forbidden,
        object? data = null)
    {
        var ApiResult = new ApiResult(StatusCodes.Status403Forbidden, message, data);
        return new ApiResultException(ApiResult);
    }

    public static ApiResultException Exception404NotFound(string? message = ApiResultMessage.Status404NotFound,
        object? data = null)
    {
        var ApiResult = new ApiResult(StatusCodes.Status404NotFound, message, data);
        return new ApiResultException(ApiResult);
    }

    public static ApiResultException Exception409Conflict(string? message = ApiResultMessage.Status409Conflict,
        object? data = null)
    {
        var ApiResult = new ApiResult(StatusCodes.Status409Conflict, message, data);
        return new ApiResultException(ApiResult);
    }

    public static ApiResultException Exception500InternalServerError(
        string? message = ApiResultMessage.Status500InternalServerError, object? data = null)
    {
        var ApiResult = new ApiResult(StatusCodes.Status500InternalServerError, message, data);
        return new ApiResultException(ApiResult);
    }
}