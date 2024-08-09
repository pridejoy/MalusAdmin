using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Quartz;

namespace MalusAdmin.BackUpServices.QuartzJob
{
    public class WordQuartzJob : IJob
    {
        /// <summary>
        /// 当前任务执行的Core表达式
        /// </summary>
        public static string Cron = "*/1 * * * * ?";


        public async Task Execute(IJobExecutionContext context)
        {
            try
            {
                //业务处理逻辑
                Console.WriteLine("我是WordQuartzJob，任务2");

                // 查询数据库表
                //var date = await SqlsugarHelper.db.Queryable<bs_gallery>()
                //    .Where(x => x.IsDelete == false)
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
}
