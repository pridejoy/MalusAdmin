using System.Linq.Expressions;
using MalusAdmin.Common.Components;
using MalusAdmin.Servers.Hub;
using MalusAdmin.WebApi;


try
{
    var builder = WebApplication.CreateBuilder(args);
    //App注册 
    builder.ConfigureApplication();
    // 注册服务
    builder.Services.AddApplicationServices(builder.Configuration);

    var app = builder.Build();

    // 配置中间件
    app.UseApplicationMiddlewares();

    app.MapHub<OnlineUserHub>("/hub");

    app.Run();
}
catch (Exception e)
{
    Console.WriteLine("启动异常："+e.Message);
	throw;
}

