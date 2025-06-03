using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.DependencyInjection;
using Simple.DynamicWebApi.Conventions;
using Simple.DynamicWebApi.Providers;

namespace Simple.DynamicWebApi.Extensions;

public static class DynamicWebApiExtensions
{
    /// <summary>
    /// 添加动态API控制器服务
    /// </summary>
    /// <param name="services">服务集合</param>
    /// <returns>服务集合</returns>
    public static IServiceCollection AddDynamicApiController(this IServiceCollection services)
    {
        if (services == null)
        {
            throw new ArgumentNullException(nameof(services));
        }

        //AddDynamicApiController 必须在 AddControllers 之后调用
        var partManager = services.FirstOrDefault(s => s.ServiceType == typeof(ApplicationPartManager))?.ImplementationInstance as ApplicationPartManager;
        if (partManager is null)
        {
            throw new InvalidOperationException(
                $" {nameof(AddDynamicApiController)} 必须在在 {nameof(MvcServiceCollectionExtensions.AddControllers)} 之后调用"
            );
        }

        //动态API控制器特性提供者,用于动态发现和注册 API 控制器
        partManager.FeatureProviders.Add(new DynamicWebApiFeatureProvider());

        IServiceCollection serviceCollection = services.Configure<MvcOptions>(o =>
        {
            //动态API控制器路由约定
            o.Conventions.Add(new DynamicWebApiConvention());
        });

        return services;
    }
}
