using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MalusAdmin.Common
{
    /// <summary>
    /// 内部App副本
    /// </summary>
    public static class InternalApp
    {
        /// <summary>
        /// 应用服务
        /// </summary>
        internal static IServiceCollection InternalServices;

        /// <summary>
        /// 根服务
        /// </summary>
        internal static IServiceProvider RootServices;

        /// <summary>
        /// 配置对象
        /// </summary>
        internal static IConfiguration Configuration;

        /// <summary>
        /// 获取Web主机环境
        /// </summary>
        internal static IWebHostEnvironment WebHostEnvironment;

        /// <summary>
        /// 获取泛型主机环境
        /// </summary>
        internal static IHostEnvironment HostEnvironment;


        public static void ConfigureApplication(this WebApplicationBuilder wab)
        {
            HostEnvironment = wab.Environment;
            WebHostEnvironment = wab.Environment;
            InternalServices = wab.Services;
        }

        public static void ConfigureApplication(this IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static void ConfigureApplication(this IHost app)
        {
            RootServices = app.Services;
        }
    }
}
