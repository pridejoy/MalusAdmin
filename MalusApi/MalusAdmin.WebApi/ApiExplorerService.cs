using Microsoft.AspNetCore.Mvc.Infrastructure;

public class ApiExplorerService
{
    private readonly IActionDescriptorCollectionProvider _provider;

    public ApiExplorerService(IActionDescriptorCollectionProvider provider)
    {
        _provider = provider;
    }

    /// <summary>
    /// 扫描所有API端点并返回它们的列表
    /// </summary>
    /// <returns></returns>
    public List<string> GetAllEndpoints()
    {
        var endpoints = new List<string>();

        foreach (var descriptor in _provider.ActionDescriptors.Items)
        {
            var method = descriptor.EndpointMetadata.OfType<HttpMethodMetadata>().FirstOrDefault()?.HttpMethods.FirstOrDefault() ?? "Unknown";
            var route = descriptor.AttributeRouteInfo?.Template;
            if (route != null)
            {
                endpoints.Add($"{method} /{route}");
            }
        }

        return endpoints;
    }
}