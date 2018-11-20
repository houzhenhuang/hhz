using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Configuration
{
    class Program
    {
        static void Main(string[] args)
        {
            {//以键-值对的形式读取配置
                //Dictionary<string, string> dataSource = new Dictionary<string, string>()
                //{
                //    ["longDatePattern"] = "dddd, MMMM d, yyyy",
                //    ["longTimePattern"] = "h:mm:ss tt",
                //    ["shortDatePattern"] = "M/d/yyyy",
                //    ["shortTimePattern"] = "h:mm tt"
                //};
                //IConfiguration config = new ConfigurationBuilder()
                //    .Add(new MemoryConfigurationSource() { InitialData = dataSource })
                //    .Build();
                //DateTimeFormatOptions options = new DateTimeFormatOptions(config);
                //Console.WriteLine($"LongDatePattern: {options.LongDatePattern}");
                //Console.WriteLine($"LongTimePattern: {options.LongTimePattern}");
                //Console.WriteLine($"ShortDatePattern: {options.ShortDatePattern}");
                //Console.WriteLine($"ShortTimePattern: {options.ShortTimePattern}");
            }

            {//读取结构化的配置
                //Dictionary<string, string> source = new Dictionary<string, string>
                //{
                //    ["format:dateTime:longDatePattern"] = "dddd, MMMM d, yyyy",
                //    ["format:dateTime:longTimePattern"] = "h:mm:ss tt",
                //    ["format:dateTime:shortDatePattern"] = "M/d/yyyy",
                //    ["format:dateTime:shortTimePattern"] = "h:mm tt",

                //    ["format:currencyDecimal:digits"] = "2",
                //    ["format:currencyDecimal:symbol"] = "$",
                //};
                //IConfiguration configuration = new ConfigurationBuilder()
                //        .Add(new MemoryConfigurationSource
                //        {
                //            InitialData = source
                //        })
                //       .Build();

                //FormatOptions options = new FormatOptions(configuration.GetSection("Format"));
                //DateTimeFormatOptions dateTime = options.DateTime;
                //CurrencyDecimalFormatOptions currencyDecimal = options.CurrencyDecimal;

                //Console.WriteLine("DateTime:");
                //Console.WriteLine($"\tLongDatePattern: {dateTime.LongDatePattern}");
                //Console.WriteLine($"\tLongTimePattern: {dateTime.LongTimePattern}");
                //Console.WriteLine($"\tShortDatePattern: {dateTime.ShortDatePattern}");
                //Console.WriteLine($"\tShortTimePattern: {dateTime.ShortTimePattern}");

                //Console.WriteLine("CurrencyDecimal:");
                //Console.WriteLine($"\tDigits:{currencyDecimal.Digits}");
                //Console.WriteLine($"\tSymbol:{currencyDecimal.Symbol}");
            }
            //.NET Core的配置系统采用一种叫做“Options Pattern”的编程模式来支持从原始配置到Options对象之间的绑定
            {//将结构化配置直接绑定为对象
                Dictionary<string, string> source = new Dictionary<string, string>
                {
                    ["format:dateTime:longDatePattern"] = "dddd, MMMM d, yyyy",
                    ["format:dateTime:longTimePattern"] = "h:mm:ss tt",
                    ["format:dateTime:shortDatePattern"] = "M/d/yyyy",
                    ["format:dateTime:shortTimePattern"] = "h:mm tt",

                    ["format:currencyDecimal:digits"] = "2",
                    ["format:currencyDecimal:symbol"] = "$",
                };
                IConfiguration configuration = new ConfigurationBuilder()
                        .Add(new MemoryConfigurationSource
                        {
                            InitialData = source
                        })
                       .Build();
                {//方法一
                    FormatOptions options = new ServiceCollection()//创建一个ServiceCollection对象
                                         .AddOptions()//并调用扩展方法AddOptions注册于针对Option模型的服务
                                         .Configure<FormatOptions>(configuration.GetSection("Format"))//调用Configure方法将FormatOptions这个Option类型与对应的Configuration对象进行映射
                                         .BuildServiceProvider()// 我们最后利用这个ServiceCollection对象生成一个ServiceProvider
                                         .GetService<IOptions<FormatOptions>>()//并调用其GetService方法得到一个类型为IOptions<FormatOptions>的对象
                                         .Value;//后者的Value属性返回的就是绑定了相关配置的FormatOptions对象

                    DateTimeFormatOptions dateTime = options.DateTime;
                    CurrencyDecimalFormatOptions currencyDecimal = options.CurrencyDecimal;

                    Console.WriteLine("DateTime:");
                    Console.WriteLine($"\tLongDatePattern: {dateTime.LongDatePattern}");
                    Console.WriteLine($"\tLongTimePattern: {dateTime.LongTimePattern}");
                    Console.WriteLine($"\tShortDatePattern: {dateTime.ShortDatePattern}");
                    Console.WriteLine($"\tShortTimePattern: {dateTime.ShortTimePattern}");

                    Console.WriteLine("CurrencyDecimal:");
                    Console.WriteLine($"\tDigits:{currencyDecimal.Digits}");
                    Console.WriteLine($"\tSymbol:{currencyDecimal.Symbol}");
                }

                {//方法二
                    var services = new ServiceCollection();
                    //services.AddSingleton(typeof(IOptions<>), typeof(OptionsManager<>));
                    services.AddSingleton<IOptions<FormatOptions>, OptionsManager<FormatOptions>>();
                    services.Configure<FormatOptions>(configuration.GetSection("Format"));
                    var provider = services.BuildServiceProvider();
                    var options = provider.GetService<IOptions<FormatOptions>>().Value;

                    DateTimeFormatOptions dateTime = options.DateTime;
                    CurrencyDecimalFormatOptions currencyDecimal = options.CurrencyDecimal;

                    Console.WriteLine("DateTime:");
                    Console.WriteLine($"\tLongDatePattern: {dateTime.LongDatePattern}");
                    Console.WriteLine($"\tLongTimePattern: {dateTime.LongTimePattern}");
                    Console.WriteLine($"\tShortDatePattern: {dateTime.ShortDatePattern}");
                    Console.WriteLine($"\tShortTimePattern: {dateTime.ShortTimePattern}");

                    Console.WriteLine("CurrencyDecimal:");
                    Console.WriteLine($"\tDigits:{currencyDecimal.Digits}");
                    Console.WriteLine($"\tSymbol:{currencyDecimal.Symbol}");
                }
            }
            Console.ReadKey();
        }
    }
    public class DateTimeFormatOptions
    {
        public DateTimeFormatOptions(IConfiguration config)
        {
            this.LongDatePattern = config["LongDatePattern"];
            this.LongTimePattern = config["LongTimePattern"];
            this.ShortDatePattern = config["ShortDatePattern"];
            this.ShortTimePattern = config["ShortTimePattern"];
        }
        public DateTimeFormatOptions()
        {

        }
        public string LongDatePattern { get; set; }
        public string LongTimePattern { get; set; }
        public string ShortDatePattern { get; set; }
        public string ShortTimePattern { get; set; }
    }
    public class CurrencyDecimalFormatOptions
    {
        public int Digits { get; set; }
        public string Symbol { get; set; }
        public CurrencyDecimalFormatOptions()
        {

        }
        public CurrencyDecimalFormatOptions(IConfiguration config)
        {
            this.Digits = int.Parse(config["Digits"]);
            this.Symbol = config["Symbol"];
        }
    }
    public class FormatOptions
    {
        public DateTimeFormatOptions DateTime { get; set; }
        public CurrencyDecimalFormatOptions CurrencyDecimal { get; set; }

        public FormatOptions()
        {

        }
        public FormatOptions(IConfiguration config)
        {
            this.DateTime = new DateTimeFormatOptions(config.GetSection("DateTime"));
            this.CurrencyDecimal = new CurrencyDecimalFormatOptions(config.GetSection("CurrencyDecimal"));
        }
    }
}
