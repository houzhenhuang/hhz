using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuartzDemo.Quartz
{
    public class TimeJob : IJob
    {
        async Task IJob.Execute(IJobExecutionContext context)
        {
            await Task.Run(()=> {
                System.IO.File.AppendAllText(@"D:\hhz\CommonDemo\QuartzDemo\bin\Debug\quartz.txt", DateTime.Now + Environment.NewLine);
            }); 
        }
    }
}
