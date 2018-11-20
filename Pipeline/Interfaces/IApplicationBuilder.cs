using System;
using System.Collections.Generic;
using System.Text;

namespace Pipeline.Interfaces
{
    public interface IApplicationBuilder
    {
        RequestDelegate Build();
        IApplicationBuilder Use(Func<RequestDelegate, RequestDelegate> middleware);
    }
}
