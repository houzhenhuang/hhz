using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Pipeline.Interfaces;

namespace Pipeline
{
    public class DefaultHttpResponse : HttpResponse
    {
        public IHttpResponseFeature HttpResponseFeature { get; }
        public DefaultHttpResponse(DefaultHttpContext context)
        {
            this.HttpResponseFeature = context.HttpContextFeatures.Get<IHttpResponseFeature>();
        }
        public override Stream OutputStream { get => this.HttpResponseFeature.OutputStream; }

        public override string ContentType { get => this.HttpResponseFeature.ContentType; set => this.HttpResponseFeature.ContentType = value; }
        public override int StatusCode { get => this.HttpResponseFeature.StatusCode; set => this.HttpResponseFeature.StatusCode = value; }
    }
}
