using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Pipeline.Interfaces
{
    public interface IHttpResponseFeature
    {
        Stream OutputStream { get; }
        string ContentType { get; set; }
        int StatusCode { get; set; }
    }
}
