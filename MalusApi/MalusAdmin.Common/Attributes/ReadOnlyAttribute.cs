using Microsoft.AspNetCore.Mvc.Filters;

namespace MalusAdmin.Common;

/// <summary>
///     演示环境禁止操作
/// </summary>
public class ReadOnlyAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (AppSettings.IsDemo) throw ResultHelper.Exception207Bad("演示环境,禁止操作");
        base.OnActionExecuting(context);
    }
}