using MalusAdmin.Common.Components;
using MalusAdmin.Common.Components.Swagger;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MalusAdmin.Common;

public static class SwaggerSetup
{
    public static IServiceCollection AddSwaggerBaseSetup(this IServiceCollection services)
    {
        //为 Swagger 提供了必要的路由和端点信息
        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen(o =>
        {

            //文档加上注释
            var basePath = System.AppDomain.CurrentDomain.BaseDirectory;
            // 获取所有 .xml 文件（默认不包含子目录）
            foreach (var xmlFile in Directory.GetFiles(basePath, "*.xml"))
            {
                o.IncludeXmlComments(xmlFile, true);
            }


            foreach (var group in typeof(ApiVersionGropInfo).GetFields())
            { 
                o.SwaggerDoc(group.Name, new OpenApiInfo
                {
                    
                    Title = $"MalusAdmin {group.Name} API",
                    Version = group.Name,
                    Description = $"MalusAdmin {group.Name} API文档"
                });
            }

            // 根据 GroupName 匹配文档版本
            o.DocInclusionPredicate((docName, apiDesc) =>
            {
                return apiDesc.GroupName == docName;
            });

            o.OrderActionsBy(a => a.GroupName);
            //o.OrderActionsBy(x=>x)

        });

        ////默认文档
        //services.AddSwaggerGen(SwaggerDocConfiguration.Configure);
        ////JWT配置
        services.AddSwaggerGen(SwaggerConfiguration.Configure);
        ////文档版本管理==》此处用户分组
        ////services.AddTransient<IConfigureOptions<SwaggerGenOptions>, SwaggerGroup>();

        //// 其他配置
        Action<SwaggerGenOptions> defaultSetupAction = options =>
        {

        };

        //// 注册 Swagger 并添加默认配置
        services.AddSwaggerGen(defaultSetupAction);


        return services;
    }
}