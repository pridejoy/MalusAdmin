namespace MalusAdmin.Common;

public class ApiResult
{
    public ApiResult(int code = StatusCodes.Status200OK, string? message = ApiResultMessage.Status200OK,
        object? body = null)
    {
        Code = code;
        Message = message;
        Body = body;
    }

    public int Code { get; set; }

    public string? Message { get; set; }

    public object? Body { get; set; }
}