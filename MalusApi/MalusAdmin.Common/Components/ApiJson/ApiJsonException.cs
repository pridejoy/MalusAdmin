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
    }
      
    public ApiJsonException(ApiJson ApiJson, Exception? innerException)
        : base(ApiJson.Message, innerException)
    {
        ApiJson = ApiJson;
    }

    /// <summary>
    /// API 结果
    /// </summary>
    public ApiJson ApiJson { get; private set; }
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
        return new ApiJsonException(ApiCode.缺少权限.RJson(data,message));
    }
}