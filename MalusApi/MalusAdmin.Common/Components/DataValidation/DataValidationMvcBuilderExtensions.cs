using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace MalusAdmin.Common
{
    public static class DataValidationMvcBuilderExtensions
    {
        /// <summary>
        /// 配置模型验证
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="filterOrder">结果过滤器排序</param>
        /// <returns></returns>
        public static IMvcBuilder AddDataValidation(this IMvcBuilder builder, int filterOrder = DataValidationFilter.FilterOrder)
        {
            builder.ConfigureApiBehaviorOptions(options =>
            {
                // 禁用默认模型验证过滤器
                options.SuppressModelStateInvalidFilter = true;
            });

            builder.AddMvcOptions(options =>
            {
                // 添加自定义模型验证过滤器
                //options.Filters.Add<DataValidationFilter>(filterOrder);
            });

            return builder;
        }
    }
}
