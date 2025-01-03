namespace MalusAdmin.Common;

/// <summary>
/// 返回统一结果的异常。
/// 需要配合 AppResultActionFilter 使用。
/// </summary>
/// <typeparam name="T"></typeparam>
public class ApiJsonException : Exception
{ 
    public ApiJsonException(ApiJson ApiJson)
        : this(ApiJson, null)
    {
        apiJson = ApiJson; 
    }

    public ApiJsonException(ApiJson ApiJson, Exception? innerException)
     : base(ApiJson.Message, innerException)
    {
        apiJson = ApiJson; 
    }

    /// <summary>
    /// API 结果
    /// </summary>
    public ApiJson apiJson { get; private set; }
}

public static class ApiException
{
    public static ApiJsonException Exception(ApiCode apicode, string? message = "", object? data = null)
    {
        if (string.IsNullOrEmpty(message)) message = apicode.GetDescription();
        var ApiJson = new ApiJson(apicode, message, data);
        return new ApiJsonException(ApiJson);
    }

    public static ApiJsonException Exception401(string? message, object? data = null)
    { 
        return new ApiJsonException(ApiCode.没有登录状态.RJson(data, message));
    }

    public static ApiJsonException Exception207Bad(string? message, object? data = null)
    {
        var j = ApiCode.Exception207Bad.RJson(data, message);
        return new ApiJsonException(j);
    }
}