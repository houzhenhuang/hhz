using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace Log4NetDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure();

            TestLog log = new TestLog();
            Console.WriteLine("ok");
            Console.ReadKey();
        }
    }

    public class TestLog
    {
        ILog log = LogManager.GetLogger(typeof(TestLog));

        public TestLog()
        {
            log.Error(string.Format("this type is {0}", typeof(TestLog)));
        }
    }
}
