using Simple.DynamicWebApi.Consts;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Simple.DynamicWebApi.Helper;

/// <summary>
/// DynamicWebApiHelper 静态帮助类。
/// </summary>
internal static class DynamicWebApiHelper
{
    /// <summary>
    /// 移除字符串末尾的指定后缀（默认区分大小写），如:TestAppService -> Test
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
    /// 移除字符串开头的指定前缀（默认区分大小写），如:GetUserInfo -> UserInfo
    /// </summary>
    internal static string RemovePreFix(this string str, params string[] preFixes)
    {
        return str.RemovePreFix(StringComparison.Ordinal, preFixes);
    }
    internal static string RemovePreFix(this string str, StringComparison comparisonType, params string[] preFixes)
    {
        if (str.IsNullOrEmpty())
        {
            return str;
        }

        if (preFixes.IsNullOrEmpty())
        {
            return str;
        }

        foreach (var preFix in preFixes.Where(pf => !string.IsNullOrEmpty(pf)))
        {
            // 检查字符串是否以当前前缀开头
            if (str.StartsWith(preFix, comparisonType))
            {
                // 移除前缀并返回结果
                return str.Substring(preFix.Length);
            }
        }

        return str;
    }

    /// <summary>
    /// 根据Action名称选择HttpMethod，如果找不到对应的HttpMethod，则返回post;
    /// </summary>
    internal static string SelectHttpMethod(string actionName)
    {
        foreach (var conventionalPrefix in DynamicWebApiConsts.ConventionalPrefixes)
        {
            if (conventionalPrefix.Value.Any(prefix => actionName.StartsWith(prefix, StringComparison.OrdinalIgnoreCase)))
            {
                return conventionalPrefix.Key;
            }
        }
        return DynamicWebApiConsts.DefaultHttpVerb;
    }

    /// <summary>
    /// 获取Action的路由前缀
    /// </summary>
    internal static string GetApiRoutePrefix()
    {
        return DynamicWebApiConsts.DefaultApiPrefix;
    }

    /// <summary>
    /// 驼峰转Kebab命名法（如 "HelloWorld" → "hello-world"）
    /// </summary>
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

    /// <summary>
    /// 移除HttpMethod前缀（如 "GetHelloWorld" → "HelloWorld"，"PostHelloWorld" → "HelloWorld"）
    /// </summary>
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

        DynamicWebApiConsts.ConventionalPrefixes.TryGetValue(httpMethod, out var prefixes);
        if (prefixes.IsNullOrEmpty())
        {
            return actionName;
        }

        return actionName.RemovePreFix(prefixes!);
    }

    /// <summary>
    /// 判断类型是否为扩展原始类型（包括枚举），包含可为空的情况。
    /// </summary>
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

    /// <summary>
    /// 判断类型是否为扩展原始类型（包括枚举）。
    /// </summary>
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

    /// <summary>
    /// 判断字符串是否在给定的数据中
    /// </summary>
    internal static bool IsIn(this string str, params string[] data)
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

    /// <summary>
    /// 判断字符串是否为空或null
    /// </summary>
    internal static bool IsNullOrEmpty( this string? str)
    {
        return string.IsNullOrEmpty(str);
    }

    /// <summary>
    /// 判断集合是否为空或null
    /// </summary>
    internal static bool IsNullOrEmpty<T>(this ICollection<T>? source)
    {
        return source == null || source.Count <= 0;
    }
}
