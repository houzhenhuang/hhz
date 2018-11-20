using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Logging.Debug;
using System;
using System.Text;

namespace Logging
{
    class Program
    {
        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Func<string, LogLevel, bool> filter = (category, level) => level >= LogLevel.Warning;
            {//基本使用
                ILoggerFactory loggerFactory = new LoggerFactory();
                loggerFactory.AddProvider(new ConsoleLoggerProvider(filter, true));
                loggerFactory.AddProvider(new DebugLoggerProvider(filter));
                ILogger logger = loggerFactory.CreateLogger(nameof(Program));

                int eventId = 3212;
                logger.LogInformation(eventId, "升级到最新.NET Core版本({version})", "2.1.1");
                logger.LogWarning(eventId, "并发量接近上限({maximum}) ", 200);
                logger.LogError(eventId, "数据库连接失败(数据库：{Database}，用户名：{User})", "TestDb", "sa");
            }
            {//调用LoggerFactory扩展方法
                ILogger logger = new LoggerFactory()
               .AddConsole((c, l) => l > LogLevel.Warning)
               .AddDebug((c, l) => l > LogLevel.Warning)
               .CreateLogger(nameof(Program));

                int eventId = 3212;
                logger.LogInformation(eventId, "升级到最新.NET Core版本({version})", "2.1.1");
                logger.LogWarning(eventId, "并发量接近上限({maximum}) ", 200);
                logger.LogError(eventId, "数据库连接失败(数据库：{Database}，用户名：{User})", "TestDb", "sa");
            }

            {//采用依赖注入编程模式创建Logger
                ILogger logger = new ServiceCollection()
                   .AddLogging()
                   .BuildServiceProvider()
                   .GetService<ILoggerFactory>()
                   .AddConsole(LogLevel.Warning)
                   .AddDebug()
                   .CreateLogger(nameof(Program));
            }
            {
                IServiceCollection services = new ServiceCollection();
                services.AddLogging();
                var provider = services.BuildServiceProvider();
                var loggerFactory = provider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(new ConsoleLoggerProvider(filter, true));
                loggerFactory.AddProvider(new DebugLoggerProvider());
                ILogger logger = loggerFactory.CreateLogger(nameof(Program));
                int eventId = 3212;
                logger.LogInformation(eventId, "升级到最新.NET Core版本({version})", "2.1.1");
                logger.LogWarning(eventId, "并发量接近上限({maximum}) ", 200);
                logger.LogError(eventId, "数据库连接失败(数据库：{Database}，用户名：{User})", "TestDb", "sa");
            }
            {
                //EventLogLogger;ConsoleLogger;ConsoleLoggerProvider;DebugLogger;
            }

            Console.ReadKey();
        }
    }
}
