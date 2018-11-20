using Quartz;
using Quartz.Impl;
using QuartzDemo.Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuartzDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            RunProgramRunExample2Async().GetAwaiter();

            Console.ReadKey();
        }

        public static async Task RunProgramRunExampleAsync()
        {
            IScheduler scheduler;
            ISchedulerFactory schedulerFactory;
            //1、创建一个调度器
            schedulerFactory = new StdSchedulerFactory();
            scheduler = await schedulerFactory.GetScheduler();
            //2、创建一个任务
            IJobDetail job = JobBuilder.Create<TimeJob>().WithIdentity("job1", "group1").Build();

            //3、创建一个触发器
            ITrigger trigger = TriggerBuilder.Create().WithIdentity("tigger1", "group1").WithCronSchedule("0/5 * * * * ?").Build();

            //4、将任务与触发器添加到调度器中
            await scheduler.ScheduleJob(job, trigger);
            //5、开始执行
            await scheduler.Start();
        }
        public static async Task RunProgramRunExample2Async()
        {
            IScheduler scheduler;
            ISchedulerFactory schedulerFactory;
            //1、创建一个调度器
            schedulerFactory = new StdSchedulerFactory();
            scheduler = await schedulerFactory.GetScheduler();

            //2、定义工作并将其与我们的TimeJob类联系起来
            IJobDetail job = JobBuilder.Create<TimeJob>()
               .WithIdentity("job1", "group1")
               .Build();
            //3、现在触发作业运行，然后每5秒钟重复一次
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("tigger1", "group1")
                .WithSimpleSchedule(x=>
                    x.WithIntervalInSeconds(5)//间隔时间为秒
                    .RepeatForever())//永远重复
                .Build();

            await scheduler.ScheduleJob(job, trigger);
            await scheduler.Start();
        }


    }
}
