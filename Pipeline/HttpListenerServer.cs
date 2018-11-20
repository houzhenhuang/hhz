using Pipeline.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Pipeline
{
    public class HttpListenerServer : IServer
    {
        public HttpListener Listener { get; }
        public IFeatureCollection Features { get; }

        public HttpListenerServer()
        {
            this.Listener = new HttpListener();
            this.Features = new FeatureCollection().Set<IServerAddressesFeature>(new ServerAddressesFeature());
        }

        public void Start<TContext>(IHttpApplication<TContext> application)
        {
            IServerAddressesFeature addressFeatures = this.Features.Get<IServerAddressesFeature>();
            foreach (string address in addressFeatures.Addresses)
            {
                this.Listener.Prefixes.Add(address.TrimEnd('/') + "/");
            }
            this.Listener.Start();
            foreach (var item in this.Listener.Prefixes)
            {
                Console.WriteLine("服务启动成功，监听地址：" + item);
            }
            while (true)
            {
                HttpListenerContext httpListenerContext = this.Listener.GetContext();

                HttpListenerContextFeature feature = new HttpListenerContextFeature(httpListenerContext, this.Listener);

                IFeatureCollection contextFeatures = new FeatureCollection()
                .Set<IHttpRequestFeature>(feature)
                .Set<IHttpResponseFeature>(feature);

                TContext context = application.CreateContext(contextFeatures);

                application.ProcessRequestAsync(context)
                   .ContinueWith(_ => httpListenerContext.Response.Close())
                   .ContinueWith(_ => application.DisposeContext(context, _.Exception));
            }
        }
    }
}
