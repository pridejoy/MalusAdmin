using MalusAdmin.Servers.Hub;
using MalusAdmin.Servers.SysRolePermission;
using MalusAdmin.Servers.SysUserButtonPermiss;
using MalusAdmin.WebApi.Filter;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using SqlSugar;

namespace MalusAdmin.WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        //  进行配置注册 | 添加静态文件读取(优先级比较高)
        AppSettings.AddConfigSteup(builder.Configuration);

        //进行选项注册
        builder.Services.AddConfigureSetup(builder.Configuration);

        // 缓存
        builder.Services.AddCacheSetup();

        //HttpContext
        builder.Services.AddHttpContextAccessor();

        // 添加过滤器
        builder.Services.AddControllers(options =>
            {
                // 全局异常过滤
                options.Filters.Add<GlobalExceptionFilter>();
                // 日志过滤器
                options.Filters.Add<RequestActionFilter>();
            })
            // 配置Api行为选项
            .ConfigureApiBehaviorOptions(options =>
            {
                // 禁用默认模型验证过滤器
                options.SuppressModelStateInvalidFilter = true;
            })
            .AddApiResult<CustomApiResultProvider>();


        // 配置Json选项
        builder.Services.AddJsonOptions();

        // 添加sqlsugar
        builder.Services.AddSqlsugarSetup();

        // 添加swagger文档
        builder.Services.AddSwaggerSetup(); 

        // 自动添加服务层
        builder.Services.AddAutoServices("MalusAdmin.Servers");

        // 添加jwt认证
        //builder.Services.AddJwtSetup();

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
        App.Instance = app.Services;
        App.Configuration = builder.Configuration;

        //ForwardedHeaders中间件会自动把反向代理服务器转发过来的X-Forwarded-For（客户端真实IP）以及X-Forwarded-Proto（客户端请求的协议）
        //自动填充到HttpContext.Connection.RemoteIPAddress和HttpContext.Request.Scheme中，这样应用代码中读取到的就是真实的IP和真实的协议了，不需要应用做特殊处理。
        app.UseForwardedHeaders(new ForwardedHeadersOptions
        {
            ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
        });


        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                // 获取 IApiDescriptionGroupCollectionProvider 服务
                var provider = App.GetService<IApiDescriptionGroupCollectionProvider>();

                // 遍历所有API描述组
                foreach (var descriptionGroup in provider.ApiDescriptionGroups.Items)
                {
                    // 为每个分组指定Swagger文档和标题
                    c.SwaggerEndpoint($"/swagger/{descriptionGroup.GroupName}/swagger.json", descriptionGroup.GroupName);
                }
                //指定Swagger JSON文件的终结点，用于加载和显示API文档。
                // 为默认分组设置端点
                c.SwaggerEndpoint("/swagger/vdefault/swagger.json", "Default API");
                //指定swagger文档的启动目录 。默认为swagger
                //可以通过设置为空字符串来让Swagger UI直接在根路径下进行访问
                //c.RoutePrefix = string.Empty;

                //设置默认的接口文档展开方式，可选值包括None、List和Full。
                //默认值为None，表示不展开接口文档；
                //List表示只展开接口列表；
                //Full表示展开所有接口详情
                c.DocExpansion(DocExpansion.None); // 设置为完整模式 
                c.DisplayRequestDuration();
                c.EnablePersistAuthorization();

                //c.UseRequestInterceptor("(request) => { return defaultRequestInterceptor(request); }");
                //c.UseResponseInterceptor("(response) => { return defaultResponseInterceptor(response); }");
            }); 
        }


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