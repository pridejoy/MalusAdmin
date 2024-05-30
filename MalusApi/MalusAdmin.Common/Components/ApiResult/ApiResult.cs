using System.ComponentModel;

namespace MalusAdmin.Common;

/// <summary>
///     定义具体的返回状态码
/// </summary>
public enum ResultCode
{
    [Description("请求成功")] Success = 1,
    [Description("请求失败")] Fail = 0,
    [Description("请求异常")] Error = -1
}

#region 接口返回的Json对象

/// <summary>
///     JsonR 接口返回的Json对象
/// </summary>
[Serializable]
public class JsonR
{
    public JsonR()
    {
        code = -1;
        message = string.Empty;
        body = null;
    }

    /// <summary>
    ///     返回码
    /// </summary>
    public int code { get; set; }

    /// <summary>
    ///     返回说明
    /// </summary>
    public string message { get; set; }

    /// <summary>
    ///     返回数据体 可为空
    /// </summary>
    public object body { get; set; }
}

#endregion

#region JsonR 接口返回的Json对象

[Serializable]
public class JsonR<T>
{
    public JsonR()
    {
        code = -1;
        message = string.Empty;
        body = default;
    }

    /// <summary>
    ///     返回码
    /// </summary>
    public int code { get; set; }

    /// <summary>
    ///     返回说明
    /// </summary>
    public string message { get; set; }

    /// <summary>
    ///     返回数据体 可为空
    /// </summary>
    public T body { get; set; }
}

#endregion

public static class Tools
{
    /// <summary>
    ///     根据枚举返回对应的状态码
    /// </summary>
    /// <param name="Code"></param>
    /// <param name="obj"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    public static JsonR JsonR(this Enum Code, object obj = null, string message = "")
    {
        return new JsonR
        {
            code = Code.GetHashCode(),
            message = string.IsNullOrEmpty(message) ? EnumHelper.GetDescription(Code) : message,
            body = obj
        };
    }
}

public class ResObjectResult : ObjectResult
{
    public ResObjectResult(object value) : base(value)
    {
        StatusCode = StatusCodes.Status200OK;
    }
}