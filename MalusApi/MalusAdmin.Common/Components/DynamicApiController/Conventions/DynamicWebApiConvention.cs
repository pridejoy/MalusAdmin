using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Simple.DynamicWebApi.Consts;
using Simple.DynamicWebApi.Helper;
using System.Numerics;
using System.Reflection;

namespace Simple.DynamicWebApi.Conventions;

/// <summary>
/// 动态接口控制器应用模型转换器
/// 参考：https://www.cnblogs.com/h82258652/p/12454554.html
/// </summary>
internal class DynamicWebApiConvention : IApplicationModelConvention
{
    /// <summary>
    /// 普通方法转换为动态接口控制器
    /// </summary>
    /// <param name="application"></param>
    public void Apply(ApplicationModel application)
    {
        //仅需对动态接口控制器进行配置
        var dynamicWebApiControllers = application.Controllers.Where(u => { return ControllerSelector.IsDynamicWebApiController(u.ControllerType); });

        foreach (var controller in dynamicWebApiControllers)
        {
            controller.ControllerName = controller.ControllerName.RemovePostFix(DynamicWebApiConsts.CommonPostfixes);
            ConfigureDynamicWebApi(controller);
        }
    }

    /// <summary>
    /// 配置动态WebApi控制器的文档显示、路由规则、控制器参数
    /// </summary>
    /// <param name="controller"></param>
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
        if (!controller.ApiExplorer.IsVisible.HasValue)
        {
            controller.ApiExplorer.IsVisible = true;
            controller.ApiExplorer.GroupName = controller.ControllerName;//Swagger文档分组为控制器名称,默认为控制器名称
        }

