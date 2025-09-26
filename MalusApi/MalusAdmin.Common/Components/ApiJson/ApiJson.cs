using System.Reflection.Emit;
using CSToolHub.Extensions;
using Dm;
using EasyNetQ;
using static Dm.net.buffer.ByteArrayBuffer;

namespace MalusAdmin.Common;

public class ApiJson
{
    public ApiJson(ApiCode apicode, string? message = null, object? body = null)
    {
        Code = apicode.GetHashCode();
        Message = message ?? apicode.GetDescription();
        Body = body;
    }
    public ApiJson()
    {
        Code = -1;
        Message = string.Empty;
        Body = null;
    }

    public int Code { get; set; }

    public string? Message { get; set; }

    public object? Body { get; set; }
}


public static class Tool
{
    public static ApiJson RJson(this Enum apicode, object body = null, string message = "")
    {
        if (string.IsNullOrEmpty(message)) message = apicode.GetDescription();
        return new ApiJson()
        {
            Code = apicode.GetHashCode(),
            Message = message,
            Body = body
        };
    }

}