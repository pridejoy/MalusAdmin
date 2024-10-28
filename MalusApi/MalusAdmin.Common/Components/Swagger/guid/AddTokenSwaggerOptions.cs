using MalusAdmin.Common.Components;
using MalusAdmin.Common.Components.Swagger;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MalusAdmin.Common;

public static class SwaggerSetup
{
    public static IServiceCollection AddSwaggerSetup(this IServiceCollection services)
    {
        // 默认配置
        Action<SwaggerGenOptions> defaultSetupAction = options =>
        {
            options.SwaggerDoc("vdefault", new OpenApiInfo { Title = "Default API", Version = "v1" });

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

            //添加jwt的
            //options.AddJwtSwagger();
            //DOTO: 此处根据用的是jwt或者是Guid Token 来进行切换
            options.AddTokenSwagger();

            //判断接口归于哪个分组
            options.DocInclusionPredicate((docName, apiDescription) =>
            {
                if (docName == "vdefault")
                    //当分组为NoGroup时，只要没加特性的都属于这个组
                    return string.IsNullOrEmpty(apiDescription.GroupName);
                return apiDescription.GroupName == docName;
            });
        };

        // 注册 Swagger 并添加默认配置
        services.AddSwaggerGen(defaultSetupAction);

        //文档分组
        services.AddTransient<IConfigureOptions<SwaggerGenOptions>, SwaggerConfigureOptions>();
 

        return services;
    }
}