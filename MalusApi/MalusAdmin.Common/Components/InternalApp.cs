using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace MalusAdmin.Common;

/// <summary>
/// 内部App副本
/// </summary>
internal static class InternalApp
{
    /// <summary>
    /// 应用服务
    /// </summary>
    internal static IServiceCollection InternalServices;

    /// <summary>
    /// 根服务
    /// </summary>
    internal static IServiceProvider RootServices;

    /// <summary>
    /// 配置对象
    /// </summary>
    internal static IConfiguration Configuration;

    /// <summary>
    /// 获取Web主机环境
    /// </summary>
    internal static IWebHostEnvironment WebHostEnvironment;

    /// <summary>
    /// 获取泛型主机环境
    /// </summary>
    internal static IHostEnvironment HostEnvironment;
}

/// <summary>
/// 内部 App 副本扩展方法
/// </summary>
public static class InternalAppExtensions
{
    /// <summary>
    /// 配置应用服务和环境
    /// </summary>
    /// <param name="builder">WebApplicationBuilder</param>
    public static void ConfigureApplication(this WebApplicationBuilder builder)
    {
        // 存储服务提供器
        InternalApp.InternalServices = builder.Services;

        // 存储配置对象
        InternalApp.Configuration = builder.Configuration;

        // 存储Web主机环境
        InternalApp.WebHostEnvironment = builder.Environment;

        // 存储泛型主机环境
        InternalApp.HostEnvironment = builder.Environment;
    }


    /// <summary>
    /// 配置中间件
    /// </summary>
    /// <param name="app">WebApplication</param>
    public static void ConfigureApplication(this IApplicationBuilder app)
    {
        // 存储根服务提供器
        InternalApp.RootServices = app.ApplicationServices;

        app.Use(async (context, next) =>
        {

            await next.Invoke();

            //释放所有未托管的对象
            App.DisposeUnmanagedObjects();
        });
    }
}
