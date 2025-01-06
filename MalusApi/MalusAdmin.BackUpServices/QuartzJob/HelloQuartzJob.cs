 
//using MalusAdmin.Common;
//using MalusAdmin.Repository.Model;
//using Newtonsoft.Json;
//using Quartz;
//using SqlSugar;

//namespace MalusAdmin.BackUpServices.QuartzJob;

//public class HelloQuartzJob : IJob
//{
//    /// <summary>
//    /// 当前任务执行的Core表达式
//    /// </summary>
//    public static string Cron = "0/1 * * * * ? ";


//    //private readonly ISqlSugarClient db;
//    //public HelloQuartzJob(ISqlSugarClient db)
//    //{
//    //    this.db = db;
//    //}


//    public async Task Execute(IJobExecutionContext context)
//    {
//        try
//        {
//            //业务处理逻辑
//            Console.WriteLine("任务1,连接是：" + AppSettings.RabbitMqConnetion);

//            // 查询数据库表
//            //var date = await new SqlsugarHelper().db.Queryable<BsBingWallpaper>() 
//            //     .Take(1)
//            //    .OrderBy(x => SqlFunc.GetRandom())
//            //    .FirstAsync();

//            //Console.WriteLine(JsonConvert.SerializeObject(date));
//        }
//        catch (Exception ex)
//        {
//            FileHelper.Write(ex.Message, "error");
//        }
//    }
//}