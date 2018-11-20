using Pipeline.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pipeline
{
    public class DelegateStartup : IStartup
    {
        private Action<IApplicationBuilder> configure;
        public DelegateStartup(Action<IApplicationBuilder> configure)
        {
            this.configure = configure;
        }

        public void Configure(IApplicationBuilder app)
        {
            configure(app);
        }
    }
}
