using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using SqlSugar.Extensions;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace MalusAdmin.Common.Components;

public static class SwaggerExtension
{
    /// <summary>
    /// app.use
    /// </summary>
    /// <param name="app"></param>
    public static void UseSwaggerExtension(this IApplicationBuilder app)
    {
        if (App.Configuration["DisplaySwaggerDoc"].ObjToBool())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                foreach (var group in typeof(ApiVersionGropInfo).GetFields())
                {
                    c.SwaggerEndpoint($"/swagger/{group.Name}/swagger.json", $"{group.Name} ");
                }
                 

                c.RoutePrefix = string.Empty; // 如果需要将 Swagger UI 放在根路径下

                c.DocExpansion(DocExpansion.None);
                c.DisplayRequestDuration();
                c.EnablePersistAuthorization();
            }

            );
        } 
    }
}