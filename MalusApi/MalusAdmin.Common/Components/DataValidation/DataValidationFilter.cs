using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MalusAdmin.Common
{
    public class DataValidationFilter : IActionFilter, IOrderedFilter
    {
        public const int FilterOrder = -2000;

        public int Order { get; set; } = FilterOrder;

        public void OnActionExecuting(ActionExecutingContext context)
        {

            // 检查是否需要禁用模型验证
            //if (context.ActionArguments.ContainsKey("pageInput") &&
            //    context.ActionArguments["pageInput"] is Keyword)
            //{
            //    // 禁用模型验证
            //    //context.ModelState.Clear();
            //    return;
            //}

            // 如果其他过滤器已经设置了结果，则跳过验证
            if (context.Result != null) return;

            // 获取模型验证状态
            var modelState = context.ModelState;

            // 如果验证通过，跳过后面的动作
            if (modelState.IsValid) return;

            // 获取失败的验证信息列表
            var errors = modelState.Where(s => s.Value != null && s.Value.ValidationState == ModelValidationState.Invalid)
                                   .SelectMany(s => s.Value!.Errors.ToList())
                                   .Select(e => e.ErrorMessage)
                                   .ToArray();

            // 统一返回
            var result = ApiResultHelper.Result400BadRequest("数据验证不通过！", errors);

            // 设置结果
            context.Result = new ObjectResult(result); 
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
