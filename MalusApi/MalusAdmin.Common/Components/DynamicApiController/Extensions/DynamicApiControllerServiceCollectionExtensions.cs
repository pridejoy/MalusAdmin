using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.DependencyInjection;


namespace MalusAdmin.Common;

public static class DynamicApiControllerServiceCollectionExtensions
{
    /// <summary>
    /// 添加动态API控制器服务
    /// </summary>
    /// <param name="services">服务集合</param>
    /// <returns>服务集合</returns>
    public static IServiceCollection AddDynamicApiControllers(this IServiceCollection services)
    {
        if (services == null)
        {
            throw new ArgumentNullException(nameof(services));
        }

        //AddDynamicApiControllers 必须在 AddControllers 之后调用
        var partManager = services.FirstOrDefault(s => s.ServiceType == typeof(ApplicationPartManager))?.ImplementationInstance as ApplicationPartManager;
        if (partManager is null)
        {
            throw new InvalidOperationException(
                $"请确保在调用 {nameof(AddDynamicApiControllers)} 之前已调用 {nameof(MvcServiceCollectionExtensions.AddControllers)}。" +
                $"正确的顺序为：services.AddControllers().{nameof(AddDynamicApiControllers)}();"
            );
        }

        //动态API控制器特性提供者,用于动态发现和注册 API 控制器
        partManager.FeatureProviders.Add(new DynamicApiControllerFeatureProvider());

        services.Configure<MvcOptions>(o =>
        {
            //动态API控制器路由约定
            o.Conventions.Add(new DynamicWebApiConvention());
        });

        return services;
    }
}
