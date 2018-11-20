using System;
using System.Collections.Generic;
using System.Text;

namespace Pipeline
{
    public abstract class HttpRequest
    {
        public abstract Uri Url { get; }
        public abstract string PathBase { get; }
    }
}
