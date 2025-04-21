

namespace MalusAdmin.Common;

public static class DynamicApiConsts
{
    /// <summary>
    /// 默认API前缀
    /// </summary>
    public const string DefaultApiPrefix = "api";

    /// <summary>
    /// 默认根路径：如(/api/app/test/xxx)，其中app为根路径，可根据实际需求修改。
    /// 是否需要将根路径添加到路由中，根据实际情况而定，此处是参考abp的约定来做，请根据实际需求来决定是否使用根路径。
    /// 此处提供DefaultIsRootPathInRoute快捷开关，默认不开启，如需客开，可在DynamicWebApiConvention处理
    /// </summary>
    public const string DefaultRootPath = "app";

    /// <summary>
    /// 是否需要将根路径添加到路由中
    /// </summary>
    public static bool DefaultIsRootPathInRoute = false;

    /// <summary>
    /// 默认HTTP方法
    /// </summary>
    public const string DefaultHttpVerb = "POST";

    /// <summary>
    /// 控制器名称后缀
    /// </summary>
    public static string[] CommonPostfixes { get; set; } = { "AppService", "ApplicationService", "Service" };

    /// <summary>
    /// 默认的约定前缀
    /// </summary>
    public static IReadOnlyDictionary<string, string[]> ConventionalPrefixes { get; } = new Dictionary<string, string[]>
    {
        ["GET"] = new[] { "GetList", "GetAll", "Get" },
        ["PUT"] = new[] { "Put", "Update" },
        ["DELETE"] = new[] { "Delete", "Remove" },
        ["POST"] = new[] { "Create", "Add", "Insert", "Post" },
        ["PATCH"] = new[] { "Patch" }
    };
}
