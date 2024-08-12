using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace MalusAdmin.Common.Components
{
    public static class SwaggerExtension
    {
        public static void UseSwaggerExtension(this IApplicationBuilder app)
        {
            app.UseSwagger( );
            app.UseSwaggerUI(c =>
            {
                // 获取 IApiDescriptionGroupCollectionProvider 服务
                var provider = App.GetService<IApiDescriptionGroupCollectionProvider>();

                // 遍历所有API描述组
                foreach (var descriptionGroup in provider.ApiDescriptionGroups.Items)
                {
                    if (descriptionGroup.GroupName is null)
                    {
                        // 为默认分组设置端点
                        c.SwaggerEndpoint("/swagger/vdefault/swagger.json", "Default API");
                    }
                    else
                    {
                        // 为每个分组指定Swagger文档和标题
                        c.SwaggerEndpoint($"/swagger/{descriptionGroup.GroupName}/swagger.json", descriptionGroup.GroupName);
                    } 
                    
                }
                //指定Swagger JSON文件的终结点，用于加载和显示API文档。
               
                //指定swagger文档的启动目录 。默认为swagger
                //可以通过设置为空字符串来让Swagger UI直接在根路径下进行访问
                //c.RoutePrefix = string.Empty;

                //设置默认的接口文档展开方式，可选值包括None、List和Full。
                //默认值为None，表示不展开接口文档；
                //List表示只展开接口列表；
                //Full表示展开所有接口详情
                c.DocExpansion(DocExpansion.None); // 设置为完整模式 
                c.DisplayRequestDuration();
                c.EnablePersistAuthorization();

                //c.UseRequestInterceptor("(request) => { return defaultRequestInterceptor(request); }");
                //c.UseResponseInterceptor("(response) => { return defaultResponseInterceptor(response); }");
            });
        }
    }
}
