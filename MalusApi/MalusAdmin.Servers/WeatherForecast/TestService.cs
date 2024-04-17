using System.Security.Permissions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Routing;
using SqlSugar; 
using MalusAdmin.Common;

namespace MalusAdmin.Servers.WeatherForecast
{
    /// <summary>
    /// 测试服务
    /// </summary>
    public class TestService
    {
        private readonly ISqlSugarClient _db;
        readonly IHttpContextAccessor _httpContext;
        private readonly IActionDescriptorCollectionProvider _actionDescriptorCollectionProvider;
        public TestService(ISqlSugarClient db, IActionDescriptorCollectionProvider actionDescriptorCollectionProvider)

        {

            _db = db;
            _actionDescriptorCollectionProvider = actionDescriptorCollectionProvider;
        }

        /// <summary>
        /// 获取接口所有的路由信息
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public async Task<dynamic> GetAllButen()
        {
            // 获取所有路由信息
            var actionDescriptors = _actionDescriptorCollectionProvider.ActionDescriptors.Items;

            // 创建一个列表来存储路由信息
            var routeInfoList = new List<dynamic>();

            // 遍历所有路由信息
            foreach (var actionDescriptor in actionDescriptors)
            { 
                // 检查路由是否是HTTP动作
                if (actionDescriptor.EndpointMetadata.Any(m => m is HttpMethodMetadata))
                {
                    // 创建一个字典来存储路由信息
                    var routeInfo = new Dictionary<string, object>
                    {
                        { "permissionName",actionDescriptor.EndpointMetadata.OfType<PermissionAttribute>().FirstOrDefault()?.PermissionName},
                        { "ApiPath", "api:"+actionDescriptor.RouteValues["controller"]+":" + actionDescriptor.RouteValues["action"]},
                        { "ActionName", actionDescriptor.DisplayName },
                        { "RouteTemplate", actionDescriptor.RouteValues["action"] },
                        { "ControllerName", actionDescriptor.RouteValues["controller"] },
                        { "HttpMethods", actionDescriptor.EndpointMetadata.OfType<HttpMethodMetadata>().Select(m => m.HttpMethods.FirstOrDefault()) }
                    };

                    // 将字典添加到列表中
                    routeInfoList.Add(routeInfo);
                }
            }

            // 将列表转换为动态类型返回
            return routeInfoList;
        }

    }
}
