using System;

namespace Pipeline
{
    class Program
    {
        static void Main(string[] args)
        {
            new WebHostBuilder()
                 .UseHttpListener()
                 //.UseUrls("http://localhost:3721/images")
                 .Configure(app => app.UseImages(@"c:\images"))
                 .Build()
                 .Start();

            Console.Read();
        }
    }
}
