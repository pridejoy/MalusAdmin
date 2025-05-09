using Microsoft.AspNetCore.Mvc.Filters;
using SqlSugar.Extensions;

namespace MalusAdmin.Common;

/// <summary>
/// 演示环境禁止操作
/// </summary>
public class ReadOnlyAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        //是否演示环境
        if (App.Configuration["IsDemo"].ObjToBool()) throw ApiException.Exception207Bad("演示环境,禁止操作");
        base.OnActionExecuting(context);
    }
}