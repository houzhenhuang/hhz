using System;
using System.Collections.Generic;
using System.Text;

namespace Pipeline.Interfaces
{
    public interface IHttpRequestFeature
    {
        Uri Url { get; }
        string PathBase { get; }
    }
}
