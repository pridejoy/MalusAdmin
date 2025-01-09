using System.Reflection;
using Quartz;
using Quartz.Impl;

namespace MalusAdmin.BackUpServices;

public class JobService
{
    private readonly IScheduler scheduler;

    public JobService()
    {
        scheduler = new StdSchedulerFactory().GetScheduler().GetAwaiter().GetResult();
    }

    /// <summary>
    /// 开始执行所有的job
    /// </summary>
    /// <returns></returns>
    public async Task StartAll()
    {
        var jobTypes = GetJobTypes(); // 获取所有实现了 IJob 接口的类型
        foreach (var type in jobTypes)
        {
            Console.WriteLine($"当前任务：{type.Name}");
            var jobDetail = JobBuilder.Create(type).Build();
            var trigger = TriggerBuilder.Create().WithCronSchedule(GetCronExpression(type)).Build();
            await scheduler.ScheduleJob(jobDetail, trigger);
        }
        Console.WriteLine("开始执行所有的job");
        await scheduler.Start();
    }

    private IEnumerable<Type> GetJobTypes()
    {
        return Assembly.GetExecutingAssembly().GetTypes().Where(type => typeof(IJob).IsAssignableFrom(type));
    }


    private string GetCronExpression(Type type)
    {
        // 可以根据需要自定义获取 cron 表达式的逻辑
        //return (string)type.GetField("Cron", BindingFlags.Static | BindingFlags.Public)?.GetValue(null)??"";
        
        var cron = type.GetCustomAttribute<CronAttribute>().Cron;
        Console.WriteLine("表达式"+cron);
        if (string.IsNullOrEmpty(cron)) throw new Exception("当前特性Corn为空，请检查");
        return cron;
    }
}