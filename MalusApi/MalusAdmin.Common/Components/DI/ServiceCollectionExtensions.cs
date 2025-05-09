using System;
using System.Collections.Concurrent;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// 自动注册程序集内以 Service 结尾的服务
    /// </summary>
    /// <param name="services"></param>
    /// <param name="dllNames"></param>
    /// <returns></returns>
    public static IServiceCollection AddAutoServices(this IServiceCollection services, string[] dllNames)
    {

        // 根据名称获取程序集
        var assemblies = AssemblyHelper.GetAssemblies(dllNames);

        var types = assemblies
            .SelectMany(assembly => assembly.GetTypes()) // 获取每个程序集中的所有类型
            .ToArray();


     
        foreach (var type in types)
        {
            try
            {   //扫描注册
                if (type.IsClass && !type.IsAbstract && !type.IsGenericType)
                {
                    var interfaces = type.GetInterfaces();

                    foreach (var @interface in interfaces)
                    {
                        Console.WriteLine($"Scoped注册服务：{@interface.Name} -> {type.Name} ");
                        if (@interface.Name == "I" + type.Name && @interface.IsAssignableFrom(type))
                        {
                            services.AddScoped(@interface, type);
                        }
                    }
                }


                // 获取服务自动注入标签（AutoInject） ：适用于没有注册实现类
                var autoInjection = type.GetCustomAttribute<AutoInjectAttribute>();
                if (autoInjection != null)
                {
                    Console.WriteLine($"单独注册服务：  {type.Name}，生命周期：{autoInjection.Lifetime}");
                    switch (autoInjection.Lifetime)
                    {
                        case ServiceLifetime.Singleton:
                            services.AddSingleton(type);
                            break;
                        case ServiceLifetime.Scoped:
                            services.AddScoped(type);
                            break;
                        case ServiceLifetime.Transient:
                            services.AddTransient(type);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"注册 {type.FullName} 失败：{ex.Message}");
            }
        }





       

        return services;

    }
}