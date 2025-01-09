using System.Text.Json.Serialization;
using MalusAdmin.Common;
using MalusAdmin.Repository.Model;
using Newtonsoft.Json;
using Quartz;
using SqlSugar;

namespace MalusAdmin.BackUpServices;

[Cron("0/1 * * * * ? ")]
public class HelloQuartzJob : IJob
{
  
    public async Task Execute(IJobExecutionContext context)
    {
        try
        {
            //业务处理逻辑
            Console.WriteLine("任务1,HelloQuartzJob");

            // 查询数据库表
            //var date = await new SqlsugarHelper().db.Queryable<BsBingWallpaper>() 
            //     .Take(1)
            //    .OrderBy(x => SqlFunc.GetRandom())
            //    .FirstAsync();

            //Console.WriteLine(JsonConvert.SerializeObject(date));
        }
        catch (Exception ex)
        {
            FileHelper.Write(ex.Message, "error");
        }
    }
}