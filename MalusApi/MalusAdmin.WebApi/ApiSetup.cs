using System.Configuration;
using System.Reflection;
using MalusAdmin.Common.Components;
 
using MalusAdmin.WebApi.Middleware;
using Microsoft.AspNetCore.Builder;
using Simple.DynamicWebApi.Extensions;
using SqlSugar.Extensions;

namespace MalusAdmin.WebApi
{ 

    // 扩展方法：服务注册
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            //跨域处理
            services.AddCorsSetup();

            //缓存
            services.AddCacheSetup();

            //基础服务注册
            services.AddBaseServices();

            //添加过滤器
            services.AddControllers(options =>
            {
                //授权筛选器 
                //options.Filters.Add<CustomAuthorizationFilter>();
                //全局异常过滤
                //options.Filters.Add<GlobalExceptionFilter>();
                //日志过滤器
                //options.Filters.Add<RequestActionFilter>();
                //结果过滤器
                options.Filters.Add<ResultFilter>();

            }).AddDataValidation();

            //.AddApiJson<CustomApiJsonProvider>();

            //配置Json选项
            //services.AddTextJsonOptions();

            services.AddJsonOptions();

            services.AddSqlsugarSetup();

            services.AddSwaggerBaseSetup();


            var dllnames = new string[] { "MalusAdmin.Servers" };
            services.AddAutoServices(dllnames);
            //services.AddAutoInjection(Assembly.GetExecutingAssembly());

            //添加授权
            //services.AddAuthorization();
            services.AddAuthorizationSetup();

            // 替换默认 PermissionChecker[权限检查]
            //services.Replace(new ServiceDescriptor(typeof(IPermissionChecker), typeof(PermissionChecker), ServiceLifetime.Transient));

            //rabbit
            //services.AddRabbitMqClientExtension();
            //services.AddEasyNetQExtension(); 

            services.AddDynamicApiController();

            //
            //services.AddTransient<ISysOnlineUserService, SysOnlineUserService>();

        

            services.AddSingleton(services);

            // 将 IServiceCollection 注册为单例，以便在中间件中访问
            services.AddSingleton<ApiExplorerService>();


            // 打印所有注册的服务 

            //Console.WriteLine("===== 已注册的服务列表 =====");
            //foreach (var service in builder.Services)
            //{
            //    Console.WriteLine($"服务类型: {service.ServiceType.FullName}");
            //    Console.WriteLine($"实现类型: {service.ImplementationType?.FullName}");
            //    Console.WriteLine($"生命周期: {service.Lifetime}");
            //    Console.WriteLine("----------------------------------");
            //}

            foreach (var service in services)
            {
                string? serviceNs = service.ServiceType?.Namespace ?? "";

                bool isMicrosoftNamespace = serviceNs.StartsWith("Microsoft");

                if (!isMicrosoftNamespace)
                {
                    Console.WriteLine($"服务类型: {service.ServiceType.FullName}");
                    Console.WriteLine($"实现类型: {service.ImplementationType?.FullName ?? "(工厂或实例)"}");
                    Console.WriteLine($"生命周期: {service.Lifetime}");
                    Console.WriteLine("----------------------------------");
                }
            }

            return services;
        }
    }

    // 扩展方法：中间件配置
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseApplicationMiddlewares(this WebApplication app)
        {
             
            app.ConfigureApplication();

            app.UseSwaggerExtension();

            // 全局异常中间件
            app.UseMiddleware<GlobalException>();

            //获取远程真实ip,不是nginx代理部署可以不要
            app.UseMiddleware<RealIpMiddleware>();

            app.UseServiceInspector(); // 注册服务查询中间件

            app.UseHttpsRedirection(); // 确保所有请求都通过HTTPS

            app.UseStaticFiles(); // 启用静态文件服务

            app.UseDefaultFiles(); // 提供默认文件支持

            app.UseRouting(); // 确定路由

            app.UseCors(); // 配置跨域资源共享

            app.UseAuthentication(); // 启用身份验证中间件

            app.UseAuthorization(); // 启用授权中间件
             
            app.UseResponseCaching(); // 应用响应缓存
             
            app.MapControllers();

            Console.WriteLine("扫描所有api端口");
            Console.WriteLine("=============");

            var service = app.Services.GetRequiredService<ApiExplorerService>();
            var endpoints = service.GetAllEndpoints();
            foreach (var endpoint in endpoints)
            {
                Console.WriteLine(endpoint);
            }

            Console.WriteLine("=============");

            return app;
        }
    }

}
