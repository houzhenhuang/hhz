using Pipeline.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pipeline
{
    public class ApplicationBuilder : IApplicationBuilder
    {
        private IList<Func<RequestDelegate, RequestDelegate>> middlewares = new List<Func<RequestDelegate, RequestDelegate>>();
        public RequestDelegate Build()
        {
            RequestDelegate seed = context => Task.Run(() => { });
            return middlewares.Reverse().Aggregate(seed, (next, current) => current(next));
            //var result=middlewares[0] fun1(seed)
            //result=middlewares[1] fun1(result)
            //...

        }

        public IApplicationBuilder Use(Func<RequestDelegate, RequestDelegate> middleware)
        {
            middlewares.Add(middleware);
            return this;
        }
    }
}
