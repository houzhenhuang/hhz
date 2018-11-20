using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Pipeline
{
    public abstract class HttpResponse
    {
        public abstract Stream OutputStream { get; }
        public abstract string ContentType { get; set; }
        public abstract int StatusCode { get; set; }
    }
}
