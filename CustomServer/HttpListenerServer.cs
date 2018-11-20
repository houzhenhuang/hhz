using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace CustomServer
{
    public class HttpListenerServer
    {
        private readonly HttpListener listener;

        public HttpListenerServer()
        {
            listener = new HttpListener();
        }

        public void Start()
        {
            string address = "http://localhost:5000";
            listener.Prefixes.Add(address.TrimEnd('/') + "/");
            listener.Start();
            Console.WriteLine("服务器已启动，监听地址：" + address);
            while (true)
            {
                HttpListenerContext httpListenerContext = listener.GetContext();

                byte[] content = Encoding.UTF8.GetBytes("Hello World!");
                //httpListenerContext.Response.ContentType = contentType;
                httpListenerContext.Response.OutputStream.Write(content, 0, content.Length);
            }
        }
    }
}
