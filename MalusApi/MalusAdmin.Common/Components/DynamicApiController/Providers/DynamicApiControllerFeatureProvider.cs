using Microsoft.AspNetCore.Mvc.Controllers;
using System.Reflection;

namespace MalusAdmin.Common;

/// <summary>
/// 自定义控制器特性提供程序，用于动态识别和注册API控制器
/// </summary>
public class DynamicApiControllerFeatureProvider : ControllerFeatureProvider
{
    protected override bool IsController(TypeInfo typeInfo)
    {
        return ControllerSelector.IsDynamicApiController(typeInfo);
    }
}
