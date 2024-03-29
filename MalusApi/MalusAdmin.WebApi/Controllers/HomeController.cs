using System.Reflection;
using MalusAdmin.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MalusAdmin.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ApiControllerBase
    {
        [HttpGet]
        [AllowAnonymous]
        public ApiResult<string> Index()
        {
            return SuccessResult("string");
        }

        [HttpPost]
        public string Two()
        {


            var allowAnonymousEndpoints = new List<string>();
            // 获取程序集中的所有控制器类型
            var controllerTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => type.IsSubclassOf(typeof(Controller)) && !type.IsAbstract);
            // 遍历所有控制器和动作方法
            foreach (var controllerType in controllerTypes)
            {
                var controllerActions = controllerType.GetMethods(BindingFlags.Public | BindingFlags.Instance)
                    .Where(method => method.DeclaringType == controllerType && method.GetCustomAttribute<NonActionAttribute>() == null);
                foreach (var action in controllerActions)
                {
                    // 检查动作方法或控制器类是否标记有[AllowAnonymous]特性
                    if (action.GetCustomAttribute<AllowAnonymousAttribute>() != null || controllerType.GetCustomAttribute<AllowAnonymousAttribute>() != null)
                    {
                        // 构造动作方法的URL模板
                        var selector = controllerType.Name + "." + action.Name;
                        allowAnonymousEndpoints.Add(selector);
                    }
                }
            }

            return "";
        }
        
    }
}
