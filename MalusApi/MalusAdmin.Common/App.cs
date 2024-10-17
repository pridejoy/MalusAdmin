using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MalusAdmin.Common;

public static class App
{
    /// <summary>
    /// 应用服务
    /// </summary>
    public static IServiceProvider ServiceProvider;

    /// <summary>
    /// 全局配置构建器
    /// </summary>
    public static IConfiguration Configuration;

    /// <summary>
    /// 获取Web主机环境
    /// </summary>
    public static IHostEnvironment Environment => ServiceProvider.GetRequiredService<IHostEnvironment>();


    /// <summary>
    /// 获取请求上下文
    /// </summary>
    public static HttpContext HttpContext =>
        CatchOrDefault(() => ServiceProvider?.GetService<IHttpContextAccessor>()?.HttpContext);


    //public static HttpContext HttpContext

    /// <summary>
    /// 获取服务
    /// 最好只获取单例注入的服务
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T? GetService<T>()
    {
        return ServiceProvider.GetService<T>();
    }

    /// <summary>
    /// 处理获取对象异常问题
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    /// <param name="action">获取对象委托</param>
    /// <param name="defaultValue">默认值</param>
    /// <returns>T</returns>
    private static T CatchOrDefault<T>(Func<T> action, T defaultValue = null)
        where T : class
    {
        try
        {
            return action();
        }
        catch
        {
            return defaultValue ?? null;
        }
    }
}