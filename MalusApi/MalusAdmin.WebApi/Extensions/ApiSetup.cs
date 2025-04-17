using MalusAdmin.Common.Components;
using MalusAdmin.Servers.Hub;
using Microsoft.AspNetCore.Builder;

namespace MalusAdmin.WebApi
{ 

    // 扩展方法：服务注册
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
              
            //进行配置注册 | 添加静态文件读取(优先级比较高)
            AppSettings.AddConfigSteup(configuration);

            //选项通过特性注册
            services.AddOptionRegister();

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

            //添加授权
            //services.AddAuthorization();
            services.AddAuthorizationSetup();

            // 替换默认 PermissionChecker[权限检查]
            services.Replace(new ServiceDescriptor(typeof(IPermissionChecker), typeof(PermissionChecker), ServiceLifetime.Transient));

            services.AddCorsSetup();

            services.AddResponseCaching();

            services.AddSignalR();

            //rabbit
            //services.AddRabbitMqClientExtension();
            //services.AddEasyNetQExtension(); 
            services.AddEndpointsApiExplorer();

            return services;
        }
    }

    // 扩展方法：中间件配置
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseApplicationMiddlewares(this IApplicationBuilder app)
        {
             
            app.ConfigureApplication();

            if (AppSettings.DisplaySwaggerDoc) app.UseSwaggerExtension();

            // 全局异常中间件
            app.UseMiddleware<GlobalException>();

            //获取远程真实ip,不是nginx代理部署可以不要
            app.UseMiddleware<RealIpMiddleware>();

            app.UseHttpsRedirection(); // 确保所有请求都通过HTTPS

            app.UseRouting(); // 确定路由

            app.UseCors(); // 配置跨域资源共享

            app.UseAuthentication(); // 启用身份验证中间件

            app.UseAuthorization(); // 启用授权中间件

            app.UseStaticFiles(); // 启用静态文件服务

            app.UseDefaultFiles(); // 提供默认文件支持

            app.UseResponseCaching(); // 应用响应缓存

            // 身份验证中间件（在控制器之前执行特定的检查）
            //app.UseMiddleware<CheckToken>();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            return app;
        }
    }

}
