namespace Simple.DynamicWebApi.Consts;

/// <summary>
/// 动态WebApi控制器常量类
/// </summary>
internal static class DynamicWebApiConsts
{
    /// <summary>
    /// 默认API前缀
    /// </summary>
    internal const string DefaultApiPrefix = "api";

    /// <summary>
    /// 默认根路径：如(/api/app/test/xxx)，其中app为根路径，可根据实际需求修改。
    /// 此处默认不添加根路径，如果要添加根路径，请将DefaultIsRootPathInRoute设置为true。
    /// </summary>
    internal const string DefaultRootPath = "app";

    /// <summary>
    /// 是否需要将根路径添加到路由中
    /// </summary>
    internal static bool DefaultIsRootPathInRoute = false;

    /// <summary>
    /// 默认HTTP方法
    /// </summary>
    internal const string DefaultHttpVerb = "POST";

    /// <summary>
    /// 控制器名称后缀
    /// </summary>
    internal static string[] CommonPostfixes { get; set; } = { "AppService", "ApplicationService", "Service", "Controller" };

    /// <summary>
    /// 默认的约定前缀
    /// </summary>
    internal static IReadOnlyDictionary<string, string[]> ConventionalPrefixes { get; } = new Dictionary<string, string[]>
    {
        ["GET"] = new[] { "GetList", "GetAll", "Get" },
        ["PUT"] = new[] { "Put", "Update" },
        ["DELETE"] = new[] { "Delete", "Remove" },
        ["POST"] = new[] { "Create", "Add", "Insert", "Post" },
        ["PATCH"] = new[] { "Patch" }
    };
}
