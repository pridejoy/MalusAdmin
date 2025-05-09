using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Reflection;
using System.Text;
using static System.Collections.Specialized.BitVector32;

namespace MalusAdmin.Common;

/// <summary>
/// 动态接口控制器应用模型转换器
/// 参考：https://www.cnblogs.com/h82258652/p/12454554.html
/// https://learn.microsoft.com/zh-cn/aspnet/core/fundamentals/routing?view=aspnetcore-9.0
/// </summary>
public class DynamicWebApiConvention : IApplicationModelConvention
{
    public void Apply(ApplicationModel application)
    {
        //仅需对动态接口控制器进行配置
        var dynamicControllers = application.Controllers.Where(u => { return ControllerSelector.IsDynamicApiController(u.ControllerType); });

        foreach (var controller in dynamicControllers)
        {
            controller.ControllerName = controller.ControllerName.RemovePostFix(DynamicApiConsts.CommonPostfixes);
            ConfigureDynamicWebApi(controller);
        }
    }
    private void ConfigureDynamicWebApi(ControllerModel controller)
    {
        ConfigureApiExplorer(controller);
        ConfigureSelector(controller);
        ConfigureParameters(controller);
    }
    /// <summary>
    /// Swagger/OpenAPI 文档分组、显示
    /// </summary>
    /// <param name="controller"></param>
    private void ConfigureApiExplorer(ControllerModel controller)
    {
        var controllerApiSettings = controller.Attributes
            .OfType<ApiExplorerSettingsAttribute>()
            .FirstOrDefault();

        controller.ApiExplorer.GroupName = controllerApiSettings?.GroupName ?? controller.ControllerName;
        controller.ApiExplorer.IsVisible = controllerApiSettings != null ? !controllerApiSettings.IgnoreApi : true;

        foreach (var action in controller.Actions)
        {
            //根据ApiExplorerSettingsAttribute特性设置Action的显示状态
            var actionApiSettings = action.Attributes
                .OfType<ApiExplorerSettingsAttribute>()
                .FirstOrDefault();

            if (controller.ApiExplorer.IsVisible == false && actionApiSettings?.IgnoreApi != true)
            {
                action.ApiExplorer.IsVisible = false;
            }
            else
            {
                action.ApiExplorer.IsVisible = actionApiSettings != null ? !actionApiSettings.IgnoreApi : true;
            }
        }
    }
    private void ConfigureSelector(ControllerModel controller)
    {
        RemoveEmptySelectors(controller.Selectors); //每个 SelectorModel 都定义了一个 路由规则，包含
                                                    //1.路由模板（AttributeRouteModel）： [Route("api/users")]
                                                    //2.HTTP 方法约束（ActionConstraints）：[HttpGet]、[HttpPost]...
                                                    //3.端点元数据（EndpointMetadata）:[ApiController]、[Authorize]、[AllowAnonymous]、与路由相关的元数据，例如 Swagger 描述、自定义过滤器等。
                                                    // asp.net core 框架会自动生成一些空白信息，这里移除空白信息，然后实现自定义路由规则


        //if (controller.Selectors.Any(temp => temp.AttributeRouteModel != null))//如果类已经打上了[Route]特性，则不再添加自定义模版信息(不明白ABP为什么要这么做)
        //{
        //    return;
        //}

        //获取控制器根路径
        var rootPath = GetRootPathOrDefault(controller.ControllerType.AsType());

        //如果action被打上[NonAction]标记，根据 ASP.NET Core 约定，该action不再是一个有效的Action，不会出现在controller.Actions中，所以不用在此处进行对[NonAction]特性的过滤处理
        foreach (var action in controller.Actions)
        {
            ConfigureActionSelector(rootPath, controller.ControllerName, action);
        }
    }
    private void ConfigureActionSelector(string rootPath, string controllerName, ActionModel action)
    {
        RemoveEmptySelectors(action.Selectors);

        if (!action.Selectors.Any())
        {
            //正常情况下此方法应该不会执行，因为每个方法至少有一个System.Runtime.CompilerServices.NullableContextAttribute特性，此处只是为了防止万一出现这种情况
            AddApplicationServiceSelector(rootPath, controllerName, action);
        }
        else
        {
            NormalizeSelectorRoutes(rootPath, controllerName, action);
        }
    }
    protected virtual void RemoveEmptySelectors(IList<SelectorModel> selectors)
    {
        selectors
            .Where(IsEmptySelector)
            .ToList()
            .ForEach(s => selectors.Remove(s));
    }
    protected virtual bool IsEmptySelector(SelectorModel selector)
    {
        return selector.AttributeRouteModel == null
                && selector.ActionConstraints.IsNullOrEmpty()
                && selector.EndpointMetadata.IsNullOrEmpty();
    }
    protected virtual string GetRootPathOrDefault(Type controllerType)
    {
        //1.此处可以从配置文件中读取，如有需要可自行扩展


        //2.从[Area]特性中获取
        var areaAttribute = controllerType.GetCustomAttributes().OfType<AreaAttribute>().FirstOrDefault();
        if (areaAttribute?.RouteValue != null)
        {
            return areaAttribute.RouteValue;
        }

        //3.从DynamicApiConsts.DefaultRootPath中获取
        return DynamicApiConsts.DefaultRootPath;
    }
    private void NormalizeSelectorRoutes(string rootPath, string controllerName, ActionModel action)
    {
        foreach (var selector in action.Selectors)
        {
            var httpMethod = selector.ActionConstraints
                                .OfType<HttpMethodActionConstraint>()
                                .FirstOrDefault()?
                                .HttpMethods?
                                .FirstOrDefault();

            if (httpMethod == null)
            {
                httpMethod = DynamicApiHelper.SelectHttpMethod(action.ActionName);
            }

            // 如果方法没有打上[Route]/[HttpGet]特性，添加默认的路由模板
            // 例如方法打上了[Route("api/test")]/[HttpGet("api/test")]特性，则selector.AttributeRouteModel 的 Template 会被ASP.NET自动设置为api/test
            if (selector.AttributeRouteModel == null)
            {
                selector.AttributeRouteModel = new AttributeRouteModel(new RouteAttribute(CalculateRouteTemplate(rootPath, controllerName, action, httpMethod)));
            }

            // 如果没有定义 HTTP 方法约束，则添加默认的 HTTP 方法,如当Action打上[HttpGet]特性时，此处会自动添加[HttpGet]约束
            if (!selector.ActionConstraints.OfType<HttpMethodActionConstraint>().Any())
            {
                selector.ActionConstraints.Add(new HttpMethodActionConstraint(new[] { httpMethod }));
            }
        }
    }
    private void AddApplicationServiceSelector(string rootPath, string controllerName, ActionModel action)
    {
        var httpMethod = DynamicApiHelper.SelectHttpMethod(action.ActionName);

        var selector = new SelectorModel();
        selector.AttributeRouteModel = new AttributeRouteModel(new RouteAttribute(CalculateRouteTemplate(rootPath, controllerName, action, httpMethod)));
        selector.ActionConstraints.Add(new HttpMethodActionConstraint(new[] { httpMethod }));
        action.Selectors.Add(selector);
    }
    private string CalculateRouteTemplate(string rootPath, string controllerName, ActionModel action, string httpMethod)
    {
        // 1. 获取基础路由前缀
        var apiRoutePrefix = DynamicApiHelper.GetApiRoutePrefix(action);

        // 2. 转换控制器名称为路由格式
        var controllerSegment = controllerName.ToKebabCase();

        // 3. 处理Action名称（移除HTTP方法前缀和Async后缀）
        var actionSegment = action.ActionName
            .RemoveHttpMethodPrefix(httpMethod)
            .RemovePostFix("Async")
            .ToKebabCase();

        // 4. 构建基础路径（根据配置决定是否包含rootPath）
        var baseUrl = DynamicApiConsts.DefaultIsRootPathInRoute
            ? $"{apiRoutePrefix}/{rootPath}/{controllerSegment}"
            : $"{apiRoutePrefix}/{controllerSegment}";

        // 5. 附加Action路径段（当存在有效值时）
        return !actionSegment.IsNullOrEmpty()
            ? $"{baseUrl}/{actionSegment}"
            : baseUrl;
    }

