
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.IdentityModel.Tokens;
using System.Text.RegularExpressions;

namespace MalusAdmin.Common;

internal static class DynamicApiHelper
{
    /// <summary>
    /// 移除字符串末尾的指定后缀（默认区分大小写）。
    /// </summary>
    internal static string RemovePostFix(this string str, params string[] postFixes)
    {
        return str.RemovePostFix(StringComparison.Ordinal, postFixes);
    }
    internal static string RemovePostFix(this string str, StringComparison comparisonType, params string[] postfixes)
    {
        if (str.IsNullOrEmpty())
        {
            return str;
        }

        if (postfixes.IsNullOrEmpty())
        {
            return str;
        }


        // 遍历有效后缀
        foreach (var postFix in postfixes.Where(pf => !string.IsNullOrEmpty(pf)))
        {
            if (str.EndsWith(postFix, comparisonType))
            {
                return str.Substring(0, str.Length - postFix.Length);
            }
        }

        return str;
    }

    /// <summary>
    /// 移除字符串开头的指定前缀（默认区分大小写）。
    /// </summary>
    internal static string RemovePreFix(this string str, params string[] preFixes)
    {
        return str.RemovePreFix(StringComparison.Ordinal, preFixes);
    }
    internal static string RemovePreFix(this string str, StringComparison comparisonType, params string[] preFixes)
    {
        // 如果字符串为空或为 null，则直接返回原字符串
        if (str.IsNullOrEmpty())
        {
            return str;
        }

        // 如果没有提供前缀列表，或者前缀列表为空，则直接返回原字符串
        if (preFixes.IsNullOrEmpty())
        {
            return str;
        }

        // 遍历有效前缀
        foreach (var preFix in preFixes.Where(pf => !string.IsNullOrEmpty(pf)))
        {
            // 检查字符串是否以当前前缀开头
            if (str.StartsWith(preFix, comparisonType))
            {
                // 移除前缀并返回结果
                return str.Substring(preFix.Length);
            }
        }

        // 如果没有匹配到任何前缀，则返回原字符串
        return str;
    }

    /// <summary>
    /// 根据Action名称选择HttpMethod，如果找不到对应的HttpMethod，则返回post;
    /// </summary>
    /// <param name="actionName"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    internal static string SelectHttpMethod(string actionName)
    {
        foreach (var conventionalPrefix in DynamicApiConsts.ConventionalPrefixes)
        {
            if (conventionalPrefix.Value.Any(prefix => actionName.StartsWith(prefix, StringComparison.OrdinalIgnoreCase)))
            {
                return conventionalPrefix.Key;
            }
        }
        return DynamicApiConsts.DefaultHttpVerb;
    }

    /// <summary>
    /// 获取Action的路由前缀
    /// </summary>
    /// <param name="action"></param>
    /// <returns></returns>
    internal static string GetApiRoutePrefix(ActionModel action)
    {
        //可参考abp自行实现IntegrationService

        return DynamicApiConsts.DefaultApiPrefix;
    }

    /// <summary>
    /// 驼峰转Kebab命名法（如 "HelloWorld" → "hello-world"）
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    internal static string ToKebabCase(this string str)
    {
        if (string.IsNullOrWhiteSpace(str))
        {
            return str;
        }

        str = str.ToCamelCase();

        // 处理驼峰转短横线
        return Regex.Replace(str, "[a-z][A-Z]", m => m.Value[0] + "-" + char.ToLowerInvariant(m.Value[1]));
    }

    /// <summary>
    /// 转换为驼峰命名（首字母小写，如 "Test" → "test"，"HelloWorld" → "helloWorld"）
    /// </summary>
    internal static string ToCamelCase(this string str)
    {
        if (string.IsNullOrWhiteSpace(str)) return str;

        return str.Length == 1
            ? str.ToLowerInvariant()
            : char.ToLowerInvariant(str[0]) + str.Substring(1);
    }

    internal static string RemoveHttpMethodPrefix(this string actionName, string httpMethod)
    {

        if (actionName == null)
        {
            throw new ArgumentNullException(nameof(actionName));
        }
        if (httpMethod == null)
        {
            throw new ArgumentNullException(nameof(httpMethod));
        }

        DynamicApiConsts.ConventionalPrefixes.TryGetValue(httpMethod, out var prefixes);
        if (prefixes.IsNullOrEmpty())
        {
            return actionName;
        }

        return actionName.RemovePreFix(prefixes!);
    }

    internal static bool IsPrimitiveExtendedIncludingNullable(Type type, bool includeEnums = false)
    {
        if (IsPrimitiveExtended(type, includeEnums))
        {
            return true;
        }

        if (type.GetTypeInfo().IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
        {
            return IsPrimitiveExtended(type.GenericTypeArguments[0], includeEnums);
        }

        return false;
    }

    internal static bool IsPrimitiveExtended(Type type, bool includeEnums)
    {
        if (type.GetTypeInfo().IsPrimitive)
        {
            return true;
        }

        if (includeEnums && type.GetTypeInfo().IsEnum)
        {
            return true;
        }

        return type == typeof(string) ||
               type == typeof(decimal) ||
               type == typeof(DateTime) ||
               type == typeof(DateTimeOffset) ||
               type == typeof(TimeSpan) ||
               type == typeof(Guid);
    }

    public static bool IsIn(this string str, params string[] data)
    {
        foreach (var item in data)
        {
            if (str == item)
            {
                return true;
            }
        }
        return false;
    }
}
