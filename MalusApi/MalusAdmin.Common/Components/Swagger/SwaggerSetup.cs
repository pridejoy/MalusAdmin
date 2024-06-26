using MalusAdmin.Common.Components.Swagger;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MalusAdmin.Common;

public static class SwaggerSetup
{
    public static IServiceCollection AddSwaggerSetup(this IServiceCollection services)
    {
        // 默认配置
        Action<SwaggerGenOptions> defaultSetupAction = options =>
        {
            var basePath = AppContext.BaseDirectory;


            // 获取根目录下，所有 xml 完整路径（注：并不会获取二级目录下的文件）
            var directoryInfo = new DirectoryInfo(basePath);
            var xmls = directoryInfo
                .GetFiles()
                .Where(f => f.Name.ToLower().EndsWith(".xml"))
                .Select(f => f.FullName)
                .ToList();

            // 添加注释文档
            foreach (var xml in xmls) options.IncludeXmlComments(xml, true);

            //在 Swagger UI 中显示相应的安全要求信息（api有"Authorize" 特性，加上小锁）
            options.OperationFilter<SecurityRequirementsOperationFilter>();

            // api有"Authorize" 特性， header中添加 token 传递到后台
            options.OperationFilter<TokenOperationFilter>();
            // 添加授权要求


            // 接入Jwt认证，swagger右上角加上手动可以添加token的按钮
            //options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            //{
            //    Scheme = "Bearer",
            //    BearerFormat = "JWT",
            //    Description = "在下面输入框输入Token,不用输入Bearer[空格] ",
            //    Name = "Authorization",
            //    In = ParameterLocation.Header,
            //    Type = SecuritySchemeType.Http
            //});

            options.AddSecurityDefinition("Token", new OpenApiSecurityScheme
            {
                Scheme = "Bearer",
                BearerFormat = "Token",
                Description = "在下面输入框输入GuidToken,不用输入",
                Name = "Token",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http
            });
        };

        // 注册 Swagger 并添加默认配置
        services.AddSwaggerGen(defaultSetupAction);

        //文档分组
        services.AddTransient<IConfigureOptions<SwaggerGenOptions>, SwaggerConfigureOptions>();

        // 如果有自定义配置
        //if (setupAction != null) services.Configure(setupAction);

        return services;
    }
}