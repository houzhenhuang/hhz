using System;
using System.Collections.Generic;
using System.Text;

namespace Pipeline
{
    public abstract class HttpContext
    {
        public abstract HttpRequest Request { get; }
        public abstract HttpResponse Response { get; }
    }
}
