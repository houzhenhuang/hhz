using Pipeline.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pipeline
{
    public class DefaultHttpRequest : HttpRequest
    {
        public IHttpRequestFeature RequestFeature { get; }
        public DefaultHttpRequest(DefaultHttpContext context)
        {
            this.RequestFeature = context.HttpContextFeatures.Get<IHttpRequestFeature>();

        }
        public override Uri Url { get => this.RequestFeature.Url; }

        public override string PathBase { get => this.RequestFeature.PathBase; }
    }
}
