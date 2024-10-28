using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

public static class InjectionServiceCollectionExtensions
{
    /// <summary>
    /// 自动注册程序集内以 Service 结尾的服务
    /// </summary>
    /// <param name="services"></param>
    /// <param name="dllNames"></param>
    /// <returns></returns>
    public static IServiceCollection AddAutoServices(this IServiceCollection services, params string[] dllNames)
    {
        // 根据名称获取程序集
        var assemblies = AssemblyHelper.GetAssemblies(dllNames);

        // 获取程序集内名称以 Service 结尾的 class
        var serviceTypes = assemblies.SelectMany(a => a.GetTypes())
            .Where(t => t.Name.EndsWith("Service") && t.IsClass && !t.IsAbstract)
            .Distinct();

        // 遍历，将服务默认注册为瞬态服务（生命周期：Transient）
        foreach (var serviceType in serviceTypes)
        {
            // 注册自身
            RegistrationType(services, serviceType, serviceType);

            // 注册所有实现的实例（!Problem：子类也会实现父类的接口，可能导致父类对接口的实现被覆盖）
            var serviceInterfaces = serviceType.GetInterfaces();
            foreach (var serviceInterface in serviceInterfaces)
                RegistrationType(services, serviceInterface, serviceType);
        }


        return services;


        // 实现自定义注册
        static void RegistrationType(IServiceCollection services, Type serviceType, Type implementationType)
        {
            
            // 设置默认生命周期为 Transient
            var lifecyleType = ServiceLifetime.Transient;

            Console.WriteLine("注册方式：" + lifecyleType.ToString() + 
                "名称：" + serviceType.Name, 
                "实例：" + implementationType.Name);

            // 获取服务自动注入标签（AutoInject）
            // 获取服务自动注入标签（AutoInject）
            var autoInjection = serviceType.GetCustomAttribute<AutoInjectionAttribute>();
            if (autoInjection != null)
            {
                if (!autoInjection.AutoRegister)
                {
                    return;
                }
                lifecyleType = autoInjection.Lifecycle;
            }
            //AutoIocAttribute attribute = (AutoIocAttribute)Attribute.GetCustomAttribute(serviceType, typeof(AutoIocAttribute));
            //if (attribute != null)
            //{
            //    services.Add(new ServiceDescriptor(serviceType, attribute.Mode));
            //}
            //https://blog.csdn.net/qq_39427511/article/details/128212497

            // 注册服务
            switch (lifecyleType)
            {
                case ServiceLifetime.Singleton:
                    services.AddSingleton(serviceType, implementationType);
                    break;
                case ServiceLifetime.Scoped:
                    services.AddScoped(serviceType, implementationType);
                    break;
                case ServiceLifetime.Transient:
                default:
                    services.AddTransient(serviceType, implementationType);
                    break;
            }
        }
    }
}