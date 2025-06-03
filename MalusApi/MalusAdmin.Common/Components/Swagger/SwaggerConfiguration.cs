using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MalusAdmin.Common.Components.Swagger
{
    public static class SwaggerConfiguration
    {
        public static OpenApiSecurityScheme Scheme => new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "在下面输入框输入Token,不用输入Bearer[空格] ",
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Scheme = "Bearer",
            Reference = new OpenApiReference
            {
                Id = "Bearer",
                Type = ReferenceType.SecurityScheme,
            },
        };

        public static void Configure(SwaggerGenOptions option)
        {
            // 解决Swagger文档中API描述冲突的问题，取第一个描述作为最终结果
            option.ResolveConflictingActions(apiDesc => apiDesc.First());

            // 向Swagger中添加JWT Bearer安全定义，便于前端在请求头中传递Token
            option.AddSecurityDefinition(Scheme.Reference.Id, Scheme);

            // 配置Swagger要求在所有API请求中使用上述定义的安全方案（即JWT Bearer Token）
            option.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                { Scheme, Array.Empty<string>() },
            });
        }
    }
}
