namespace MalusAdmin.WebApi.Middleware
{
    using Microsoft.Extensions.DependencyInjection;
    using System.Text.Json;
    using System.Threading.Tasks;

    public class ServiceInspectorMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IServiceCollection _services;

        public ServiceInspectorMiddleware(RequestDelegate next, IServiceCollection services)
        {
            _next = next;
            _services = services;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // 检查请求路径是否为 /allservices
            if (context.Request.Path.Equals("/allservices", StringComparison.OrdinalIgnoreCase))
            {
                // 准备服务信息列表
                var serviceInfos = _services.Select(s => new
                {
                    ServiceType = s.ServiceType.FullName,
                    ImplementationType = s.ImplementationType?.FullName ?? s.ImplementationInstance?.GetType().FullName ?? "Factory",
                    Lifetime = s.Lifetime.ToString()
                }).ToList();

                // 设置响应内容类型为 JSON
                context.Response.ContentType = "application/json";

                // 序列化服务信息并写入响应
                var json = JsonSerializer.Serialize(serviceInfos, new JsonSerializerOptions { WriteIndented = true });
                await context.Response.WriteAsync(json);

                return; // 终止管道
            }

            // 继续执行下一个中间件
            await _next(context);
        }
    }

    // 扩展方法以简化中间件注册
    public static class ServiceInspectorMiddlewareExtensions
    {
        public static IApplicationBuilder UseServiceInspector(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ServiceInspectorMiddleware>();
        }
    }
}
