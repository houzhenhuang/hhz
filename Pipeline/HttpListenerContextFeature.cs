using Pipeline.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Pipeline
{
    public class HttpListenerContextFeature : IHttpRequestFeature, IHttpResponseFeature
    {
        private readonly HttpListenerContext context;

        public HttpListenerContextFeature(HttpListenerContext context, HttpListener listener)
        {
            this.context = context;
            this.Url = context.Request.Url;
            this.OutputStream = context.Response.OutputStream;
            this.PathBase = (from it in listener.Prefixes
                             let pathBase = new Uri(it).LocalPath.TrimEnd('/')
                             where context.Request.Url.LocalPath.StartsWith(pathBase, StringComparison.OrdinalIgnoreCase)
                             select pathBase).First();
        }

        public Uri Url { get; set; }

        public string PathBase { get; set; }

        public Stream OutputStream { get; set; }

        public string ContentType
        {
            get { return context.Response.ContentType; }
            set { context.Response.ContentType = value; }
        }
        public int StatusCode
        {
            get { return context.Response.StatusCode; }
            set { context.Response.StatusCode = value; }
        }
    }
}
