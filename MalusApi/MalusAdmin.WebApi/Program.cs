using MalusAdmin.Common.Components;
using MalusAdmin.Common.Components.JsonOptionsExtensions;
using MalusAdmin.Servers.Hub;
using MalusAdmin.WebApi.Filter;
using Microsoft.AspNetCore.HttpOverrides;

namespace MalusAdmin.WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        //App注册 
        builder.ConfigureApplication();
        builder.Configuration.ConfigureApplication();

        //进行配置注册 | 添加静态文件读取(优先级比较高)
        AppSettings.AddConfigSteup(builder.Configuration); 
           
        //缓存
        builder.Services.AddCacheSetup(); 
         
        //基础服务注册
        builder.Services.AddBaseServices();

        //添加过滤器
        builder.Services.AddControllers(options =>
            {
                //授权筛选器 
                //options.Filters.Add<CustomAuthorizationFilter>();
                // 全局异常过滤
                //options.Filters.Add<GlobalExceptionFilter>();
                // 日志过滤器
                //options.Filters.Add<RequestActionFilter>();

                options.Filters.Add<ResultFilter>();
            })
            .AddDataValidation();
            //.AddApiJson<CustomApiJsonProvider>();

        //配置Json选项
        //builder.Services.AddTextJsonOptions();
        builder.Services.AddJsonOptions();

        // 添加sqlsugar
        builder.Services.AddSqlsugarSetup();

        // 添加swagger文档
        builder.Services.AddSwaggerBaseSetup();
         
        var dllnames =new string[] { "MalusAdmin.Servers" };
        // 自动添加服务层
        builder.Services.AddAutoServices(dllnames);
         
        //添加授权
        //builder.Services.AddAuthorization();

        // 添加自定义授权
        builder.Services.AddAuthorizationSetup();
 
        // 添加跨域支持
        builder.Services.AddCorsSetup();

        //响应缓存中间件
        builder.Services.AddResponseCaching();

        //实时应用
        builder.Services.AddSignalR();
         
        //rabbit
        //builder.Services.AddRabbitMqClientExtension();
        //builder.Services.AddEasyNetQExtension(); 

        // 添加EndpointsApiExplorer
        builder.Services.AddEndpointsApiExplorer();

        var app = builder.Build();

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
        app.UseMiddleware<CheckToken>();
         
        app.MapHub<OnlineUserHub>("/hub");// 映射SignalR Hub
         
        app.MapControllers(); // 映射控制器

        // 启动服务器
        app.Run(); 
    }
}