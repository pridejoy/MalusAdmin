using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MalusAdmin.Common.Components;

public static class AddJwtSwaggerSetup
{
    public static SwaggerGenOptions AddJwtSwagger(this SwaggerGenOptions options)
    {
        //在 Swagger UI 中显示相应的安全要求信息（api有"Authorize" 特性，加上小锁）
        options.OperationFilter<SecurityRequirementsOperationFilter>();

        // api有"Authorize" 特性， header中添加 token 传递到后台
        options.OperationFilter<JwtOperationFilter>();
        // 添加授权要求

        //接入Jwt认证，swagger右上角加上手动可以添加token的按钮
        options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Scheme = "Bearer",
            BearerFormat = "JWT",
            Description = "在下面输入框输入Token,不用输入Bearer[空格] ",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.Http
        });

        return options;
    }
}