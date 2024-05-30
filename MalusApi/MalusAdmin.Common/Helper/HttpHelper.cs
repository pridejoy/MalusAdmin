namespace MalusAdmin.Common;

public static class HttpHelper
{
    /// <summary>
    ///     获取完整请求地址
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public static string GetRequestUrlAddress(this HttpRequest request)
    {
        return new StringBuilder()
            .Append(request.Scheme).Append("://").Append(request.Host)
            .Append(request.PathBase.ToString())
            .Append(request.Path.ToString())
            .Append(request.QueryString)
            .ToString();
    }


    /// <summary>
    ///     获取请求的ip4
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public static string GetRequestIPv4(this HttpContext context)
    {
        var ip = string.Empty;
        if (context.Connection.RemoteIpAddress != null)
        {
            if (context.Request.Headers.ContainsKey("X-Real-IP"))
                ip = context.Request.Headers["X-Real-IP"].FirstOrDefault() ?? "";
            if (context.Request.Headers.ContainsKey("X-Forwarded-For"))
                ip = context.Request.Headers["X-Forwarded-For"].FirstOrDefault() ?? "";
            if (string.IsNullOrEmpty(ip)) ip = context.Connection.RemoteIpAddress?.MapToIPv4()?.ToString() ?? "";
        }

        return ip;
    }
}