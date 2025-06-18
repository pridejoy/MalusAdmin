using Microsoft.AspNetCore.Mvc; 
namespace Simple.DynamicWebApi.Helper;

/// <summary>
/// 控制器选择器，用于判断类型是否为动态API控制器。
/// </summary>
internal class ControllerSelector
{
    /// <summary>
    /// 判断类型是否为动态API控制器
    /// </summary>
    /// <param name="type">要检查的类型</param>
    /// <returns>如果类型符合动态 API 控制器的约定条件，则返回 true；否则返回 false</returns>
    internal static bool IsDynamicWebApiController(Type type)
    {
        if (!type.IsPublic) // 排除非公开类型
        {
            return false;
        }

        if (type.IsPrimitive) // 基元类型（int/string等）
        {
            return false;
        }

        if (type.IsValueType) // 值类型（如 struct）
        {
            return false;
        }

        if (type.IsAbstract) // 抽象类
        {
            return false;
        }

        if (type.IsInterface) // 接口
        {
            return false;
        }

        if (type.IsGenericType) // 泛型类型
        {
            return false;
        }

        if (type.IsDefined(typeof(NonControllerAttribute), false)) //标记了[NonController]特性，排除
        {
            return false;
        }

        return typeof(IDynamicWebApi).IsAssignableFrom(type) || typeof(IApplicationService).IsAssignableFrom(type);
    }
}