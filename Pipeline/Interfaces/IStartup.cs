using System;
using System.Collections.Generic;
using System.Text;

namespace Pipeline.Interfaces
{
    public interface IStartup
    {
        void Configure(IApplicationBuilder app);
    }
}
