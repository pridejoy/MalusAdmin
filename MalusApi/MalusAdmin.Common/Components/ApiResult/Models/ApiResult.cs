using System;
using System.Collections.Generic;
using System.DirectoryServices.Protocols;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalusAdmin.Common;

public class ApiResult
{
    public int Code { get; set; }

    public string? Message { get; set; }

    public object? Body { get; set; } 

    public ApiResult(int code = StatusCodes.Status200OK, string? message = ApiResultMessage.Status200OK,  object? body = null)
    {
        Code = code;
        Message = message;
        Body = body; 
    }
}