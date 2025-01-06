using MalusAdmin.Common;
using Microsoft.AspNetCore.Builder;

namespace MalusAdmin.BackUpServices;

internal class Program
{
    //文档地址:https://www.dotnetshare.com/guid/service/quartz-service.html
    public static async Task Main(string[] args)
    {
		try
		{


            //为了解耦单独得做成服务
            var builder = WebApplication.CreateBuilder(args);

            //进行配置注册 | 添加静态文件读取(优先级比较高)
            AppSettings.AddConfigSteup(builder.Configuration);

            //https://www.dotnetshare.com/guid/service/install/use-windows-server.html
            //指定项目可以部署为Windows服务
            //builder.Host.UseWindowsService();

            //添加sqlsugaer的注入
            builder.Services.AddSqlsugarSetup();

            builder.Services.AddSingleton<JobService>();

            var app = builder.Build();
            //获取任务服务
            var jobService = app.Services.GetService<JobService>();

            await jobService.StartAll();

            await FileHelper.Write("任务开始了", "run");

            Console.WriteLine("开始执行");

            app.Run();
        }
		catch (Exception e)
		{

			throw;
		}
    }
}