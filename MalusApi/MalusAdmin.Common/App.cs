using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MalusAdmin.Common;

public static class App
{
    public static IConfiguration Configuration { get; set; }

    public static IServiceProvider Instance { get; set; }

    public static IHostEnvironment Environment => Instance.GetRequiredService<IHostEnvironment>();

    /// <summary>
    /// 获取服务
    /// 最好只获取单例注入的服务
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T? GetService<T>()
    {
        return Instance.GetService<T>();
    }
}