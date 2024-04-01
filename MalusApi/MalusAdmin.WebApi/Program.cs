using MalusAdmin.Common.Components.Token;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace MalusAdmin.WebApi
{
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
            });
             

            // 配置Json选项
            builder.Services.AddJsonOptions();

            // 添加sqlsugar
            builder.Services.AddSqlsugarSetup();

            // 添加swagger文档
            builder.Services.AddSwaggerSetup();

            // 添加基础服务
            //builder.Services.AddBaseServicesSetup();

            // 自动添加服务层
            builder.Services.AddAutoServices("MalusAdmin.Servers");

            // 添加jwt认证
            //builder.Services.AddJwtSetup();
            // 添加自定义授权
            builder.Services.AddAuthorizationSetup();
            // 替换默认 PermissionChecker
            //builder.Services.Replace(new ServiceDescriptor(typeof(IPermissionChecker), typeof(PermissionChecker), ServiceLifetime.Transient));
             
            //Token
            builder.Services.AddSingleton<ITokenService, GuidTokenService>(); 

            // 添加跨域支持
            builder.Services.AddCorsSetup();
            // 添加EndpointsApiExplorer
            builder.Services.AddEndpointsApiExplorer(); 

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    //指定Swagger JSON文件的终结点，用于加载和显示API文档。
                    //需要提供JSON文件的URL和一个可识别的名称
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
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
             
            //Token验证
            app.UseMiddleware<CheckToken>();
             
            app.UseHttpsRedirection();
            // UseCors 必须在 UseRouting 之后，UseResponseCaching、UseAuthorization 之前
            app.UseCors();

            // 使用身份验证
            app.UseAuthentication();
            // 然后是授权中间件
            app.UseAuthorization();

            //使用静态文件
            app.UseStaticFiles();

            app.MapControllers();

            app.Run();
        }
    }
}
