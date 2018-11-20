using Pipeline.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pipeline
{
    public class DefaultHttpContext : HttpContext
    {
        public IFeatureCollection HttpContextFeatures { get; }
        public DefaultHttpContext(IFeatureCollection httpContextFeatures)
        {
            this.HttpContextFeatures = httpContextFeatures;
            this.Request = new DefaultHttpRequest(this);
            this.Response = new DefaultHttpResponse(this);
        }
        public override HttpRequest Request { get; }
        public override HttpResponse Response { get; }
    }
}
