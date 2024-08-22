using Microsoft.AspNetCore.Builder;

namespace MalusAdmin.BackUpServices
{
    internal class Program
    {
        //文档地址:https://www.dotnetshare.com/guid/service/quartz-service.html
        public static async Task Main(string[] args)
        {
            //为了解耦单独得做成服务
            var builder = WebApplication.CreateBuilder(args);
            //https://www.dotnetshare.com/guid/service/install/use-windows-server.html
            //指定项目可以部署为Windows服务
            builder.Host.UseWindowsService();
            //指定项目可以部署为Linux服务,可以和 UseWindowsService() 共存
            //builder.Host.UseSystemd(); 
            builder.Services.AddSingleton<JobService>(); 
            //可添加sqlsugaer的注入 
            var app = builder.Build();
            //获取任务服务
            var jobService = app.Services.GetService<JobService>();
            //开始执行
            await jobService.StartAll();

            await FileHelper.Write("任务开始了", "run");
            app.Run();
        }
    }
}
