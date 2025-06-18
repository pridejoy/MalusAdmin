using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;

public static class JsonCollectionExtensions
{
    /// <summary>
    /// 添加默认 Json 序列化/反序列化 配置
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    //[Obsolete("不在使用")]
    public static IServiceCollection AddJsonOptions(this IServiceCollection services, Action<JsonSerializerOptions>? setupAction = null)
    {

        // 教程：https://mp.weixin.qq.com/s/4ZdnOqI72zz1kbXinhv-ng

        // 配置 JsonOptions
        services.AddControllers()
            .AddNewtonsoftJson(options =>
            {
                // 首字母小写(驼峰样式)
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                // 时间格式化
                options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
                // 忽略循环引用
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                // 忽略空值
                //options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            });

        return services;
    }
}