using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MalusAdmin.Common.Components.Swagger;

public class SwaggerGroup : IConfigureOptions<SwaggerGenOptions>
{
    private readonly IApiDescriptionGroupCollectionProvider provider;

    public SwaggerGroup(IApiDescriptionGroupCollectionProvider provider)
    {
        this.provider = provider;
    }

    public void Configure(SwaggerGenOptions options)
    {
        // 为每个 API 描述组创建一个 Swagger 文档
        foreach (var group in provider.ApiDescriptionGroups.Items)
            if (!string.IsNullOrEmpty(group.GroupName))
                options.SwaggerDoc(group.GroupName, new OpenApiInfo
                {
                    Title = $"{group.GroupName} API",
                    Version = group.GroupName,
                    Description = $"Documentation for {group.GroupName} version of the API"
                });

        // 为没有明确分组的控制器创建默认分组
        options.SwaggerDoc("Default", new OpenApiInfo
        {
            Title = "Default API",
            Version = "Default",
            Description = "Default API documentation for unspecified versions"
        });


        options.OrderActionsBy(a => a.GroupName);
    }
}