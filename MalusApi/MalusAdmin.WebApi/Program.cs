using MalusAdmin.Common.Components;
using MalusAdmin.Servers.Hub;
using MalusAdmin.WebApi.Filter;
using Microsoft.AspNetCore.HttpOverrides;

namespace MalusAdmin.WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args); 

        //进行配置注册 | 添加静态文件读取(优先级比较高)
        AppSettings.AddConfigSteup(builder.Configuration); 

        //打印控制台显示
        builder.Services.AddLogo();

        //进行选项注册
        builder.Services.AddConfigureSetup(builder.Configuration); 

        //缓存
        builder.Services.AddCacheSetup(); 
         
        //基础服务注册
        builder.Services.AddBaseServices();

        // 添加过滤器
        builder.Services.AddControllers(options =>
            {
                // 全局异常过滤
                options.Filters.Add<GlobalExceptionFilter>();
                // 日志过滤器
                options.Filters.Add<RequestActionFilter>();
            })
            .AddDataValidation()
            .AddApiResult<CustomApiResultProvider>(); 

        // 配置Json选项
        builder.Services.AddJsonOptions();

        // 添加sqlsugar
        builder.Services.AddSqlsugarSetup();

        // 添加swagger文档
        builder.Services.AddSwaggerBaseSetup();
         
        var dllnames =new string[] { "MalusAdmin.Servers", "MalusAdmin.Common" };
        // 自动添加服务层
        builder.Services.AddAutoServices(dllnames);
          
        //添加授权
        //builder.Services.AddAuthorization();
        // 添加自定义授权
        builder.Services.AddAuthorizationSetup();

        // 替换默认 PermissionChecker
        //builder.Services.Replace(new ServiceDescriptor(typeof(IPermissionChecker), typeof(PermissionChecker), ServiceLifetime.Transient));

        // 添加跨域支持
        builder.Services.AddCorsSetup();

        //响应缓存中间件
        builder.Services.AddResponseCaching();

        //实时应用
        builder.Services.AddSignalR();

        // 添加EndpointsApiExplorer
        builder.Services.AddEndpointsApiExplorer();


        var app = builder.Build();
        //写入静态类供全局获取
        App.ServiceProvider = app.Services;
        App.Configuration = builder.Configuration;

        //ForwardedHeaders中间件会自动把反向代理服务器转发过来的X-Forwarded-For（客户端真实IP）以及X-Forwarded-Proto（客户端请求的协议）
        //自动填充到HttpContext.Connection.RemoteIPAddress和HttpContext.Request.Scheme中，这样应用代码中读取到的就是真实的IP和真实的协议了，不需要应用做特殊处理。
        app.UseForwardedHeaders(new ForwardedHeadersOptions
        {
            ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
        });


        // Configure the HTTP request pipeline.
        if (AppSettings.DisplaySwaggerDoc) app.UseSwaggerExtension();


        app.UseDefaultFiles(); // 提供默认文件支持
        app.UseStaticFiles(); // 启用静态文件服务

        app.UseHttpsRedirection(); // 放在前面，确保所有请求都通过HTTPS

        app.UseRouting(); // 确定路由

        app.UseCors(); // 配置跨域资源共享

        app.UseAuthentication(); // 启用身份验证中间件

        app.UseAuthorization(); // 启用授权中间件

        app.UseResponseCaching(); // 应用响应缓存

        app.UseMiddleware<CheckToken>(); // 如果CheckToken是身份验证中间件，放在认证之前

        app.MapHub<OnlineUserHub>("/hub"); // 映射SignalR Hub

        app.MapControllers(); // 映射控制器

        app.Run(); // 启动服务器
    }
}