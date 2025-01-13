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
        //默认文档
        services.AddSwaggerGen(SwaggerDocConfiguration.Configure);
        //JWT配置
        services.AddSwaggerGen(SwaggerConfiguration.Configure);
        //文档分组
        services.AddTransient<IConfigureOptions<SwaggerGenOptions>, SwaggerGroup>();

        // 其他配置
        Action<SwaggerGenOptions> defaultSetupAction = options =>
        {

        };

        // 注册 Swagger 并添加默认配置
        services.AddSwaggerGen(defaultSetupAction);


        return services;
    }
}