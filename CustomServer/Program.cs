using System;

namespace CustomServer
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                HttpListenerServer server = new HttpListenerServer();
                server.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }

}