    private void ConfigureParameters(ControllerModel controller)
    {
        foreach (var action in controller.Actions)
        {
            foreach (var prm in action.Parameters)
            {
                if (prm.BindingInfo != null)
                {
                    continue;
                }

                if (!DynamicApiHelper.IsPrimitiveExtended(prm.ParameterInfo.ParameterType, includeEnums: true))
                {
                    if (CanUseFormBodyBinding(action, prm))
                    {
                        prm.BindingInfo = BindingInfo.GetBindingInfo(new[] { new FromBodyAttribute() });
                    }
                }
            }
        }
    }

    protected virtual bool CanUseFormBodyBinding(ActionModel action, ParameterModel parameter)
    {
        if (parameter.ParameterName == "id")
        {
            return false;
        }

        foreach (var selector in action.Selectors)
        {
            if (selector.ActionConstraints == null)
            {
                continue;
            }

            foreach (var actionConstraint in selector.ActionConstraints)
            {
                var httpMethodActionConstraint = actionConstraint as HttpMethodActionConstraint;
                if (httpMethodActionConstraint == null)
                {
                    continue;
                }

                if (httpMethodActionConstraint.HttpMethods.All(hm => hm.IsIn("GET", "DELETE", "TRACE", "HEAD")))
                {
                    return false;
                }
            }
        }

        return true;
    }
}
