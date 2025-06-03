using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MalusAdmin.Common.Components.Swagger
{
    public static class SwaggerDocConfiguration
    {  
        public static void Configure(SwaggerGenOptions options)
        {
            options.DocInclusionPredicate((docName, description) => true);

            var basePath = AppContext.BaseDirectory;

            // 获取根目录下，所有 xml 完整路径（注：并不会获取二级目录下的文件）
            var directoryInfo = new DirectoryInfo(basePath);
            var xmls = directoryInfo
                .GetFiles()
                .Where(f => f.Name.ToLower().EndsWith(".xml"))
                .Select(f => f.FullName)
                .ToList();

            // 添加注释文档
            foreach (var xml in xmls) options.IncludeXmlComments(xml, true);
        }
    }
}