        foreach (var action in controller.Actions)
        {
            if (!action.ApiExplorer.IsVisible.HasValue)
            {
                action.ApiExplorer.IsVisible = true;
            }
        }

    }

    /// <summary>
    /// 参数配置
    /// </summary>
    /// <param name="controller"></param>
    private void ConfigureSelector(ControllerModel controller)
    {
        RemoveEmptySelectors(controller.Selectors); //每个 SelectorModel 都定义了一个 路由规则，包含
                                                    //1.路由模板（AttributeRouteModel）： [Route("api/users")]
                                                    //2.HTTP 方法约束（ActionConstraints）：[HttpGet]、[HttpPost]...
                                                    //3.端点元数据（EndpointMetadata）:[ApiController]、[Authorize]、[AllowAnonymous]、与路由相关的元数据，例如 Swagger 描述、自定义过滤器等。
                                                    // asp.net core 框架会自动生成一些空白信息，这里移除空白信息，然后实现自定义路由规则
                                                    //获取控制器根路径
        var rootPath = GetRootPathOrDefault(controller.ControllerType.AsType());

        foreach (var action in controller.Actions)
        {
            ConfigureActionSelector(controller, rootPath, controller.ControllerName, action);
        }
    }

    /// <summary>
    /// 添加路由规则
    /// </summary>
    private void ConfigureActionSelector(ControllerModel controller, string rootPath, string controllerName, ActionModel action)
    {
        RemoveEmptySelectors(action.Selectors);


        if (!action.Selectors.Any())
        {
            //todo:研究下action.Selectors为0的情况
            AddApplicationServiceSelector(rootPath, controllerName, action);
        }
        else
        {
            NormalizeSelectorRoutes(controller, rootPath, controllerName, action);
        }
    }

    /// <summary>
    /// 移除空白信息
    /// </summary>
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
               && (selector.ActionConstraints == null || selector.ActionConstraints.Count <= 0)
               && (selector.EndpointMetadata == null || selector.EndpointMetadata.Count <= 0);
    }

    /// <summary>
    /// 获取控制器根路径
    /// </summary>
    /// <param name="controllerType"></param>
    /// <returns></returns>
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
        return DynamicWebApiConsts.DefaultRootPath;
    }

    /// <summary>
    /// 实现自定义路由规则
    /// </summary>
    private void NormalizeSelectorRoutes(ControllerModel controller, string rootPath, string controllerName, ActionModel action)
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
                httpMethod = DynamicWebApiHelper.SelectHttpMethod(action.ActionName);
            }

            // 如果没有定义 HTTP 方法约束，则添加默认的 HTTP 方法,如当Action打上[HttpGet]特性时，此处会自动添加[HttpGet]约束
            if (!selector.ActionConstraints.OfType<HttpMethodActionConstraint>().Any())
            {
                selector.ActionConstraints.Add(new HttpMethodActionConstraint(new[] { httpMethod }));
            }


            // 如果action已存在[Route]特性， ASP.NET Core 会自动对其进行路由模板的处理，此处需要清空掉ASP.NET Core 自动生成的路由模板
            // 通过类型判断，不能通过是否为空来判断：因为如果是存在[HttpGet]特性，selector.AttributeRouteModel 不为空
            if (selector.AttributeRouteModel?.Attribute is AttributeRouteModel)
            {
                //selector.AttributeRouteModel.Template = string.Empty;
                //改为报错更清晰
                throw new InvalidOperationException($"控制器 '{controller.ControllerType.FullName}' 中的方法 '{action.ActionName}' 具有 [Route] 特性，DynamicWebApi 不支持此特性。");
            }

            var controllerTemplate = controller.ControllerType.GetCustomAttributes().OfType<RouteAttribute>().FirstOrDefault()?.Template;

            //情况1：controllerTemplate为空，即控制器无[Route]特性
            if (string.IsNullOrEmpty(controllerTemplate))
            {
                //情况1.1：控制器无[Route]特性,action存在[HttpMethod]特性
                if (selector.AttributeRouteModel?.Attribute is Microsoft.AspNetCore.Mvc.Routing.HttpMethodAttribute)
                {
                    //对 [HttpGet("")]的情况做报错处理
                    if (selector.AttributeRouteModel.Template.IsNullOrEmpty())
                    {
                        throw new InvalidOperationException($"控制器 '{controller.ControllerType.FullName}' 中的方法 '{action.ActionName}' 具有 [HttpGet] 特性，但没有指定路由模板。");
                    }
                    //路由模版为：api/rootPath/controllerName/{selector.AttributeRouteModel.Template}
                    selector.AttributeRouteModel = new AttributeRouteModel(new RouteAttribute(CalculateRouteTemplate(rootPath, controllerName, selector.AttributeRouteModel.Template!)));
                    continue;
                }
                else
                {
                    //情况1.2：控制器无[Route]特性,action不存在[HttpMethod]特性
                    selector.AttributeRouteModel = new AttributeRouteModel(new RouteAttribute(CalculateRouteTemplate(rootPath, controllerName, FormatActionName(action.ActionName, httpMethod))));
                    continue;
                }
            }
            else
            {

                // 情况2：控制器存在[Route]特性

                // 情况2.1：控制器存在[Route]特性,且以[action]结尾
                if (controllerTemplate.EndsWith("/[action]"))
                {
                    //[Route("api/[controller]/[action]")]
                    //对路由模版置空，避免拼接[HttpGet("GetName")]造成重复拼接问题
                    if (selector.AttributeRouteModel?.Attribute is Microsoft.AspNetCore.Mvc.Routing.HttpMethodAttribute && !selector.AttributeRouteModel.Template.IsNullOrEmpty())
                    {
                        //selector.AttributeRouteModel.Template = string.Empty;
                    }

                    continue;
                }
                else
                {
                    //情况2.1：控制器存在[Route]特性,action存在[HttpMethod]特性
                    if (selector.AttributeRouteModel?.Attribute is Microsoft.AspNetCore.Mvc.Routing.HttpMethodAttribute)
                    {
                        //对 [HttpGet("")]的情况做报错处理
                        if (selector.AttributeRouteModel.Template.IsNullOrEmpty())
                        {
                            throw new InvalidOperationException($"控制器 '{controller.ControllerType.FullName}' 中的方法 '{action.ActionName}' 具有 [HttpGet] 特性，但没有指定路由模板。");
                        }
                        //路由模版为：api/rootPath/controllerName/{selector.AttributeRouteModel.Template}
                        selector.AttributeRouteModel = new AttributeRouteModel(new RouteAttribute(selector.AttributeRouteModel.Template!));
                        continue;
                    }
                    else
                    {
                        //情况2.2：控制器存在[Route]特性,action不存在[HttpMethod]特性
                        selector.AttributeRouteModel = new AttributeRouteModel(new RouteAttribute(FormatActionName(action.ActionName, httpMethod)));
                        continue;
                    }
                }
            }
        }
    }

    /// <summary>
    ///  计算路由模板，例如：api/v1/users/create-user
    /// </summary>
    private string CalculateRouteTemplate(string rootPath, string controllerName, string templateName)
    {
        var url = string.Empty;

        // 1. 获取路由前缀
        var apiRoutePrefix = DynamicWebApiHelper.GetApiRoutePrefix();

        // 2. 转换控制器名称为路由格式
        var controllerSegment = controllerName.ToKebabCase();


        if (DynamicWebApiConsts.DefaultIsRootPathInRoute)
        {
            url = $"{apiRoutePrefix}/{rootPath}/{controllerSegment}";
        }
        else
        {
            url = $"{apiRoutePrefix}/{controllerSegment}";
        }

        if (!templateName.IsNullOrEmpty())
        {
            url = $"{url}/{templateName}";
        }

        return url;
    }


    /// <summary>
    /// 添加默认的路由规则
    /// </summary>
    private void AddApplicationServiceSelector(string rootPath, string controllerName, ActionModel action)
    {
        var httpMethod = DynamicWebApiHelper.SelectHttpMethod(action.ActionName);

        var selector = new SelectorModel();
        selector.AttributeRouteModel = new AttributeRouteModel(new RouteAttribute(CalculateRouteTemplate(rootPath, controllerName, FormatActionName(action.ActionName, httpMethod))));
        selector.ActionConstraints.Add(new HttpMethodActionConstraint(new[] { httpMethod }));
        action.Selectors.Add(selector);
    }

    /// <summary>
    /// 配置参数绑定信息，将非基础类型参数设置为FromBody绑定
    /// </summary>
    /// <param name="controller"></param>
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

                // 非基础类型参数设置为FromBody绑定
                if (!DynamicWebApiHelper.IsPrimitiveExtendedIncludingNullable(prm.ParameterInfo.ParameterType))
                {
                    if (CanUseFormBodyBinding(action, prm))
                    {
                        prm.BindingInfo = BindingInfo.GetBindingInfo(new[] { new FromBodyAttribute() });
                    }
                }
            }
        }
    }

    /// <summary>
    /// 判断是否可以使用FromBody绑定
    /// </summary>
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

    /// <summary>
    /// 格式化Action名称（移除HTTP方法前缀和Async后缀），例如GetUsersAsync => users, PostCreateUserAsync => create-user
    /// </summary>
    /// <param name="actionName"></param>
    /// <param name="httpMethod"></param>
    /// <returns></returns>
    private string FormatActionName(string actionName, string httpMethod)
    {
        return actionName
            .RemoveHttpMethodPrefix(httpMethod)
            .RemovePostFix("Async")
            .ToKebabCase();
    }
}
