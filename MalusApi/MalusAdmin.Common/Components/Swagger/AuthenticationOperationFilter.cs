using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

public class AuthenticationOperationFilter : IOperationFilter
{
    /// <summary>
    ///     Swagger UI 的配置代码。具体来说，它获取当前正在执行的 API 方法的所有自定义属性，
    ///     然后检查其中是否有任何 "AuthorizeAttribute" 属性。
    /// </summary>
    /// <param name="operation"></param>
    /// <param name="context"></param>
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var actionAttributes = context.MethodInfo.GetCustomAttributes(true);
        var declaringTypeAttributes = context.MethodInfo.DeclaringType?.GetCustomAttributes(true);

        if (declaringTypeAttributes != null)
            actionAttributes = actionAttributes.Concat(declaringTypeAttributes).ToArray();

        var authorizeAttributes = actionAttributes.OfType<AuthorizeAttribute>();

        if (authorizeAttributes.Any())
        {
            //operation.Responses.Add("401", new OpenApiResponse { Description = "Unauthorized" });
            //operation.Responses.Add("403", new OpenApiResponse { Description = "Forbidden" });
            var bearerScheme = new OpenApiSecurityScheme
            {
                Scheme = "Bearer",
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
            };
            operation.Security = new List<OpenApiSecurityRequirement>
            {
                new()
                {
                    [bearerScheme] = Array.Empty<string>()
                }
            };
        }
    }
}